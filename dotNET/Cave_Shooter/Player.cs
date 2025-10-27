using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class Player : Damageable, IHealth, IPlayerInput
	{
		private const float MAX_HEALTH = 100;

		public KeyboardKey shootKey { get; private set; }

		private Weapon weapon;
		public static Texture2D texture;
		private Vector2 position;
		private float rotation;

		//physics variables
		float engineThrust;
		float maxSpeed;
		Vector2 acceleration;
		Vector2 direction;
		Vector2 velocity;

		public Player(Weapon weapon) // Initialize player
		{
			this.weapon = weapon;
			maxHealth = MAX_HEALTH;
			health = MAX_HEALTH;
			//Create player camera
		}

		public static void InitTexture()
		{
			texture = Raylib.LoadTexture("Images/Drawf.png");
		}

		private void Shoot()
		{
			//Shoot logic
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
			Console.WriteLine("UPDATE");
			CalculatePhysics();
		}

		public void Draw()
		{
			Raylib.DrawTexture(texture,(int)position.X,(int)position.Y,Color.White);
		}

		void IPlayerInput.Thrust()
		{
			throw new NotImplementedException();
		}

		void IPlayerInput.TurnRight()
		{
			throw new NotImplementedException();
		}

		void IPlayerInput.TurnLeft()
		{
			throw new NotImplementedException();
		}

		void IPlayerInput.Shoot()
		{
			Shoot();
		}

		void IPlayerInput.ShootSpecial()
		{
			throw new NotImplementedException();
		}
	}
}
