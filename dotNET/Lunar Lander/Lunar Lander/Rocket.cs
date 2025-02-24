using System;
using Raylib_cs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lunar_Lander
{
	internal class Rocket
	{
		public Vector2 pos = new Vector2(475,0);
		public bool engineOn = false;
		Vector2 velocity = Vector2.Zero;
		float acceleration = 0;
		float speed = 0;

		float enginePower = 5000;

		Vector2 direction = new Vector2(0,1);

		Vector2 A = new Vector2(15, 0);
		Vector2 B = new Vector2(0, 40);
		Vector2 C = new Vector2(30, 40);
		public void Update()
		{
			float deltaTime = Raylib.GetFrameTime();

			if (Raylib.IsKeyDown(KeyboardKey.Space))
			{
				engineOn = true;
				velocity.Y -= enginePower * deltaTime;
			}
			if (Raylib.IsKeyReleased(KeyboardKey.Space))
			{
				engineOn = false;
			}

			acceleration += 9.8f * deltaTime * 10;
			velocity.Y = acceleration;

			pos.Y += velocity.Y * Raylib.GetFrameTime() + acceleration * (1/2 * acceleration * acceleration);
		}

		public void Draw()
		{
			Raylib.DrawTriangle(A + pos, B + pos, C + pos, Color.White);
			if (engineOn)
			{
				Raylib.DrawTriangle(B + pos + Vector2.UnitX * 5, new Vector2(A.X, A.Y + 70) + pos, C + pos - Vector2.UnitX*5, Color.Orange);
			}
		}
	}
}
