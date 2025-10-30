using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal interface IInput
	{
		object ThrustInput { get; }

		object ShootInput { get; }

		object ShootSpecialInput { get; }

		object TurnRightInput { get; }

		object TurnLeftInput { get; }
	}
}
