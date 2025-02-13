using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotti
{
	internal class Käynnistä : IRobottiKäsky
	{
		public void Suorita(Robotti robotti)
		{
			robotti.OnKäynnissä = true;
		}
	}
}
