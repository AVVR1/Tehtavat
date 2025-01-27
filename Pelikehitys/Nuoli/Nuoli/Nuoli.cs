using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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

		public Nuoli(Nuoli.ArrowHead karki, Nuoli.Fletching sulat, byte pituus)
		{
			this.kärki = karki;
			this.sulat = sulat;
			shaftLenghtCm = pituus;
		}

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

		public static Nuoli LuoEliittiNuoli()
		{
			return new Nuoli(ArrowHead.timantti, Fletching.kotkansulka, 100);
		}
		public static Nuoli LuoAloittelijaNuoli()
		{
			return new Nuoli(ArrowHead.puu, Fletching.kanansulka, 70);
		}
		public static Nuoli LuoPerusNuoli()
		{
			return new Nuoli(ArrowHead.teräs, Fletching.kanansulka, 85);
		}
	}
}
