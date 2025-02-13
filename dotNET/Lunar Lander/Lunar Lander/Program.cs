using Raylib_cs;
using System.Security.Authentication;

namespace Lunar_Lander
{
	internal class Program
	{
		static void Main(string[] args) 
		{
			Rocket rocket = new Rocket();

			Raylib.InitWindow(960, 540, "Lunar lander");
			Rectangle landingPlatform = new Rectangle(Raylib.GetScreenWidth() / 2 - 50, Raylib.GetScreenHeight() - 50, 100, 10);
			while (!Raylib.WindowShouldClose())
			{
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.Black);
				Raylib.DrawRectangleRec(landingPlatform, Color.LightGray);
				rocket.Draw();

				Raylib.EndDrawing();
			}
		}
	}
}
