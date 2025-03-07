using Raylib_cs;
using System.Data;
using System.Numerics;

namespace Artillery
{
	internal class Program
	{
		static Cannon cannon = new Cannon();
		static Bullet bullet = null;
		static Terrain terrain = new Terrain();
		static void Main(string[] args)
		{
			Init();
			Update();
		}

		static void Init()
		{
			Raylib.InitWindow(1000,700,"ARTILLERY");
		}
		static void Update()
		{
			while (!Raylib.WindowShouldClose())
			{
				Input();
				cannon.Update();
				if (bullet != null)
				{
					bullet.Update();
				}
				Draw();
			}
			Raylib.CloseWindow();
		}

		static void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();
			cannon.Draw();
			terrain.Draw();
			if (bullet != null)
			{
				bullet.Draw();
			}
			Raylib.EndDrawing();
		}

		static void Input()
		{
			if (Raylib.IsKeyDown(KeyboardKey.Right))
			{
				if (cannon.IsCannonPastLimit(1))
				{
					cannon.cannonRotation += 60 * Raylib.GetFrameTime();
				}
			}

			if (Raylib.IsKeyDown(KeyboardKey.Left))
			{
				if (cannon.IsCannonPastLimit(-1))
				{
					cannon.cannonRotation -= 60 * Raylib.GetFrameTime();
				}
			}

			if (Raylib.IsKeyPressed(KeyboardKey.Space))
			{
				bullet = new Bullet();
                Console.WriteLine(cannon.cannonRotation);
				bullet.Init(cannon.cannonPos + cannon.RotationToVector() * 47, cannon.RotationToVector(), 500);
			}
		}
	}
}
