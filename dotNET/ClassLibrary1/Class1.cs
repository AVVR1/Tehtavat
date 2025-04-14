using Raylib_cs;
using System.Numerics;

namespace ClassLibrary1
{
	public class Class1
	{
		public static void DrawTextureRotated(Texture2D texture, Vector2 position, Vector2 origin, float rotation)
		{
			Raylib.DrawTexturePro
			(
				texture, 
				new Rectangle(0, 0, texture.Width, texture.Height), 
				new Rectangle(position, new Vector2(texture.Width, texture.Height)), 
				origin, 
				rotation,
				Color.White
			);
		}

		public static void DrawTextureRotated(Texture2D texture, Vector2 position, float rotation)
		{
			Raylib.DrawTexturePro
			(
				texture,
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Rectangle(position, new Vector2(texture.Width, texture.Height)),
				new Vector2(texture.Width / 2, texture.Height / 2),
				rotation,
				Color.White
			);
		}
	}
}
