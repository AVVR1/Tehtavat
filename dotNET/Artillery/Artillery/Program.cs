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
		Cannon selectedCannon = p1Cannon;
		Bullet bullet = null;
		Terrain terrain = new Terrain(20);

		void Init()
		{
			Raylib.InitWindow(1000,700,"ARTILLERY");
			terrain.GenerateTerrain(60);
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
						if (bullet.position.X > Raylib.GetScreenWidth() + 7 || bullet.position.X < -7)
						{
							bullet = null;
							SwitchTurn();
						}
					}
					else if (Raylib.CheckCollisionPointRec(bullet.position, terrain.terrainPieces[(int)MathF.Floor(bullet.position.X/ terrain.terrainPieceWidth)]))
					{
						bullet = null;
						SwitchTurn();
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

			if (Raylib.IsKeyPressed(KeyboardKey.Space))
			{
				if (bullet == null)
				{
					bullet = new Bullet();
					bullet.Init(selectedCannon.position + selectedCannon.RotationToVector() * 47, selectedCannon.RotationToVector(), 500);
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
	}
}
