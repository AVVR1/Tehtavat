using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotti
{
	internal class Sammuta : IRobottiKäsky
	{
		public void Suorita(Robotti robotti)
		{
			robotti.OnKäynnissä = false;
		}
	}
}
