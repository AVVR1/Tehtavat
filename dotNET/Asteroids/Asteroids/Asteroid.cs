using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Raylib_cs;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Asteroids
{
	//float means circle
	internal class Asteroid : Movable, ICollidable
	{
		string root = "Images/Asteroids/";
		string beginning = "meteorBrown_";
		string[] asteroidTextures;
		float speed;

		//Variables
		public float radius = 100f;

		public object hitbox { get; set; } = 40f;
		public ColliderType colliderType { get; set; } = ColliderType.Circle;

		public void OnCollide()
		{
			CollisionManager.collidables.Remove(this);
            Console.WriteLine("Asteroid collision");
		}

		public Asteroid(Vector2 position, Vector2 direction, float speed)
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
			CollisionManager.collidables.Add(this);
			this.position = position;
			this.direction = direction;
			this.speed = speed;
		}

		public void LoadRandomTexture()
		{
			Random random = new Random();
			int randomTextureIndex = random.Next(3);
			texture = Raylib.LoadTexture(asteroidTextures[randomTextureIndex]);
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
