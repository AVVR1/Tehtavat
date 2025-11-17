using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZeroElectric.Vinculum.Extensions;

namespace Cave_Shooter
{
	internal class Player : Damageable, IHealth
	{
		private const float GRAVITY = -9.81f;
		private const float GRAVITY_MULT = 5f;
		private const float MAX_HEALTH = 100f;
		private const float ENGINE_POWER = 200f;
		private const float TURN_POWER = 300f;

		public static Texture2D texture;

		// Camera
		public Camera2D camera;
		public RenderTexture2D screenCameraTexture;
		public Rectangle splitScreenRect; // splitScreen position and Size.

		// Transform
		private Vector2 position = new Vector2(200, 200);
		private float rotation = 0f;

		private IInput inputDevice;
		private Weapon weapon;

		// Physics variables
		private float engineThrust = 0f;
		private float maxSpeed = 300f;
		private Vector2 acceleration;
		private Vector2 direction;
		private Vector2 velocity;

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

		public void CalculateSplitscreenSize(float preferredRatio, int playerCount, int playerIndex)
		{
			int w = Raylib.GetScreenWidth();
			int h = Raylib.GetScreenHeight();
			float targetAspect = w / h / preferredRatio;
			int rows = (int)MathF.Round(MathF.Sqrt(playerCount / targetAspect));
			int columns = (int)MathF.Ceiling((float)playerCount / rows);
			int splitScreenWidth = w / columns;
			int splitScreenHeight = h / rows;
			int splitScreenX = playerIndex % columns * splitScreenWidth;
			int splitScreenY = (int)(MathF.Ceiling(playerIndex / columns) * splitScreenHeight);

			// Set variables
			screenCameraTexture = Raylib.LoadRenderTexture(splitScreenWidth, splitScreenHeight);
			splitScreenRect = new Rectangle(splitScreenX, splitScreenY, splitScreenWidth, -splitScreenHeight);
		}

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
			Console.WriteLine("Player should Die");
		}

		public void OnHurt()
		{
			Console.WriteLine("Player got hurt");
		}

		public void Update()
		{
			camera.Target = position;
			CalculatePhysics();
			Input();

		}

		private void CalculatePhysics()
		{
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
				Shoot();
			}
			if (Raylib.IsKeyPressed((KeyboardKey)inputDevice.ShootSpecialInput))
			{
				ShootSpecial();
			}
			if (Raylib.IsKeyDown((KeyboardKey)inputDevice.ThrustInput))
			{
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

		private void CalculateCollision()
		{
			// if player collides with terrain
				//Get terrain normal
				//Change player direction, prevent going through
		}
		public void Collision(Vector2 normal)
		{
			float dot = Vector2.Dot(velocity, normal);
			if (dot < 0)
			{
				velocity -= dot * normal;
			}
		}

		public void DrawPlayer()
		{
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
	}
}
