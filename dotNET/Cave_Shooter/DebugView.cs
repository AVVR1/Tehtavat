using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class DebugView
	{
		public Camera2D camera;
		public RenderTexture2D screenCameraTexture;
		public Rectangle splitScreenRect; // splitScreen position and Size.

		public DebugView()
		{
			camera = new Camera2D();
			camera.Offset = new Vector2(1000,10);
			camera.Target = Vector2.Zero;
			camera.Zoom = 1;
			//camera.Offset = -new Vector2(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2);
		}

		public void CalculateSplitscreenSize(float preferredRatio, int playerCount, int playerIndex)
		{
			int w = Raylib.GetScreenWidth();
			int h = Raylib.GetScreenHeight();
			float targetAspect = w / h / preferredRatio;
			int rows = (int)MathF.Round(MathF.Sqrt(playerCount / targetAspect));
			int columns = (int)MathF.Ceiling((float)playerCount / rows);
			int splitScreenWidth = w / columns;
			int splitScreenHeight = h / rows;
			int splitScreenX = playerIndex % columns * splitScreenWidth;
			int splitScreenY = (int)(MathF.Ceiling(playerIndex / columns) * splitScreenHeight);

			// Set variables
			screenCameraTexture = Raylib.LoadRenderTexture(splitScreenWidth, splitScreenHeight);
			splitScreenRect = new Rectangle(splitScreenX, splitScreenY, splitScreenWidth, -splitScreenHeight);
		}

		public void UpdateDebug(Vector2 target)
		{
			camera.Target = target;
		}

		public void DrawDebugUI()
		{
			DrawX(splitScreenRect.Position + new Vector2(1,-1) * splitScreenRect.Size/2, Vector2.One*5);
		}

		public void DrawX(Vector2 position, Vector2 size)
		{
			Raylib.DrawLineEx(position-size, position + size, 2f, Color.Red);
			Raylib.DrawLineEx(position + new Vector2(-1, 1) * size, position - new Vector2(-1, 1) * size, 2f, Color.Red);
		}
	}
}