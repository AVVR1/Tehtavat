using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal struct Keybinds
	{
		public Enum ThrustInput;

		public Enum ShootInput;

		public Enum ShootSpecialInput;

		public Enum TurnLeftInput;

		public Enum TurnRightInput;

		public Keybinds(Enum thrustInput, Enum shootInput, Enum shootSpecialInput, Enum turnLeftInput, Enum turnRightInput)
		{
			ThrustInput = thrustInput;
			ShootInput = shootInput;
			ShootSpecialInput = shootSpecialInput;
			TurnLeftInput = turnLeftInput;
			TurnRightInput = turnRightInput;
		}
	}
}
