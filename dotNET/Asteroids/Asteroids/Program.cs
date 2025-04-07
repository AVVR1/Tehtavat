using Raylib_cs;

namespace Asteroids
{
	internal class Program
	{
		Texture2D playerShipTexture;
		static void Main(string[] args)
		{
			Program game = new Program();
			game.Init();
		}

		void Init()
		{
			Raylib.InitWindow(600, 600, "ASTEROIDS");
			playerShipTexture = Raylib.LoadTexture("Images/playerShip2_blue.png");
			//kaikki ladattu --> Gameloop
			GameLoop();
		}

		void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
				Draw();
			}
			Raylib.UnloadTexture(playerShipTexture);
			Raylib.CloseWindow();
		}

		void Draw()
		{
			Raylib.BeginDrawing();
			Raylib.DrawTexture(playerShipTexture, 10, 10, Color.White);
			Raylib.EndDrawing();
		}
	}
}
