using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
	internal class Bullet
	{
		public Vector2 bulletPos;
		public Vector2 bulletDir;
		public Vector2 bulletSize = new Vector2(5,5);
		public float bulletSpeed = 1000f;

		public void FireBullet()
		{
			Raylib.DrawRectangleV(bulletPos - bulletSize / 2, bulletSize, Color.Black);
		}
	}
}