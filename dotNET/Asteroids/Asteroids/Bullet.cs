using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	class Bullet : Movable, ICollidable
	{
		public static List<Bullet> bullets = new List<Bullet>();
		public static Texture2D bulletTexture;
		public object hitbox { get; set; } = 10f;
		float speed = 500f;
		public ColliderType colliderType { get; set; } = ColliderType.Circle;
		static Player? player;

		float timer = 0f;
		float maxLifetime = 1f;

		public Bullet(Vector2 position, Vector2 direction, float rotation, float speed)
		{
			texture = bulletTexture;
			this.position = position;
			this.direction = direction;
			this.rotation = rotation;
			this.speed = speed;
			CollisionManager.collidables.Add(this);
			bullets.Add(this);
		}

		public static void InitTexture()
		{
			bulletTexture = Raylib.LoadTexture("Images/laserBlue01.png");
		}

		public void OnCollide(ICollidable collider)
		{
			Remove();
			player.AddPoints(collider);
		}

		public void Update()
		{
			timer += Raylib.GetFrameTime();
			position += direction * speed * Raylib.GetFrameTime();
			WarpToScreen();
			if (timer >= maxLifetime)
			{
				Remove();
			}
		}
		 
		void Remove()
		{
			CollisionManager.collidables.Remove(this);
			bullets.Remove(this);
		}

		public static void SetPlayer(Player player)
		{
			Bullet.player = player;
		}

		public static void UpdateBullets()
		{
			for (int i = bullets.Count - 1; i >= 0; i--)
			{
				bullets[i].Update();
			}
		}
		public static void DrawBullets()
		{
			for (int i = bullets.Count - 1; i >= 0; i--)
			{
				bullets[i].Draw();
			}
		}
	}
}
