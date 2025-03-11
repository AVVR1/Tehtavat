using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Artillery
{
	internal class Bullet
	{
		public Vector2 position;
		Vector2 bulletDir = new Vector2(0,0);
		//public float bulletSpeed;

		Vector2 gravity = new Vector2(0,9.8f);
		Vector2 velocity;
		Vector2 acceleration;

		
		public void Update()
		{
			float deltaTime = Raylib.GetFrameTime();
			acceleration = Vector2.Zero;

			acceleration += gravity * 30;

			velocity += acceleration * deltaTime;
			position += velocity * deltaTime;
		}

		public void Init(Vector2 startPos, Vector2 startDir, float speed)
		{
			position = startPos;
			bulletDir = startDir;
			velocity = startDir * speed;
			velocity = startDir * speed;
		}

		public void Draw()
		{
			Raylib.DrawCircleV(position, 7, Color.White);
		}
	}
}
