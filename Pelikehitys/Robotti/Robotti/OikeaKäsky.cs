using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotti
{
	internal class OikeaKäsky : RobottiKäsky
	{
		public override void Suorita(Robotti robotti)
		{
			if (robotti.OnKäynnissä)
			{
				robotti.X += 1;
			}
		}
	}
}
