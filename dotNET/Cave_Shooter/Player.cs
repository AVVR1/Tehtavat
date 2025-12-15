using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class Player : Damageable, IHealth
	{
		// Constants
		public const float COLLIDER_RADIUS = 25f;
		private const float GRAVITY = -9.81f;
		private const float GRAVITY_MULT = 5f;
		private const float MAX_HEALTH = 100f;
		private const float ENGINE_POWER = 200f;
		private const float TURN_POWER = 300f;
		private const float FRICTION = 0.5f;

		// Events
		public event Action<Vector2, Vector2> OnShoot;
		public event Action<Vector2, Vector2> OnShootSpecial;
		public event Action OnThrust;
		public event Action OnPlayerHurt;
		public event Action OnPlayerDeath;


		// Camera
		public Camera2D camera;
		public RenderTexture2D screenCameraTexture;
		public Rectangle splitScreenRect; // splitScreen position and Size.

		// Transform
		private Vector2 previousPos;
		private Vector2 position = new Vector2(200, 200);
		private float rotation = 0f;

		// Miscellaneous
		public Map currentMap { private get; set; }
		private IInput inputDevice;
		public static Texture2D texture;
		private Weapon weapon;

		// Physics variables
		private float engineThrust = 0f;
		private float maxSpeed = 300f;
		/// <summary>
		/// direction of where the player sprite is facing
		/// </summary>
		private Vector2 direction;
		private Vector2 acceleration;
		private Vector2 velocity;
		/// <summary>
		/// last valid normal that got calculated on terrain collision.
		/// Only updates if a valid normal is found.
		/// </summary>
		private Vector2 lastValidNormal;

		public Player(Weapon weapon, IInput inputDevice) // Initialize player
		{
			this.weapon = weapon;
			this.inputDevice = inputDevice;
			maxHealth = MAX_HEALTH;
			health = MAX_HEALTH;
		}

		public static void InitTexture()
		{
			texture = Raylib.LoadTexture("Images/Drawf.png");
			Raylib.SetTextureFilter(texture, TextureFilter.Bilinear);
		}

		public void InitCamera()
		{
			camera.Offset = new Vector2(screenCameraTexture.Texture.Width / 2, screenCameraTexture.Texture.Height / 2);
			camera.Zoom = 1;
			camera.Rotation = 0;
		}

		#region input events
		private void Shoot()
		{
			Console.WriteLine("Shoot");
		}

		private void ShootSpecial()
		{
			Console.WriteLine("ShootSpecial");
		}

		private void Thrust()
		{
			engineThrust = ENGINE_POWER;
		}

		private void Turn(float amount)
		{
			rotation += amount * TURN_POWER * Raylib.GetFrameTime();
			rotation %= 360;
		}

		public void OnDeath()
		{
			OnPlayerDeath?.Invoke();
		}

		public void OnHurt()
		{
			OnPlayerHurt?.Invoke();
		}
		#endregion

		public void Update()
		{
			camera.Target = position;
			CalculatePhysics();
			Input();
			CheckTerrainCollision();
		}

		private void CalculatePhysics()
		{
			previousPos = position;
			float deltaTime = Raylib.GetFrameTime();
			acceleration = Vector2.Zero;
			direction = Vector2.Transform(-Vector2.UnitY, Matrix3x2.CreateRotation(rotation * Raylib.DEG2RAD));

			acceleration += direction * engineThrust;
			acceleration += -Vector2.UnitY * GRAVITY * GRAVITY_MULT;

			velocity += acceleration * deltaTime;

			if (velocity.Length() > maxSpeed)
			{
				velocity = Vector2.Normalize(velocity) * maxSpeed;
			}
			position += velocity * deltaTime;

			// Set engine thrust back to 0 to deactivate when not pressing thrust key.
			engineThrust = 0f;
		}

		private void Input()
		{
			// TODO: run input functionality if Input matches inputdevice button
			if (Raylib.IsKeyPressed((KeyboardKey)inputDevice.ShootInput))
			{
				OnShoot?.Invoke(position, direction);
				Shoot();
			}
			if (Raylib.IsKeyPressed((KeyboardKey)inputDevice.ShootSpecialInput))
			{
				OnShootSpecial?.Invoke(position, direction);
				ShootSpecial();
			}
			if (Raylib.IsKeyDown((KeyboardKey)inputDevice.ThrustInput))
			{
				OnThrust?.Invoke();
				Thrust();
			}
			if (Raylib.IsKeyDown((KeyboardKey)inputDevice.TurnRightInput))
			{
				Turn(1);
			}
			else if (Raylib.IsKeyDown((KeyboardKey)inputDevice.TurnLeftInput))
			{
				Turn(-1);
			}
		}

		private void CheckTerrainCollision() // Terrain collision check. Is ran every frame
		{
			// Check for a collision
			Vector2? edgePos = IsColliderInTerrain(position);
			if (edgePos != null)
			{
				// Get normal
				Vector2 normal = GetTerrainNormalAtPosition((int)edgePos.Value.X, (int)edgePos.Value.Y, 10);
				// Replace lastValidNormal only if a valid normal is found
				if (normal != Vector2.Zero)
				{
					lastValidNormal = normal;
				}
				// Use the last valid normal for sliding
				Slide(lastValidNormal);
				// Get best air position outside of terrain
				Vector2 bestPos = GetBestAir(position, previousPos, previousPos, 0, 4);
				// Update position and velocity for collision
				position = bestPos + velocity * Raylib.GetFrameTime();
			}
		}

		/// <summary>
		/// Returns a Vector2 normal from the terrain at the given position. If no valid normal is found, Returns Vector2.Zero
		/// </summary>
		/// <param name="x">position X</param>
		/// <param name="y">position Y</param>
		/// <param name="radius">search radius</param>
		/// <returns>Vector2 normal</returns>
		private Vector2 GetTerrainNormalAtPosition(int x, int y, int radius)
		{
			float xNormal = 0;
			float yNormal = 0;

			for (int xOffset = -radius; xOffset <= radius; xOffset++)
			{
				for (int yOffset = -radius; yOffset <= radius; yOffset++)
				{
					// Clam offsets to make sure they are not out-of-bounds
					int xClamped = Math.Clamp(x + xOffset, 0, currentMap.texture.Width - 1);
					int yClamped = Math.Clamp(y + yOffset, 0, currentMap.texture.Height - 1);

					if (Map.IsSameColor(currentMap.GetImageColor(new Vector2(xClamped, yClamped)), Material.Empty.Color, 0)) // empty space influences direction
					{
						xNormal += xOffset;
						yNormal += yOffset;
					}
				}
			}

			Vector2 normal = new Vector2(xNormal, yNormal);
			if (normal.LengthSquared() == 0)
				return Vector2.Zero;

			return Vector2.Normalize(normal);
		}

		/// <summary>
		/// Calculates the angle of impact between velocity and the given normal and changes direction of velocity to go along the wall (sliding), with perpendicular velocity removed.
		/// Also simulates friction to slow down when sliding along terrain.
		/// </summary>
		/// <param name="normal">collision normal</param>
		public void Slide(Vector2 normal)
		{
			float dot = Vector2.Dot(velocity, normal);
			if (dot < 0)
			{
				Vector2 perpendicular = normal * dot;
				Vector2 tangential = velocity - perpendicular;
				// How much the velocity is pointing into the surface normal. (used to scale friction)
				float angleFactor = -dot / velocity.Length();

				// Change direction of velocity and apply friction based on the angleFactor
				velocity = tangential * (1-FRICTION * angleFactor);
			}
		}

		/// <summary>
		/// Recursive function that does a binary search to find the closest non-terrain position to the collision.
		/// </summary>
		/// <param name="start">Start position of the vector</param>
		/// <param name="end">End position of the vector</param>
		/// <param name="bestAir">Best air</param>
		/// <param name="currentRecursion">Recursion count</param>
		/// <param name="maxRecursions">How many iterations the recursion will do</param>
		/// <returns></returns>
		private Vector2 GetBestAir(Vector2 start, Vector2 end, Vector2 bestAir, int currentRecursion, int maxRecursions)
		{
			currentRecursion++;
			if (currentRecursion >= maxRecursions)
			{
				return bestAir;
			}

			Vector2 line = start - end;
			Vector2 pos = start + line / 2;

			Vector2? edgePos = IsColliderInTerrain(pos);
			if (edgePos != null)
			{
				//hit
				//forget about previous half
				return GetBestAir(start, pos, bestAir, currentRecursion, maxRecursions);
			}
			else
			{
				//not hit
				//forget about previous half
				bestAir = pos;
				return GetBestAir(pos, end, bestAir, currentRecursion, maxRecursions);
			}
		}

		public void CheckBulletCollision(PoolingList<Bullet> bulletPool)
		{
			foreach (Bullet bullet in bulletPool.GetActiveList())
			{
				if (Raylib.CheckCollisionCircles(position, COLLIDER_RADIUS, bullet.position, bullet.radius))
				{
					// Bullet player collision
					TakeDamage(bullet.damage);
					velocity += bullet.velocity * 5f;
					bulletPool.SetActivity(bulletPool.GetIndex(bullet), false);
				}
			}
		}

		public void DrawPlayer()
		{
			Raylib.DrawCircleV(position, COLLIDER_RADIUS, Color.Red);
			Raylib.DrawTexturePro
			(
				texture,
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Rectangle(position, new Vector2(texture.Width, texture.Height)),
				new Vector2(texture.Width / 2, texture.Height / 2),
				rotation,
				Color.White
			);
		}

		private Vector2? IsColliderInTerrain(Vector2 position)
		{
			float angleSpacing = 5;
			for (float angle = 0; angle < 360; angle += angleSpacing)
			{
				Vector2 edgePos = position + new Vector2(MathF.Cos(angle * Raylib.DEG2RAD), MathF.Sin(angle * Raylib.DEG2RAD)) * COLLIDER_RADIUS;

				if (Map.IsSameColor(currentMap.GetImageColor(edgePos), Material.Terrain.Color, 0))
				{
					return edgePos;
				}
			}
			return null;
		}

		/// <summary>
		/// Calculate the position and scale of the splitscreen. fits splitscreens to the screen based on the preferred ratio, and number of splitscreens.
		/// </summary>
		/// <param name="preferredRatio"></param>
		/// <param name="splitscreenCount"></param>
		/// <param name="screenIndex"></param>
		public void CalculateSplitscreenSize(float preferredRatio, int splitscreenCount, int screenIndex)
		{
			int w = Raylib.GetScreenWidth();
			int h = Raylib.GetScreenHeight();
			float targetAspect = w / h / preferredRatio;
			int rows = (int)MathF.Round(MathF.Sqrt(splitscreenCount / targetAspect));
			int columns = (int)MathF.Ceiling((float)splitscreenCount / rows);
			int splitScreenWidth = w / columns;
			int splitScreenHeight = h / rows;
			int splitScreenX = screenIndex % columns * splitScreenWidth;
			int splitScreenY = (int)(MathF.Ceiling(screenIndex / columns) * splitScreenHeight);

			// Set variables
			screenCameraTexture = Raylib.LoadRenderTexture(splitScreenWidth, splitScreenHeight);
			splitScreenRect = new Rectangle(splitScreenX, splitScreenY, splitScreenWidth, -splitScreenHeight);
		}
	}
}
