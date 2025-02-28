using System;
using Raylib_cs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lunar_Lander
{
	internal class Rocket
	{

		public Vector2 velocity = Vector2.Zero;
		float acceleration;
		float enginePower = 200;
		public float fuel = 500;
		public bool engineOn = false;

		public Vector2 pos = new Vector2(480,0);

		Vector2 A = new Vector2(0, 0);
		Vector2 B = new Vector2(-15, 40);
		Vector2 C = new Vector2(15, 40);
		public void Update()
		{
			//kiihtyvyys nollataan
			acceleration = 0;

			//aika viimeisestä ruudunpäivityksestä
			float deltaTime = Raylib.GetFrameTime();

			if (Raylib.IsKeyDown(KeyboardKey.Space) && fuel > 0)
			{
				engineOn = true;
				//kuluta polttoainetta
				fuel -= deltaTime * enginePower;
				//lisää kiihtyvyyteen moottorin voima ylöspäin
				acceleration -= enginePower;
			}
			else
			{
				engineOn = false;
			}

			//lisää kiihtyvyyteen painovoima alaspäin
			acceleration += 9.8f * 10;

			///summary
			/// kun lisätään moottorin voima ja painovoima kiihtyvyyteen voidaan kuvitella voimat suuntavektoreina.
			/// painovoima on aina sama, ja jos moottori on päällä se on myös sama tässä tapauksessa.
			/// joka ruudunpäivityksessä voimat lisätään kiihtyvyyteen, ja kiihtyvyys lisätään nopeuteen. Tätä varten pitää nollata kiihtyvyys.
			/// nopeus taas päivittää paikkaa.
			///

			//lisää kiihtyvyys nopeuteen
			velocity.Y += acceleration * deltaTime;

			//päivitä sijainti nopeudella ja ruudunpäivityksen ajalla.
			pos.Y += velocity.Y * deltaTime;
		}

		public void Draw()
		{
			Raylib.DrawTriangle(A + pos, B + pos, C + pos, Color.White);
			if (engineOn)
			{
				Raylib.DrawTriangle(B + pos + Vector2.UnitX * 5, new Vector2(A.X, A.Y + 70) + pos, C + pos - Vector2.UnitX*5, Color.Orange);
			}
		}
	}
}
