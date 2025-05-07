using Raylib_cs;
using System.Numerics;

namespace ClassLibrary1
{
	public class Class1
	{
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

		public static void DrawHitboxRotated(Vector2 position, Vector2 hitbox, float rotation, Color color)
		{
			Raylib.DrawRectanglePro
			(
				new Rectangle(position, hitbox),
				new Vector2(hitbox.X / 2, hitbox.Y / 2),
				rotation,
				color
			);
		}

		public static bool CheckCollisionCircleRecPro(Vector2 center, float radius, Rectangle rec, float rotation)
		{
			Vector2 newCenter = Vector2.Transform(center, Matrix3x2.CreateRotation(-rotation * Raylib.DEG2RAD, rec.Position));
			if (Raylib.CheckCollisionCircleRec(newCenter, radius, new Rectangle(rec.Position - rec.Size/2,rec.Size)))
			{
				return true;
			}
			return false;
		}
	}
}
