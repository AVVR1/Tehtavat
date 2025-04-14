using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Reflection.Metadata;

namespace Asteroids
{
    class Player
    {
        public Texture2D shipTexture;
        public Vector2 position = new Vector2(200, 200);
        public Vector2 direction = new Vector2(0, 1);
        public float rotation;

        public bool engineOn = false;

        public Vector2 velocity = Vector2.Zero;
        Vector2 acceleration = Vector2.Zero;

        //variables
        public float maxSpeed = 300f;
        float enginePower = 200;

        public Player()
        {

        }
		public void Update()
		{
            CalculateMovement();
            int screenWidth = Raylib.GetScreenWidth();
			int screenHeight = Raylib.GetScreenHeight();
            int playerWidth = shipTexture.Width;
            int playerHeight = shipTexture.Height;

			if (position.X > screenWidth + playerWidth)
            {
                position.X = -playerWidth;
            }
            if (position.Y > screenHeight + playerHeight)
            {
                position.Y = -playerHeight;
            }
            if (position.X < -playerWidth)
            {
                position.X = screenWidth + playerWidth;
            }
            if (position.Y < -playerHeight)
            {
                position.Y = screenHeight + playerHeight;
            }
        }

        private void CalculateMovement()
        {
			float deltaTime = Raylib.GetFrameTime();
			acceleration = Vector2.Zero;
			direction = Vector2.Transform(-Vector2.UnitY, Matrix3x2.CreateRotation(rotation * Raylib.DEG2RAD));

			if (engineOn)
			{
				acceleration += direction * enginePower;
			}

			velocity += acceleration * deltaTime;

			if (velocity.Length() >= maxSpeed)
			{
				velocity = Vector2.Normalize(velocity) * maxSpeed;
			}
			position += velocity * deltaTime;
		}


        public void Draw()
        {
            Class1.DrawTextureRotated(shipTexture, position, rotation);
            Raylib.DrawLineV(position, position + direction * 200, Color.Red);
            Raylib.DrawLineV(position, position + velocity, Color.Green);
		}
	}
}
