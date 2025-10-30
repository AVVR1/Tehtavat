using Raylib_cs;
using System;
using System.Collections.Generic;
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
		private const float MAX_HEALTH = 100f;
		private const float ENGINE_POWER = 200f;

		private Weapon weapon;
		private IInput inputDevice;
		public static Texture2D texture;
		private Vector2 position = new Vector2(50, 50);
		private float rotation = 0f;

		//physics variables
		float engineThrust = 0f;
		float maxSpeed = 300f;
		Vector2 acceleration;
		Vector2 direction;
		Vector2 velocity;

		public Player(Weapon weapon, IInput inputDevice) // Initialize player
		{
			this.weapon = weapon;
			this.inputDevice = inputDevice;
			maxHealth = MAX_HEALTH;
			health = MAX_HEALTH;
			//Create player camera
		}

		public static void InitTexture()
		{
			Console.WriteLine("Texture");
			texture = Raylib.LoadTexture("Images/Drawf.png");
			Raylib.SetTextureFilter(texture, TextureFilter.Bilinear);
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
			Console.WriteLine($"Turn {amount}");
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
			CalculatePhysics();
			Input();
		}

		private void CalculatePhysics()
		{
			float deltaTime = Raylib.GetFrameTime();
			acceleration = Vector2.Zero;
			direction = Vector2.Transform(-Vector2.UnitY, Matrix3x2.CreateRotation(rotation * Raylib.DEG2RAD));

			acceleration += direction * (engineThrust + GRAVITY);

			velocity += acceleration * deltaTime;

			if (velocity.Length() >= maxSpeed)
			{
				velocity = Vector2.Normalize(velocity) * maxSpeed;
			}
			position += velocity * deltaTime;

			//Set engine thrust back to 0 to deactivate when not pressing thrust key.
			engineThrust = 0f;
		}

		private void Input()
		{
			//TODO: run input functionality if Input matches inputdevice button
			if (Raylib.IsKeyPressed((KeyboardKey)inputDevice.ShootInput))
			{
				Shoot();
			}
			else if (Raylib.IsKeyPressed((KeyboardKey)inputDevice.ShootSpecialInput))
			{
				ShootSpecial();
			}
			else if (Raylib.IsKeyDown((KeyboardKey)inputDevice.ThrustInput))
			{
				Thrust();
			}
			else if (Raylib.IsKeyDown((KeyboardKey)inputDevice.TurnRightInput))
			{
				Turn(1);
			}
			else if (Raylib.IsKeyDown((KeyboardKey)inputDevice.TurnLeftInput))
			{
				Turn(-1);
			}
		}

		public void Draw()
		{
			Raylib.DrawTexture(texture,(int)position.X,(int)position.Y,Color.White);
		}
	}
}
