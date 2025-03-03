using Seikkailijanreppu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seikkailijanreppu
{
	internal class VäritettyTavara<T>
	{
		public T tavara;
		ConsoleColor color;

		public VäritettyTavara(T tavara, ConsoleColor color)
		{
			this.color = color;
			this.tavara = tavara;
		}

		public void NaytaTavara()
		{
			Console.ForegroundColor = color;
			Console.WriteLine(tavara?.ToString());
			Console.ResetColor();
		}
	}
}