using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seikkailijanreppu
{
	public class Nuoli : Tavara
	{
		public Nuoli() : base(0.1f, 0.05f)
		{
			
		}

		public override string ToString()
		{
			return "nuoli";
		}
	}
}
