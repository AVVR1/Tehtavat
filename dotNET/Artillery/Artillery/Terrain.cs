using Raylib_cs;
using System.Numerics;

namespace Artillery
{
	internal class Terrain
	{
		public void Draw()
		{
			Raylib.DrawRectangle(0, 500, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), Color.DarkGreen);
		}
	}
}
