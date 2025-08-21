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
		public static List<Ufo> ufoList = new List<Ufo>();
		public ColliderType colliderType { get; set; } = ColliderType.Circle;
		public static Texture2D ufoTexture;
		public object hitbox { get; set; } = 30f;
		float speed = 75f;

		//cooldowns
		static float shootCooldown = 3f;
		static float dirCooldown = 1.5f;

		static float spawnCooldown = 5f;

		//timers
		float shootTimer = shootCooldown;
		float dirTimer = dirCooldown;

		public static float spawnTimer = spawnCooldown;

		// Spawn area
		static float spawnProtectionRadius = 200f;
		static float maxDistance = 500f;

		public static void InitTexture()
		{
			ufoTexture = Raylib.LoadTexture("Images/ufoRed.png");
		}
		public Ufo(Vector2 position, Vector2 direction, float rotation)
		{
			this.position = position;
			this.direction = direction;
			texture = ufoTexture;
			ufoList.Add(this);
			CollisionManager.collidables.Add(this);
		}
		public void OnCollide(ICollidable collider)
		{
			ufoList.Remove(this);
			CollisionManager.collidables.Remove(this);
		}

		public void Update()
		{
			float deltaTime = Raylib.GetFrameTime();

			position += direction * speed * Raylib.GetFrameTime();

			shootTimer -= deltaTime;
			dirTimer -= deltaTime;

			if (shootTimer <= 0)
			{
				shootTimer = shootCooldown;
				Shoot();
			}
			if (dirTimer <= 0)
			{
				dirTimer = dirCooldown;
				ChangeDirection();
			}
		}

		public static void UpdateUfos()
		{
			for (int i = ufoList.Count - 1; i >= 0; i--)
			{
				ufoList[i].Update();
			}
		}

		public static void DrawUfos()
		{
			for (int i = ufoList.Count - 1; i >= 0; i--)
			{
				ufoList[i].Draw();
			}
		}

		public static void SpawnTimer(Vector2 playerPos)
		{
			spawnTimer -= Raylib.GetFrameTime();
			if (spawnTimer <= 0)
			{
				spawnTimer = spawnCooldown;
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
			//fix ufos shooting themself
			float randAngle = Class1.GetRandomAngle();
			Vector2 randDir = new Vector2(MathF.Cos(randAngle), MathF.Sin(randAngle));
			new Bullet(position + (randDir * ((float)hitbox + 15f)), randDir, randAngle * Raylib.RAD2DEG + 90, 250f);
			Console.WriteLine("SHOOT");
		}

		void ChangeDirection()
		{
			direction = Class1.GetRandomDirection();
		}
	}
}
