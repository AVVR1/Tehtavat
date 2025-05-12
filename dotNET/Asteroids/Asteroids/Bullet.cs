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
		public object hitbox { get; set; } = 10f;
		public ColliderType colliderType { get; set; } = ColliderType.Circle;

		public Bullet(Vector2 position, Vector2 direction, float rotation)
		{
			texture = Raylib.LoadTexture("Images/laserBlue01.png");
			this.position = position;
			this.direction = direction;
			this.rotation = rotation;
			CollisionManager.collidables.Add(this);
			bullets.Add(this);
		}

		public void OnCollide()
		{
			CollisionManager.collidables.Remove(this);
			bullets.Remove(this);
		}

		public void Update()
		{
			position += direction * 1000 * Raylib.GetFrameTime();
			WarpToScreen();
		}

		public static void UpdateBullets()
		{
			foreach (Bullet bullet in bullets)
			{
				bullet.Update();
			}
		}

		public static void DrawBullets()
		{
			foreach (Bullet bullet in bullets)
			{
				bullet.Draw();
			}
		}
	}
}
