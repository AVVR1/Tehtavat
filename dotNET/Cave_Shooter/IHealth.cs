using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal interface IHealth
	{
		void OnDeath();

		void OnHurt();
	}
}
