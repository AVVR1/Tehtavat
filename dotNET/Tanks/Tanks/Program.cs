﻿using Raylib_cs;
using System.ComponentModel.DataAnnotations;
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

			List<Rectangle> walls = new List<Rectangle>();
			walls.Add(new Rectangle(windowSize.X / 2 - 100, 0, new Vector2(200, 100)));
			walls.Add(new Rectangle(windowSize.X / 2 - 100, windowSize.Y / 2 - 100, new Vector2(200, 200)));
			walls.Add(new Rectangle(windowSize.X / 2 - 100, windowSize.Y - 100, new Vector2(200, 100)));

			player2.tankColor = Color.Red;
			player2.tankPos.X = windowSize.X - player2.tankSize.X - 10;

			double roundTime = 0;

			//float lenght = 0;

			Raylib.InitWindow((int)windowSize.X, (int)windowSize.Y, "TANKS");

			Rectangle collisionRec = new Rectangle(0, 0, 0, 0);

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
				//Shoot
				if (Raylib.IsKeyPressed(KeyboardKey.E) && (Raylib.GetTime() - player1.lastShootTime > 1.5f || bulletP1 == null))
				{
					bulletP1 = new Bullet();
					bulletP1.InitBullet(player1.tankPos, player1.tankDir, player1.tankSize);
					player1.lastShootTime = Raylib.GetTime();
				}
				if (Raylib.IsKeyPressed(KeyboardKey.PageUp) && (Raylib.GetTime() - player2.lastShootTime > 1.5f || bulletP2 == null))
				{
					bulletP2 = new Bullet();
					bulletP2.InitBullet(player2.tankPos, player2.tankDir, player2.tankSize);
					player2.lastShootTime = Raylib.GetTime();
				}

				if (bulletP1 != null)
				{
					bulletP1.UpdateBullet();
					if (Raylib.CheckCollisionPointRec(bulletP1.bulletPos, new Rectangle(player2.tankPos, player2.tankSize)))
					{
						player1.points++;
						player2.TriggerDeath();
						ResetGame();
					}
				}
				if (bulletP2 != null)
				{
					bulletP2.UpdateBullet();
					if (Raylib.CheckCollisionPointRec(bulletP2.bulletPos, new Rectangle(player1.tankPos, player1.tankSize)))
					{
						player2.points++;
						player1.TriggerDeath();
						ResetGame();
					}
				}

				player1.BoundsCheck(windowSize);
				player2.BoundsCheck(windowSize);

				foreach (var wall in walls)
				{
					if (Raylib.CheckCollisionRecs(wall, new Rectangle(player1.tankPos, player1.tankSize)))
					{
						collisionRec = Raylib.GetCollisionRec(new Rectangle(player1.tankPos, player1.tankSize), wall);
						if (collisionRec.Width < collisionRec.Height)
						{
							if (player1.tankPos.X < wall.Position.X)
							{
								player1.tankPos.X -= collisionRec.Width;
							}
							else
							{
								player1.tankPos.X += collisionRec.Width;
							}
						}
						else
						{
							if (player1.tankPos.Y < wall.Position.Y)
							{
								player1.tankPos.Y -= collisionRec.Height;
							}
							else
							{
								player1.tankPos.Y += collisionRec.Height;
							}
						}
					}
					if (Raylib.CheckCollisionRecs(wall, new Rectangle(player2.tankPos, player2.tankSize)))
					{
						//Vector2 vectorToWall = (wall.Position + wall.Size / 2) - (player2.tankPos + player2.tankSize / 2);
						//Vector2 normalizedVector = Vector2.Normalize(vectorToWall);
						collisionRec = Raylib.GetCollisionRec(new Rectangle(player2.tankPos, player2.tankSize), wall);
						if (collisionRec.Width < collisionRec.Height)
						{
							if (player2.tankPos.X < wall.Position.X)
							{
								player2.tankPos.X -= collisionRec.Width;
							}
							else
							{
								player2.tankPos.X += collisionRec.Width;
							}
						}
						else
						{
							if (player2.tankPos.Y < wall.Position.Y)
							{
								player2.tankPos.Y -= collisionRec.Height;
							}
							else
							{
								player2.tankPos.Y += collisionRec.Height;
							}
						}
						//lenght = (collisionRec.Width * MathF.Abs(normalizedVector.X) + collisionRec.Height * MathF.Abs(normalizedVector.Y))/2;
						//player2.tankPos = wall.Position + wall.Size / 2 - normalizedVector * lenght;
					}
					if (bulletP1 != null)
					{
						if (Raylib.CheckCollisionPointRec(bulletP1.bulletPos, wall))
						{
							bulletP1 = null;
						}
					}
					if (bulletP2 != null)
					{
						if (Raylib.CheckCollisionPointRec(bulletP2.bulletPos, wall))
						{
							bulletP2 = null;
						}
					}
				}

				if (Raylib.GetTime() - roundTime > 1)
				{
					player1.tankColor = Color.DarkBlue;
					player2.tankColor = Color.Red;
				}
			}

			void ResetGame()
			{
				player1.tankPos = new Vector2(10, 335);
				player2.tankPos = new Vector2(windowSize.X - player2.tankSize.X - 10, 335);
				bulletP1 = null;
				bulletP2 = null;
				roundTime = Raylib.GetTime();	
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
				foreach (var item in walls)
				{
					Raylib.DrawRectangleRec(item, Color.DarkGray);
					//Raylib.DrawLineV(item.Position + item.Size / 2, item.Position + item.Size /2 + Vector2.Normalize((item.Position + item.Size / 2) - (player2.tankPos + player2.tankSize / 2)) * lenght *-1, Color.Red);
				}
				Raylib.DrawText(player1.points.ToString(), (int)windowSize.X / 4 - 25, 10, 50, Color.Blue);
				Raylib.DrawText(player2.points.ToString(), (int)windowSize.X * 3 / 4 - 25, 10, 50, Color.Red);
				Raylib.EndDrawing();
			}
		}
	}
}
