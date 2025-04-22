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
    class Player : Movable
    {
        public bool engineOn = false;

        public Vector2 velocity = Vector2.Zero;
        Vector2 acceleration = Vector2.Zero;

        //variables
        public float maxSpeed = 300f;
        float enginePower = 200;

		public static Vector2 hitBox { get; private set; } = new Vector2(10, 50);

        public Player()
        {
			position = new Vector2(200, 200);
			direction = new Vector2(0, 1);
		}
		public void Update()
		{
            CalculateMovement();
			WarpToScreen();
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
	}
}
