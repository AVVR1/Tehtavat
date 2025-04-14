using ClassLibrary1;
using Raylib_cs;
using System.Numerics;

namespace Asteroids
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Program game = new Program();
			game.Init();
		}

		Player player = new Player();

		void Init()
		{
			Raylib.InitWindow(600, 600, "ASTEROIDS");
			player.shipTexture = Raylib.LoadTexture("Images/playerShip2_blue.png");
			//kaikki ladattu --> Gameloop
			GameLoop();
		}

		void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
				player.Update();
				Draw();
				Input();
			}
			Raylib.UnloadTexture(player.shipTexture);
			Raylib.CloseWindow();
		}

		void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();
			player.Draw();
			Raylib.EndDrawing();
		}

		void Input()
		{
			if (Raylib.IsKeyDown(KeyboardKey.Right))
			{
				player.rotation += 300 * Raylib.GetFrameTime();
			}

			if (Raylib.IsKeyDown(KeyboardKey.Left))
			{
				player.rotation -= 300 * Raylib.GetFrameTime();
			}

			if (Raylib.IsKeyDown(KeyboardKey.Up))
			{
				player.engineOn = true;
			} 
			else
			{
				player.engineOn = false;
			}
		}
	}
}
