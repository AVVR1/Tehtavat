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
		Color cannonColor = Color.DarkBlue;

		public float cannonRotation = 0;
		public float cannonMaxAngle = 75; 
		public Vector2 cannonPos = new Vector2(200,500);
		public void Update()
		{
			cannonRec.Position = cannonPos;
		}
		public void Draw()
		{
			Raylib.DrawCircleV(cannonPos, 20, cannonColor);
			Raylib.DrawRectanglePro(cannonRec, new Vector2(cannonRec.Size.X / 2,cannonRec.Size.Y), cannonRotation, cannonColor);
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
