using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Koordinaatisto
{
	internal struct Koordinaatti
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Koordinaatti(int X, int Y)
		{
			this.X = X;
			this.Y = Y;
		}
		public bool TarkistaViereisetRuudukot(Koordinaatti verrattavaKoordinaatti)
		{
			if(Vector2.Distance(new Vector2(X, Y), new Vector2(verrattavaKoordinaatti.X, verrattavaKoordinaatti.Y)) <= MathF.Sqrt(2))
            {
				return true;
            }
            return false;
		}
	}
	//Math.abs(
}
