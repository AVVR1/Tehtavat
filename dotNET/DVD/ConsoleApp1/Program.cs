using Raylib_cs;
using System.Numerics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int screenWidth = 720;
            int screenHeight = 400;

            Vector2 direction = new Vector2(1, -1);

            float speed = 100.0f;

            float speedIncrease = 5f;

            Color color = Color.Yellow;

            Raylib.InitWindow(screenWidth, screenHeight, "DVD");

            Vector2 textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), "DVD", 20, 1);

            Vector2 pos = new Vector2(screenWidth / 2 - textSize.X/2, screenHeight / 2 - textSize.Y/2);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);




                Raylib.DrawText("DVD", ((int)pos.X), ((int)pos.Y), 20, color);
                #region ehdot
                if (pos.X + textSize.X > screenWidth)
                {
                    pos.X = screenWidth - textSize.X;
                    direction.X = -direction.X;
                    Collision();
                }
                if (pos.X < 0)
                {
                    pos.X = 0;
                    direction.X = -direction.X;
                    Collision();
                }
                if (pos.Y + textSize.Y > screenHeight)
                {
                    pos.Y = screenHeight - textSize.Y;
                    direction.Y = -direction.Y;
                    Collision();
                }
                if (pos.Y < 0)
                {
                    pos.Y = 0;
                    direction.Y = -direction.Y;
                    Collision();
                }
                #endregion
                pos += direction * speed * Raylib.GetFrameTime();

                void Collision()
                {
                    speed += speedIncrease;
                    color = Raylib.ColorFromHSV(Raylib.GetRandomValue(0,360), 1, 1);
                }

                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
