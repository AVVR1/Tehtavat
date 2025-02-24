using Raylib_cs;
using System.Net.Sockets;
using System.Security.Authentication;

namespace Lunar_Lander
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Program game = new Program();
			game.Init();
			game.GameLoop();
		}
		Rocket rocket = new Rocket();
		Rectangle landingPlatform = new Rectangle(Raylib.GetScreenWidth() / 2 - 50, Raylib.GetScreenHeight() - 50, 100, 10);
		void Init()
		{
			Raylib.InitWindow(960, 540, "Lunar lander");
		}
		void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
				rocket.Update();
				Update();
				Draw();
			}
		}

		void Update()
		{

		}

		void Draw()
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			Raylib.DrawRectangleRec(landingPlatform, Color.LightGray);
			rocket.Draw();
			Raylib.EndDrawing();
		}
	}
}
