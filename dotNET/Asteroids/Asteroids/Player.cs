using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Asteroids
{
    class Player
    {
        public Texture2D shipTexture;
        public Vector2 position = new Vector2(100, 100);
        public float rotation;
        public Player()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {
            Class1.DrawTextureRotated(shipTexture, position, rotation);
		}
	}
}
