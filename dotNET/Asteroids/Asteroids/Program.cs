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
			Class1.GetRandomAngle();
			Input();
			CollisionManager.CheckCollisions();
			AsteroidManager.CheckForNextWave(player.position);
		}

		void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();
			player.Draw();
			AsteroidManager.DrawAsteroids();
			Bullet.DrawBullets();
			Raylib.EndDrawing();
		}

		void Input()
		{
			if (Raylib.IsKeyDown(KeyboardKey.Right))
			{
				player.rotation += 300 * Raylib.GetFrameTime();
				player.rotation %= 360;
			}

			if (Raylib.IsKeyDown(KeyboardKey.Left))
			{
				player.rotation -= 300 * Raylib.GetFrameTime();
				player.rotation %= 360;
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
