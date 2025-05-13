using ClassLibrary1;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    static class AsteroidManager
    {
        public static List<Asteroid> asteroids = new List<Asteroid>();

		static string root = "Images/Asteroids/meteorBrown_";
        static string[] asteroidTextures = new string[7];
		public static Texture2D[] textures = new Texture2D[7];

        static Random random = new Random();

        // Spawn area
        static float spawnProtectionRadius = 200f;
        static float maxDistance = 500f;

        //Speed
        static float minSpeed = 50f;
        static float maxSpeed = 75f;

		public static void InitTextures()
        {
			asteroidTextures =
            [
	            root + "big1.png",
				root + "big3.png",
				root + "big4.png",
				root + "med1.png",
				root + "med3.png",
				root + "small1.png",
				root + "small2.png",
			];
            for (int i = 0; i < textures.Length; i++)
			{
                textures[i] = Raylib.LoadTexture(asteroidTextures[i]);
			}
		}

        public static void UnloadTextures()
        {
            foreach (Texture2D texture in textures)
            {
                Raylib.UnloadTexture(texture);
            }
        }

		public static void UpdateAsteroids()
        {
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Update();
            }
        }

        public static void DrawAsteroids()
        {
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Draw();
            }
        }

        public static void SpawnAsteroidWave(int difficulty, Vector2 playerPos)
        {
            float speed = Class1.GetRandomValueBetween(minSpeed, maxSpeed, random);
            for (int i = 0; i < 4 + difficulty; i++)
			{
			    new Asteroid(GetSpawnPosition(playerPos), Class1.GetRandomDirection(), speed, Asteroid.AsteroidSize.Big);
			}
		}

        static Vector2 GetSpawnPosition(Vector2 playerPos)
		{
            Vector2 direction = Class1.GetRandomDirection();
            float distance = Class1.GetRandomValueBetween(spawnProtectionRadius, maxDistance, random);
			return direction * distance + playerPos;
		}
	}
}
