using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuoli
{
	internal class Nuoli
	{
		public enum ArrowHead { puu, teräs, timantti }
		public enum Fletching { lehti, kanansulka, kotkansulka}
		public ArrowHead kärki { get; private set; }
		public Fletching sulat { get; private set; }
		public byte shaftLenghtCm { get; private set; }

		public float PalautaHinta()
		{
			float hinta = 0;
			hinta += kärki switch
			{
				ArrowHead.puu => 3,
				ArrowHead.teräs => 5,
				ArrowHead.timantti => 50,
				_ => 0,
			};
			hinta += sulat switch
			{
				Fletching.lehti => 0,
				Fletching.kanansulka => 1,
				Fletching.kotkansulka => 5,
				_ => 0,
			};

			hinta += shaftLenghtCm * 0.05f;
			return hinta;
		}
	}
}
