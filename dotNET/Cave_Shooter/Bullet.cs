using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class Bullet
	{
		public static float RADIUS = 10f;
		public static float SPEED = 10f;

		public Vector2 position;
		public Vector2 velocity;
		public float radius;
		public float damage;
		public int explosionRadius = 10;

		public Bullet(Vector2 position, Vector2 velocity)
		{
			this.position = position;
			this.velocity = velocity;
			damage = 10f;
		}

		public void Update()
		{
			position += velocity;
		}

		public void Draw()
		{
			Raylib.DrawCircleV(position, RADIUS, Color.White);
		}
	}
}
