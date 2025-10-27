using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal interface IInput
	{
		object ShootInput { get; }

		object ShootSpecialInput { get; }

		object ThrustInput { get; }

		object TurnRightInput { get; }

		object TurnLeftInput { get; }
	}
}
