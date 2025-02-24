using System;
using System.Collections.Generic;
using System.Linq;
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
		public bool TarkistaViereisetRuudukot()
		{
            if (MathF.Abs(X) < 2 && MathF.Abs(Y) < 2)
            {
				return true;
            }
            return false;
		}
	}
}
