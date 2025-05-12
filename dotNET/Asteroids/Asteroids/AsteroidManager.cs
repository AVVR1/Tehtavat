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
    }
}
