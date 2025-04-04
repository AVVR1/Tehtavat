using Raylib_cs;
using System.Data;
using System.Numerics;

namespace Artillery
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Program game = new Program();
			game.Init();
			game.Update();
		}

		static Cannon p1Cannon = new Cannon(new Vector2(200,500),Color.DarkBlue);
		static Cannon p2Cannon = new Cannon(new Vector2(800,500), Color.Red);
		List<Bullet> bullets = new List<Bullet>();
		Cannon selectedCannon = p1Cannon;
		Bullet bullet = null;
		Terrain terrain = new Terrain(20);
		float force = 50;
		int selectedBulletIndex = 0;

		void Init()
		{
			Raylib.InitWindow(1000,700,"ARTILLERY");
			terrain.GenerateTerrain(60);
			Rectangle p1SpawnRectangle = GetTerrainRect(p1Cannon.position.X);
			Rectangle p2SpawnRectangle = GetTerrainRect(p2Cannon.position.X);
			p1Cannon.position = new Vector2(p1SpawnRectangle.Width / 2 + p1SpawnRectangle.Position.X, p1SpawnRectangle.Position.Y);
			p2Cannon.position = new Vector2(p2SpawnRectangle.Width / 2 + p2SpawnRectangle.Position.X, p2SpawnRectangle.Position.Y);
			bullets.Add(Bullet.JsonToBullet("Missile.json"));
			bullets.Add(Bullet.JsonToBullet("Bomb.json"));
		}
		void Update()
		{
			while (!Raylib.WindowShouldClose())
			{
				Input();
				p1Cannon.Update();
				p2Cannon.Update();
				if (bullet != null)
				{
					bullet.Update();
					if (bullet.position.X >= Raylib.GetScreenWidth() || bullet.position.X < 0)
					{
						if (bullet.position.X > Raylib.GetScreenWidth() + bullet.size || bullet.position.X < -bullet.size)
						{
							bullet = null;
							SwitchTurn();
						}
					}
					else if (Raylib.CheckCollisionPointRec(bullet.position, GetTerrainRect(bullet.position.X)))
					{
						SwitchTurn();
						if (Raylib.CheckCollisionCircles(selectedCannon.position, 20, bullet.position, bullet.size + bullet.explosionForce))
						{
							//hit player
						}
						bullet = null;
					}
				}
				Draw();
			}
			Raylib.CloseWindow();
		}

		void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();
			p1Cannon.Draw();
			p2Cannon.Draw();
			terrain.Draw();
			Raylib.DrawRectangle(0, 0, 10, (int)force / 10, Color.Red);
			Raylib.DrawText(bullets[selectedBulletIndex].name, Raylib.GetScreenWidth()/2 - (bullets[selectedBulletIndex].name.Length * 3), 10, 20, Color.White);
			if (bullet != null)
			{
				bullet.Draw();
			}
			Raylib.EndDrawing();
		}

		void Input()
		{
			if (Raylib.IsKeyDown(KeyboardKey.Right))
			{
				if (selectedCannon.IsCannonPastLimit(1))
				{
					selectedCannon.cannonRotation += 60 * Raylib.GetFrameTime();
				}
			}

			if (Raylib.IsKeyDown(KeyboardKey.Left))
			{
				if (selectedCannon.IsCannonPastLimit(-1))
				{
					selectedCannon.cannonRotation -= 60 * Raylib.GetFrameTime();
				}
			}

			if (Raylib.IsKeyPressed(KeyboardKey.Q))
			{
				selectedBulletIndex -= 1;
				if (selectedBulletIndex < 0)
				{
					selectedBulletIndex = bullets.Count - 1;
				}
			}

			if (Raylib.IsKeyPressed(KeyboardKey.E))
			{
				selectedBulletIndex += 1;
				if (selectedBulletIndex >= bullets.Count)
				{
					selectedBulletIndex = 0;
				}
			}

			double startTime = Raylib.GetTime();
			if (Raylib.IsKeyDown(KeyboardKey.Space))
			{
				if (force <= 750)
				{
					force += Raylib.GetFrameTime() * 500;
				}
			}
			if (Raylib.IsKeyReleased(KeyboardKey.Space))
			{
				if (bullet == null)
				{
					bullet = new Bullet(bullets[selectedBulletIndex]);
					bullet.Init(selectedCannon.position + selectedCannon.RotationToVector() * (40 + bullets[selectedBulletIndex].size), selectedCannon.RotationToVector(), force);
					force = 50;
				}
			}
		}

		void SwitchTurn()
		{
			if (selectedCannon == p1Cannon)
			{
				selectedCannon = p2Cannon;
			}
			else
			{
				selectedCannon = p1Cannon;
			}
		}

		Rectangle GetTerrainRect(float x)
		{
			return terrain.terrainPieces[(int)MathF.Floor(x / terrain.terrainPieceWidth)];
		}
	}
}
