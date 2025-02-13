using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotti
{
	internal class AlasKäsky : RobottiKäsky
	{
		public override void Suorita(Robotti robotti)
		{
			if (robotti.OnKäynnissä)
			{
				robotti.Y -= 1;
			}
		}
	}
}
