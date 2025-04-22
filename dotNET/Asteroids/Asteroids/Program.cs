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
		Asteroid asteroid = new Asteroid(new Vector2(600,600), new Vector2(-1,-1),40);

		void Init()
		{
			Raylib.InitWindow(600, 600, "ASTEROIDS");
			player.texture = Raylib.LoadTexture("Images/playerShip2_blue.png");
			asteroid.LoadRandomTexture();
			//kaikki ladattu --> Gameloop
			GameLoop();
		}

		void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
				player.Update();
				asteroid.Update();
				Draw();
				Input();
			}
			Raylib.UnloadTexture(player.texture);
			Raylib.UnloadTexture(asteroid.texture);
			Raylib.CloseWindow();
		}

		void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();
			player.Draw();
			asteroid.Draw();
			Raylib.DrawRectangleV(player.position, player.PLAYER_HITBOX, Color.Red);
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
