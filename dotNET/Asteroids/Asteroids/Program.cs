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
		Asteroid asteroid2 = new Asteroid(new Vector2(700, 500), new Vector2(-1, -1), 40);
		Asteroid asteroid3 = new Asteroid(new Vector2(800, 400), new Vector2(-1, -1), 40);
		Asteroid asteroid4 = new Asteroid(new Vector2(900, 300), new Vector2(-1, -1), 40);
		Asteroid asteroid5 = new Asteroid(new Vector2(1000, 200), new Vector2(-1, -1), 40);


		void Init()
		{
			Raylib.InitWindow(600, 600, "ASTEROIDS");
			player.texture = Raylib.LoadTexture("Images/playerShip2_blue.png");
			asteroid.LoadRandomTexture();
			asteroid2.LoadRandomTexture();
			asteroid3.LoadRandomTexture();
			asteroid4.LoadRandomTexture();
			asteroid5.LoadRandomTexture();
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
			Raylib.UnloadTexture(asteroid2.texture);
			Raylib.UnloadTexture(asteroid3.texture);
			Raylib.UnloadTexture(asteroid4.texture);
			Raylib.UnloadTexture(asteroid5.texture);
			Raylib.CloseWindow();
		}

		void Update()
		{
			player.Update();
			asteroid.Update();
			asteroid2.Update();
			asteroid3.Update();
			asteroid4.Update();
			asteroid5.Update();
			Input();
			CollisionManager.CheckCollisions();
		}

		void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();
			player.Draw();
			asteroid.Draw();
			asteroid2.Draw();
			asteroid3.Draw();
			asteroid4.Draw();
			asteroid5.Draw();

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
