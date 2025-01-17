using Raylib_cs;
using System.Diagnostics;
using System.Numerics;

namespace Raylib_testi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int screenWidth = 720;
            int screenHeight = 720;

            Vector2 A = new Vector2(screenWidth/2,0);
            Vector2 B = new Vector2(0,screenHeight/2);
            Vector2 C = new Vector2(screenWidth,screenHeight * 3/4);

            Vector2 dirA = new Vector2(1, 1);
            Vector2 dirB = new Vector2(1, -1);
            Vector2 dirC = new Vector2(-1, 1);

            float nopeus =100f;
            Raylib.InitWindow(screenWidth, screenHeight, "");
            while (Raylib.WindowShouldClose() == false)
            {
                Raylib.ClearBackground(Color.Black);
                A = A + dirA * nopeus * Raylib.GetFrameTime();
                B = B + dirB * nopeus * Raylib.GetFrameTime();
                C = C + dirC * nopeus * Raylib.GetFrameTime();
                Raylib.BeginDrawing();

                //viivat
                Raylib.DrawLineV(A, B, Color.Green);
                Raylib.DrawLineV(B, C, Color.Yellow);
                Raylib.DrawLineV(C, A, Color.Red);

                //ifs
                if (A.X < 0 || A.X > screenWidth)
                {
                    dirA.X = -dirA.X;
                }

                if (A.Y < 0 || A.Y > screenHeight)
                {
                    dirA.Y = -dirA.Y;
                }

                if (B.X < 0 || B.X > screenWidth)
                {
                    dirB.X = -dirB.X;
                }

                if (B.Y < 0 || B.Y > screenHeight)
                {
                    dirB.Y = -dirB.Y;
                }

                if (C.X < 0 || C.X > screenWidth)
                {
                    dirC.X = -dirC.X;
                }

                if (C.Y < 0 || C.Y > screenHeight)
                {
                    dirC.Y = -dirC.Y;
                }
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
