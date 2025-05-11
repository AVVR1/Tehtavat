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

		string root = "Images/Asteroids/";
		string beginning = "meteorBrown_";
		string[] asteroidTextures;
		float speed;
		AsteroidSize asteroidSize;

		public object hitbox { get; set; } = 40f;
		public ColliderType colliderType { get; set; } = ColliderType.Circle;

		public void OnCollide()
		{
			switch (asteroidSize)
			{
				case AsteroidSize.Big:
                    AsteroidManager.asteroids.Add(new Asteroid(position + Vector2.UnitX * 85, Class1.GetRandomDirection() + direction, 15f, AsteroidSize.Medium));
                    AsteroidManager.asteroids.Add(new Asteroid(position + -Vector2.UnitX * 85, Class1.GetRandomDirection() + direction, 15f, AsteroidSize.Medium));
				break;
				case AsteroidSize.Medium:
					AsteroidManager.asteroids.Add(new Asteroid(position + Vector2.UnitX * 45, Class1.GetRandomDirection() + direction, 20f, AsteroidSize.Small));
					AsteroidManager.asteroids.Add(new Asteroid(position + -Vector2.UnitX * 45, Class1.GetRandomDirection() + direction, 20f, AsteroidSize.Small));
				break;
				case AsteroidSize.Small:
					
				break;
			}
			AsteroidManager.asteroids.Remove(this);
			CollisionManager.collidables.Remove(this);
			
            Console.WriteLine("Asteroid collision");
		}

		public Asteroid(Vector2 position, Vector2 direction, float speed, AsteroidSize asteroidSize)
		{
			asteroidTextures = 
			[
				root + beginning + "big1.png",
				root + beginning + "big3.png",
				root + beginning + "big4.png",
				root + beginning + "med1.png",
				root + beginning + "med3.png",
				root + beginning + "small1.png",
				root + beginning + "small2.png",
			];
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
					randomTextureIndex = random.Next(4, 6);
				break;
				case AsteroidSize.Small:
					randomTextureIndex = random.Next(5, 7);
				break;
				default:
                    randomTextureIndex = 0;
                    break;
            }
            texture = Raylib.LoadTexture(asteroidTextures[randomTextureIndex]);
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
				hitbox = 5f;
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
