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
