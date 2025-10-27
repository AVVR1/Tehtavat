using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal interface IInput
	{
		object shootKey { get; }

		object shootSpecialKey { get; }

		object thrustKey { get; }

		object turnRightKey { get; }

		object turnLeftKey { get; }
	}
}
