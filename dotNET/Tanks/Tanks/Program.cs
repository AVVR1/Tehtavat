using Raylib_cs;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Tanks
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Vector2 windowSize = new Vector2(1080, 720);

			Bullet bulletP1 = null;
			Bullet bulletP2 = null;

			Tank player1 = new Tank();
            Tank player2 = new Tank();

			player2.tankColor = Color.Red;
			player2.tankPos.X = windowSize.X - player2.tankSize.X - 10;

			Raylib.InitWindow((int)windowSize.X, (int)windowSize.Y, "TANKS");

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

				if (Raylib.IsKeyPressed(KeyboardKey.E) && (Raylib.GetTime() - player1.lastShootTime > 1.5f || bulletP1 == null))
				{
					bulletP1 = new Bullet();
					bulletP1.InitBullet(player1.tankPos, player1.tankDir, player1.tankSize);
					player1.lastShootTime = Raylib.GetTime();
				}
				if (Raylib.IsKeyPressed(KeyboardKey.PageUp) && (Raylib.GetTime() - player2.lastShootTime > 1.5f || bulletP1 == null))
				{
					bulletP2 = new Bullet();
					bulletP2.InitBullet(player2.tankPos, player2.tankDir, player2.tankSize);
					player2.lastShootTime = Raylib.GetTime();
				}

				if (bulletP1 != null)
				{
					bulletP1.UpdateBullet();
					if (Raylib.CheckCollisionPointRec(bulletP1.bulletPos, new Rectangle(player2.tankPos,player2.tankSize)))
					{
						Console.WriteLine("Player2 Got hit");
						bulletP1 = null;
					}
				}
				if (bulletP2 != null)
				{
					bulletP2.UpdateBullet();
					if (Raylib.CheckCollisionPointRec(bulletP2.bulletPos, new Rectangle(player1.tankPos, player1.tankSize)))
					{
						Console.WriteLine("Player1 Got hit");
						bulletP2 = null;
					}
				}


				player1.BoundsCheck(windowSize);
				player2.BoundsCheck(windowSize);
			}


			void DrawGame()
            {
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.White);
				if (bulletP1 != null)
				{
					bulletP1.DrawBullet();
				}
				if (bulletP2 != null)
				{
					bulletP2.DrawBullet();
				}
				player1.DrawTank();
				player2.DrawTank();
				Raylib.EndDrawing();
			}
		}
    }
}
