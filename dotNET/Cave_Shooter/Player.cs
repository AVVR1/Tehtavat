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
		private const float MAX_HEALTH = 100;

		private Weapon weapon;
		private IInput inputDevice;
		public static Texture2D texture;
		private Vector2 position;
		private float rotation;

		//physics variables
		float engineThrust;
		float maxSpeed;
		Vector2 acceleration;
		Vector2 direction;
		Vector2 velocity;

		public Player(Weapon weapon, IInput inputDevice) // Initialize player
		{
			this.weapon = weapon;
			this.inputDevice = inputDevice;
			maxHealth = MAX_HEALTH;
			health = MAX_HEALTH;
			//

			//Create player camera
		}

		public static void InitTexture()
		{
			texture = Raylib.LoadTexture("Images/Drawf.png");
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
			Console.WriteLine("Thrust");
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
		private void CalculatePhysics()
		{
			float deltaTime = Raylib.GetFrameTime();
			acceleration = Vector2.Zero;
			direction = Vector2.Transform(-Vector2.UnitY, Matrix3x2.CreateRotation(rotation * Raylib.DEG2RAD));

			acceleration += direction * engineThrust;

			velocity += acceleration * deltaTime;

			if (velocity.Length() >= maxSpeed)
			{
				velocity = Vector2.Normalize(velocity) * maxSpeed;
			}
			position += velocity * deltaTime;
		}

		public void Update()
		{
			CalculatePhysics();
			Input();
		}

		private void Input()
		{
			object input = Raylib.GetKeyPressed();
			Console.WriteLine(input);
			//TODO: run input functionality if Input matches inputdevice button
			if (Raylib.IsKeyPressed((KeyboardKey)inputDevice.ShootInput))
			{
				Shoot();
			}
			else if (input == inputDevice.ShootSpecialInput)
			{
				ShootSpecial();
			}
			else if (input == inputDevice.ThrustInput)
			{
				Thrust();
			}
			else if (input == inputDevice.TurnRightInput)
			{
				Turn(1);
			}
			else if (input == inputDevice.TurnLeftInput)
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
