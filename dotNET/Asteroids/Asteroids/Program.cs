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
			Ufo.InitTexture();
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
			Ufo.UpdateUfos();		
			Ufo.SpawnTimer(player.position);
			CollisionManager.CheckCollisions();
			AsteroidManager.CheckForNextWave(player.position);
        }

		void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();

			Bullet.DrawBullets();
			Ufo.DrawUfos();
			AsteroidManager.DrawAsteroids();
			Raylib.DrawText($"Points: {player.points}", 10, 5, 20, Color.White);
			Raylib.DrawText($"Lives: ", 10, 30, 20, Color.White); Raylib.DrawText($"{player.lives}", 70, 30, 20, Color.Red);
			if (player.isAlive)
			{
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