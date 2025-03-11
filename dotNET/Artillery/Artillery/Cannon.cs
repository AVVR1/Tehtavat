using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Artillery
{
	internal class Cannon
	{
		Rectangle cannonRec = new Rectangle(0, 0, 10, 40);
		public float cannonRotation = 0;
		public float cannonMaxAngle = 75;

		public Vector2 position;

		public Color color;

		public Cannon(Vector2 position, Color color)
		{
			this.color = color;
			this.position = position;
		}
		public void Update()
		{
			cannonRec.Position = position;
		}
		public void Draw()
		{
			Raylib.DrawCircleV(position, 20, color);
			Raylib.DrawRectanglePro(cannonRec, new Vector2(cannonRec.Size.X / 2,cannonRec.Size.Y), cannonRotation, color);
		}

		public bool IsCannonPastLimit(int prefix)
		{
			if (prefix * cannonRotation < cannonMaxAngle)
			{
				return true;
			}
			return false;
		}

		public Vector2 RotationToVector()
		{
			Vector2 rotation = new Vector2(MathF.Cos((cannonRotation - 90) * Raylib.DEG2RAD), MathF.Sin((cannonRotation - 90) * Raylib.DEG2RAD));
			return rotation;
		}
	}
}
