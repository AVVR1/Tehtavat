using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Raylib_cs;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Asteroids
{
	public class Movable
	{
		public Vector2 position = new Vector2();
		public Vector2 direction = new Vector2();
		public Texture2D texture;
		public float rotation = 0;

		public void Draw()
		{
			Class1.DrawTextureRotated(texture, position, rotation);
			Raylib.DrawLineV(position, position + direction * 200, Color.Red);
		}

		public void WarpToScreen()
		{
			int screenWidth = Raylib.GetScreenWidth();
			int screenHeight = Raylib.GetScreenHeight();
			int textureWidth = texture.Width;
			int textureHeight = texture.Height;

			if (position.X > screenWidth + textureWidth)
			{
				position.X = -textureWidth;
			}
			if (position.Y > screenHeight + textureHeight)
			{
				position.Y = -textureHeight;
			}
			if (position.X < -textureWidth)
			{
				position.X = screenWidth + textureWidth;
			}
			if (position.Y < -textureHeight)
			{
				position.Y = screenHeight + textureHeight;
			}
		}
	}
}