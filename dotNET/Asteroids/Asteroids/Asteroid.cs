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
	internal class Asteroid : Movable
	{
		string root = "Images/Asteroids/";
		string beginning = "meteorBrown_";
		string[] asteroidTextures;
		float speed = 1;

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
			this.position = position;
			this.direction = direction;
			this.speed = speed;
		}

		public void LoadRandomTexture()
		{
			Random random = new Random();
			int randomTextureIndex = random.Next(4);
			texture = Raylib.LoadTexture(asteroidTextures[randomTextureIndex]);
		}

		public void Update()
		{
			Movement();
			WarpToScreen();
			if (CheckCollisionAsteroidPlayer())
			{

			}
		}

		public void Movement()
		{
			float deltaTime = Raylib.GetFrameTime();
			rotation += deltaTime * 50;
			position += direction * speed * deltaTime;
		}

		public bool CheckCollisionAsteroidPlayer(Player player)
		{
			if (Raylib.CheckCollisionCircleRec(position, texture.Width / 2, new Rectangle(player.position, Player.hitBox)))
			{
				return true;
			}
			return false;
		}

		public void Collision()
		{

		}
	}
}
