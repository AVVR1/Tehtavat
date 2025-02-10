using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
	internal class Tank
	{
		public Vector2 tankSize = new Vector2(50, 50);
		public Vector2 tankPos = new Vector2(10, 335);
		public Vector2 tankDir = new Vector2(0, -1);
		public Color tankColor = Color.DarkBlue;
		public float tankSpeed = 200;
		public double lastShootTime;
		public void DrawTank()
		{
			Raylib.DrawRectangleV(tankPos, tankSize, tankColor);
			Raylib.DrawRectangleV(new Vector2(tankPos.X + tankSize.X / 2 - tankDir.Y * 5 - tankDir.X * 5, tankPos.Y + tankSize.Y / 2 - tankDir.X * 5 - tankDir.Y * 5), new Vector2(tankDir.Y * 10 + tankDir.X * 40, tankDir.X * 10 + tankDir.Y * 40), tankColor);
		}

		public void BoundsCheck(Vector2 windowSize)
		{
			if (tankPos.X < 0)
			{
				tankPos.X = 0;
			}
			if (tankPos.X > windowSize.X - tankSize.X)
			{
				tankPos.X = windowSize.X - tankSize.X;
			}
			if (tankPos.Y < 0)
			{
				tankPos.Y = 0;
			}
			if (tankPos.Y > windowSize.Y - tankSize.Y)
			{
				tankPos.Y = windowSize.Y - tankSize.Y;
			}
		}
	}
}
