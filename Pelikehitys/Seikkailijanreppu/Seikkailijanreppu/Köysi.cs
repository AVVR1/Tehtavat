using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seikkailijanreppu
{
	internal class Köysi : Tavara
	{
		public Köysi() : base(1f, 0.5f)
		{

		}
		public override string ToString()
		{
			return "köysi";
		}
	}
}
