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
		public object shootKey => KeyboardKey.S;

		public object shootSpecialKey => throw new NotImplementedException();

		public object thrustKey => throw new NotImplementedException();

		public object turnRightKey => throw new NotImplementedException();

		public object turnLeftKey => throw new NotImplementedException();

	}
}
