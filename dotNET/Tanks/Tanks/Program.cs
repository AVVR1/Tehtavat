using Raylib_cs;
using System.Numerics;

namespace Tanks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tank player1 = new Tank();
            Tank player2 = new Tank();

			player2.tankColor = Color.Red;
			player2.tankPos.X = 660;

			Bullet currentbullet;

			Raylib.InitWindow(720, 400, "TANKS");

			while (!Raylib.WindowShouldClose())
            {
                UpdateGame();
                DrawGame();
			}
            Raylib.CloseWindow();

            void UpdateGame()
            {
				//Player 1 movement
                if (Raylib.IsKeyDown(KeyboardKey.W))
                {
                    player1.tankDir = new Vector2(0, -1);
                    player1.tankPos += player1.tankDir * player1.tankSpeed * Raylib.GetFrameTime();
                }
                if (Raylib.IsKeyDown(KeyboardKey.S))
                {
                    player1.tankDir = new Vector2(0, 1);
					player1.tankPos += player1.tankDir * player1.tankSpeed * Raylib.GetFrameTime();
				}
				if (Raylib.IsKeyDown(KeyboardKey.A))
				{
					player1.tankDir = new Vector2(-1, 0);
					player1.tankPos += player1.tankDir * player1.tankSpeed * Raylib.GetFrameTime();
				}
				if (Raylib.IsKeyDown(KeyboardKey.D))
				{
					player1.tankDir = new Vector2(1, 0);
					player1.tankPos += player1.tankDir * player1.tankSpeed * Raylib.GetFrameTime();
				}
				//Player 2 movement
				if (Raylib.IsKeyDown(KeyboardKey.Up))
				{
					player2.tankDir = new Vector2(0, -1);
					player2.tankPos += player2.tankDir * player2.tankSpeed * Raylib.GetFrameTime();
				}
				if (Raylib.IsKeyDown(KeyboardKey.Down))
				{
					player2.tankDir = new Vector2(0, 1);
					player2.tankPos += player2.tankDir * player2.tankSpeed * Raylib.GetFrameTime();
				}
				if (Raylib.IsKeyDown(KeyboardKey.Left))
				{
					player2.tankDir = new Vector2(-1, 0);
					player2.tankPos += player2.tankDir * player2.tankSpeed * Raylib.GetFrameTime();
				}
				if (Raylib.IsKeyDown(KeyboardKey.Right))
				{
					player2.tankDir = new Vector2(1, 0);
					player2.tankPos += player2.tankDir * player2.tankSpeed * Raylib.GetFrameTime();
				}

				if (Raylib.IsKeyPressed(KeyboardKey.E))
				{
					Bullet bullet1 = new Bullet();
					bullet1.bulletPos = player1.tankPos * 2;
					bullet1.bulletDir = player1.tankDir;
					bullet1.FireBullet();
				}

				if (Raylib.IsKeyPressed(KeyboardKey.PageUp))
				{

					Bullet bullet2 = new Bullet();
				}
			}

            void DrawGame()
            {
				Raylib.BeginDrawing();
				//Raylib.ClearBackground(Color.White);
				player1.DrawTank();
				player2.DrawTank();
				Raylib.EndDrawing();
			}
		}
    }
}
