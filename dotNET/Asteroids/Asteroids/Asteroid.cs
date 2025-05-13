using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Raylib_cs;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Asteroids
{
	//float means circle
	internal class Asteroid : Movable, ICollidable
	{
		public enum AsteroidSize { Big, Medium, Small}

		float speed;
		AsteroidSize asteroidSize;

		public object hitbox { get; set; } = 40f;
		public ColliderType colliderType { get; set; } = ColliderType.Circle;

		Random random = new Random();

		public void OnCollide()
		{
			Vector2 dir = Class1.GetRandomDirection();
			float distance = random.NextSingle();
			switch (asteroidSize)
			{
				case AsteroidSize.Big:
					new Asteroid(position + dir * distance * 40, dir + direction, speed, AsteroidSize.Medium);
                    new Asteroid(position - dir * (1 - distance) * 40, -dir + direction, speed, AsteroidSize.Medium);
				break;
				case AsteroidSize.Medium:
					new Asteroid(position + dir * distance * 20, dir + direction, speed, AsteroidSize.Small);
					new Asteroid(position - dir * (1 - distance) * 20, -dir + direction, speed, AsteroidSize.Small);
				break;
				case AsteroidSize.Small:
                
				break;
			}
			AsteroidManager.asteroids.Remove(this);
			CollisionManager.collidables.Remove(this);
		}

		public Asteroid(Vector2 position, Vector2 direction, float speed, AsteroidSize asteroidSize)
		{
			this.position = position;
			this.direction = direction;
			this.speed = speed;
			this.asteroidSize = asteroidSize;
			LoadRandomTexture();
			SetHitboxSize();
			CollisionManager.collidables.Add(this);
			AsteroidManager.asteroids.Add(this);
		}

		public void LoadRandomTexture()
		{
			Random random = new Random();
			int randomTextureIndex;
			switch (asteroidSize)
			{
				case AsteroidSize.Big:
					randomTextureIndex = random.Next(3);
				break;
				case AsteroidSize.Medium:
					randomTextureIndex = random.Next(3, 5);
				break;
				case AsteroidSize.Small:
					randomTextureIndex = random.Next(5, 7);
				break;
				default:
                    randomTextureIndex = 0;
                    break;
            }
            texture = AsteroidManager.textures[randomTextureIndex];
		}

		void SetHitboxSize()
		{
			switch (asteroidSize)
			{
				case AsteroidSize.Big:
				hitbox = 40f;
				break;
				case AsteroidSize.Medium:
				hitbox = 20f;
				break;
				case AsteroidSize.Small:
				hitbox = 10f;
				break;
			}
		}

		public void Update()
		{
			Movement();
			WarpToScreen();
		}

		public void Movement()
		{
			float deltaTime = Raylib.GetFrameTime();
			rotation += deltaTime * 50;
			position += direction * speed * deltaTime;
		}
	}
}
