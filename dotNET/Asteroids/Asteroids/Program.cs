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
		Asteroid asteroid = new Asteroid(new Vector2(600, 600), new Vector2(-1, -1), 10f, Asteroid.AsteroidSize.Big);


		void Init()
		{
			Raylib.InitWindow(600, 600, "ASTEROIDS");
			player.texture = Raylib.LoadTexture("Images/playerShip2_blue.png");
			//kaikki ladattu --> Gameloop
			GameLoop();
		}

		void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
				Update();
				Draw();
			}
			Raylib.UnloadTexture(player.texture);
			Raylib.UnloadTexture(asteroid.texture);
			Raylib.CloseWindow();
		}

		void Update()
		{
			player.Update();
			asteroid.Update();
			Class1.GetRandomAngle();
			Input();
			CollisionManager.CheckCollisions();
		}

		void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();
			player.Draw();
			asteroid.Draw();

			//Class1.DrawHitboxRotated(player.position, (Vector2)player.hitbox, player.rotation, Color.Red);
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
