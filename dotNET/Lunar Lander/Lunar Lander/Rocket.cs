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
		public Vector2 pos = new Vector2(100,100);
		public bool engineOn = true;
		Vector2 A = new Vector2(15, 0);
		Vector2 B = new Vector2(0, 40);
		Vector2 C = new Vector2(30, 40);
		public void Update()
		{
			
		}

		public void Draw()
		{
			Raylib.DrawTriangle(A, B, C, Color.White);
			if (engineOn)
			{
				Raylib.DrawTriangle(B, new Vector2(A.X, A.Y + 70), C, Color.Orange);
			}
		}
	}
}
