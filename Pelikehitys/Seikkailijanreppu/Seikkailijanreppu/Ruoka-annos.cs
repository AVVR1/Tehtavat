using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seikkailijanreppu
{
	internal class Ruoka_annos : Tavara
	{
		public Ruoka_annos() : base(1, 0.5f)
		{

		}

		public override string ToString()
		{
			return "ruoka-annos";
		}
	}
}
