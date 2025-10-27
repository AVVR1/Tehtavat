using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class Keyboard : IInput
	{
		public object ShootInput { get; } = KeyboardKey.S;

		public object ShootSpecialInput { get; } = KeyboardKey.E;

		public object ThrustInput { get; } = KeyboardKey.W;

		public object TurnLeftInput { get; } = KeyboardKey.A;

		public object TurnRightInput { get; } = KeyboardKey.D;

	}
}
