using ClassLibrary1;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	internal class Ufo : Movable, ICollidable
	{
		public static List<Ufo> ufos = new List<Ufo>();
		public ColliderType colliderType { get; set; } = ColliderType.Circle;
		public static Texture2D ufoTexture;
		public object hitbox { get; set; } = 50f;
		float speed = 50f;

		//timers
		static float timer = 0f;
		float shootCooldown = 3f;
		float dirCooldown = 2.5f;

		// Spawn area
		static float spawnProtectionRadius = 200f;
		static float maxDistance = 500f;

		public static void InitTexture()
		{
			ufoTexture = Raylib.LoadTexture("Images/ufo.png");
		}
		public Ufo(Vector2 position, Vector2 direction, float rotation)
		{
			this.position = position;
			this.direction = direction;
			texture = ufoTexture;
			ufos.Add(this);
			CollisionManager.collidables.Add(this);
		}
		public void OnCollide(ICollidable collider)
		{
			ufos.Remove(this);
			CollisionManager.collidables.Remove(this);
		}

		public void Update()
		{
			position += direction * speed * Raylib.GetFrameTime();
			
			if (dirCooldown > 0f)
			{
				dirCooldown -= Raylib.GetFrameTime();
			}
			else if (timer % 2.5f < 0.1f)
			{
				direction = Class1.GetRandomDirection();
                Console.WriteLine("direction");
				dirCooldown = 2.5f;
			}
			if (shootCooldown > 0f)
			{
				shootCooldown -= Raylib.GetFrameTime();
			}
			else if (timer % 3f < 0.1f)
			{
				Console.WriteLine("Shoot");
				shootCooldown = 3f;
			}
		}

		public static void UpdateUfos()
		{
			foreach (Ufo ufo in ufos)
			{
				ufo.Update();
			}
		}

		public static void UfoTimer(Vector2 playerPos)
		{
			timer += Raylib.GetFrameTime();
			if (timer % 30f < 0.01f)
			{
				new Ufo(GetSpawnPosition(playerPos), Class1.GetRandomDirection(), 0);
			}

		}
		static Vector2 GetSpawnPosition(Vector2 playerPos)
		{
			Vector2 direction = Class1.GetRandomDirection();
			float distance = Class1.GetRandomValueBetween(spawnProtectionRadius, maxDistance, new Random());
			return direction * distance + playerPos;
		}

		void Shoot()
		{
			float randAngle = Class1.GetRandomAngle();
			Vector2 randDir = new Vector2(MathF.Cos(randAngle), MathF.Sin(randAngle));
			new Bullet(position, randDir, randAngle);
		}
	}
}
