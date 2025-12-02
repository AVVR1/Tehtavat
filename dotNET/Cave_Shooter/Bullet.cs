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
		public Vector2 position;
		public Vector2 velocity;
		private float radius;
		public int explosionRadius = 10;

		public Bullet(Vector2 position, Vector2 velocity)
		{
			this.position = position;
			this.velocity = velocity;
			radius = 10;
		}

		public void Update()
		{
			position += velocity;
		}

		public void Draw()
		{
			Raylib.DrawCircleV(position, radius, Color.White);
		}
	}
}
