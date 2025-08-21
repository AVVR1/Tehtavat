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
    class Player : Movable, ICollidable
    {
        Vector2 velocity = Vector2.Zero;
        Vector2 acceleration = Vector2.Zero;
		public bool isAlive = true;
        public bool drawTexture = true;
        bool engineOn = false;
        bool hit = false;

        //variables
        Vector2 spawnPosition = new Vector2(400, 300);
        float maxSpeed = 300f;
        float enginePower = 200f;
		public int lives = 3;
        float invincibilityTime = 3f;

        //counters
        public float points = 0;
        float timer = 0f;

		public ColliderType colliderType { get; set; } = ColliderType.Rectangle;
        public object hitbox { get; set; } = new Vector2(30, 70);

		public Player()
        {
			position = spawnPosition;
			direction = new Vector2(0, 1);
			Bullet.SetPlayer(this);
			CollisionManager.collidables.Add(this);
		}
		public void Update()
		{
            if (!isAlive) return;
            Input();
            CalculateMovement();
			WarpToScreen();
            if (hit)
            {
                InvincibilityTimer();
            }
        }

		private void Input()
		{
            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                rotation += 300 * Raylib.GetFrameTime();
                rotation %= 360;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                rotation -= 300 * Raylib.GetFrameTime();
                rotation %= 360;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                engineOn = true;
            }
            else
            {
                engineOn = false;
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                Bullet bullet = new Bullet(position + direction * 50, direction, rotation, 500f);
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

		public void OnCollide(ICollidable collider)
		{
			Console.WriteLine("HIT");
			lives--;
            AddPoints(collider);
            Respawn();
            if (lives <= 0)
			{
                isAlive = false;
            }
        }

        void InvincibilityTimer()
        {
            timer += Raylib.GetFrameTime();
            drawTexture = (MathF.Round(timer,1) % 0.5f == 0) ? true : false;
            if (timer >= invincibilityTime)
            {
                Console.WriteLine("end invincibility");
                hit = false;
                timer = 0f;
                CollisionManager.collidables.Add(this);
            }
        }

        void Respawn()
        {
            hit = true;
            CollisionManager.collidables.Remove(this);
            position = spawnPosition;
            velocity = Vector2.Zero;
            rotation = 0;
        }

        public void AddPoints(ICollidable collider)
        {
			if (collider.GetType() == typeof(Asteroid))
			{
                Asteroid asteroid = (Asteroid)collider;
				switch (asteroid.asteroidSize)
				{
					case Asteroid.AsteroidSize.Big:
					points += 20;
					break;
					case Asteroid.AsteroidSize.Medium:
					points += 50;
					break;
					case Asteroid.AsteroidSize.Small:
					points += 100;
					break;
				}
			}
		}
	}
}