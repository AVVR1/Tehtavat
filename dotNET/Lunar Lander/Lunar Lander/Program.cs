using Raylib_cs;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Authentication;

namespace Lunar_Lander
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Program game = new Program();
			game.Init();
			game.GameLoop();
		}
		Rocket rocket = new Rocket();
		Rectangle landingPlatform;
		void Init()
		{
			Raylib.InitWindow(960, 540, "Lunar lander");
			landingPlatform = new Rectangle(Raylib.GetScreenWidth() / 2 - 50, Raylib.GetScreenHeight() - 50, 100, 10);
		}
		void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
				Update();
				Draw();
			}
		}

		void Update()
		{
			rocket.Update();
			//Raylib.DrawText(rocket.velocity.ToString(), 10, 40, 16, Color.White);
			

			if (Raylib.CheckCollisionPointRec(rocket.pos + new Vector2(15, 40), landingPlatform))
			{
				rocket.pos.Y = landingPlatform.Y - 40;
				if (rocket.velocity.Y < 50)
				{
					rocket.velocity = Vector2.Zero;
					Raylib.DrawText("YOU WIN", Raylib.GetScreenWidth()/2 - 100, Raylib.GetScreenHeight()/2 - 24 ,48, Color.White);
					return;
				}
				else
				{
					Raylib.DrawText("YOU LOSE", Raylib.GetScreenWidth() / 2 - 125, Raylib.GetScreenHeight() / 2 - 24, 48, Color.White);
				}
				
			}
		}

		void Draw()
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			Raylib.DrawRectangleRec(landingPlatform, Color.LightGray);
			Raylib.DrawRectangleV(new Vector2(5, 5), new Vector2(260, 30), Color.Gray);
			Raylib.DrawRectangleV(new Vector2(8, 7), new Vector2(254, 26), Color.Black);
			Raylib.DrawRectangleV(new Vector2(10, 10), new Vector2(rocket.fuel / 2, 20), Color.Orange);
			Raylib.DrawText(((int)rocket.fuel).ToString(), 12, 13, 16, Color.White);
			rocket.Draw();
			//Raylib.DrawLineV(new Vector2(Raylib.GetRenderWidth() / 2, 0), new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight()),Color.Red);
			Raylib.EndDrawing();
		}
	}
}
