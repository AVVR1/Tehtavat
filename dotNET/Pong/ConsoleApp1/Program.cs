using Raylib_cs;
using System.Numerics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Raylib.InitWindow(960,540,"PONG");
            //Raylib.ToggleFullscreen();

            #region muuttujat
            int windowWidth = Raylib.GetScreenWidth();
            int windowHeight = Raylib.GetScreenHeight();

            float moveSpeed = 10;
            Vector2 wallSize = new Vector2(20, 100);

            Vector2 p1Pos = new Vector2(10, windowHeight / 2 - wallSize.Y / 2);
            int p1Points = 0;
            Vector2 p1PointPos = new Vector2(windowWidth / 4, 0);

            Vector2 p2Pos = new Vector2(windowWidth - wallSize.X - 10, windowHeight / 2 - wallSize.Y / 2);
            int p2Points = 0;
            Vector2 p2PointPos = new Vector2(windowWidth * 3/4, 0);



            Vector2 ballPos = new Vector2(windowWidth / 2, windowHeight / 2);
            Vector2 ballDir = new Vector2(1, 1);
            float ballSpeed = 500;

            #endregion

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DarkBlue);
                //////////////////////////////////////
                Raylib.DrawRectangleV(p1Pos, wallSize, Color.White);
                Raylib.DrawRectangleV(p2Pos, wallSize, Color.White);

                Raylib.DrawTextEx(Raylib.GetFontDefault(), p1Points.ToString(), p1PointPos, 48, 0, Color.White);
                Raylib.DrawTextEx(Raylib.GetFontDefault(), p2Points.ToString(), p2PointPos, 48, 0, Color.White);

                Raylib.DrawCircleV(ballPos, 10, Color.White);

                ballPos += ballDir * ballSpeed * Raylib.GetFrameTime();

                if (Raylib.CheckCollisionPointRec(ballPos, new Rectangle(p1Pos, wallSize)))
                {
                    ballPos.X = p1Pos.X + wallSize.X;
                    ballDir.X = -ballDir.X;
                }

                if (Raylib.CheckCollisionPointRec(ballPos, new Rectangle(p2Pos, wallSize)))
                {
                    ballPos.X = p2Pos.X;
                    ballDir.X = -ballDir.X;
                }

                if (ballPos.Y < 0)
                {
                    ballPos.Y = 0;
                    ballDir.Y = -ballDir.Y;
                }

                if (ballPos.Y > windowHeight)
                {
                    ballPos.Y = windowHeight;
                    ballDir.Y = -ballDir.Y;
                }



                Raylib.EndDrawing();

                //////////////////////////////////////
            }
            Raylib.CloseWindow();
        }
    }
}
