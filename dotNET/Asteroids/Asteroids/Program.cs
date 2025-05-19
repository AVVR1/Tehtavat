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
			Raylib.InitWindow(800, 600, "ASTEROIDS");
			Start();
			//kaikki ladattu --> Gameloop
			GameLoop();
		}

		void Start()
		{
			AsteroidManager.InitTextures();
			Bullet.InitTexture();
			player.texture = Raylib.LoadTexture("Images/playerShip2_blue.png");
        }

		void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
                Update();
                Draw();
			}
			Raylib.UnloadTexture(player.texture);
			AsteroidManager.UnloadTextures();
			Raylib.CloseWindow();
		}

		void Update()
		{
			player.Update();
			AsteroidManager.UpdateAsteroids();
			Bullet.UpdateBullets();
			CollisionManager.CheckCollisions();
			AsteroidManager.CheckForNextWave(player.position);
        }

		void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();

			Bullet.DrawBullets();
			AsteroidManager.DrawAsteroids();
			if (player.isAlive)
			{
				Raylib.DrawText($"Lives: {player.lives}", 10, 5, 20, Color.White);
				if (player.drawTexture)
				{
					player.Draw();
				}
			}
			else
            {
                Raylib.DrawText("GAME OVER", 250, 275, 50, Color.Red);
            }

			Raylib.EndDrawing();
        }
	}
}
