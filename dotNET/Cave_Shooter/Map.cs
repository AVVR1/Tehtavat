using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	unsafe internal class Map
	{
		private Image image;
		public Texture2D texture;
		private Color* pixelDataPointer;

		public Map(string filename)
		{
			image = Raylib.LoadImage(filename);
			Raylib.ImageFormat(ref image, PixelFormat.UncompressedR8G8B8A8);
			texture = Raylib.LoadTextureFromImage(image);
		}

		unsafe public void UpdateTexture()
		{
			pixelDataPointer = Raylib.LoadImageColors(image);
			Raylib.UpdateTexture(texture, pixelDataPointer);
			Raylib.UnloadImageColors(pixelDataPointer);
		}

		unsafe public void MapDrawCircle(Vector2 position, int radius, Color color)
		{
			Raylib.ImageDrawCircleV(ref image, position, radius, color);
		}

		unsafe public void MapDrawRectangle(Rectangle rectangle, Color color)
		{
			Raylib.ImageDrawRectangleRec(ref image, rectangle, color);
		}

		unsafe public Color GetImageColor(Vector2 position)
		{
			if (position.X < 0 || position.X > image.Width || position.Y < 0 || position.Y > image.Height)
			{
				return Color.White;
			}
			return Raylib.GetImageColor(image, (int)position.X, (int)position.Y);
		}

		public void Draw()
		{
			Raylib.DrawTexture(texture, 0, 0, Color.White);
		}
	}
}
