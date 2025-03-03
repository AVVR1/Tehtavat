using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Seikkailijanreppu
{
	internal class Reppu
	{
		int rajoitus = 10;
		float tila = 20;
		float kesto = 30;

		public VäritettyTavara<Tavara>[] sisältö { get; private set; } = new VäritettyTavara<Tavara>[10];
		public int määrä = 0;

		public Reppu(int rajoitus, float tila, float kesto)
		{
			this.rajoitus = rajoitus;
			this.tila = tila;
			this.kesto = kesto;
		}

		public bool Lisää(VäritettyTavara<Tavara> tavara)
		{
			if (määrä < rajoitus && tavara.tavara.tilavuus + laskeTila() <= tila && tavara.tavara.paino + LaskePaino() <= kesto)
			{
				sisältö[määrä] = tavara;
				määrä++;
				return true;
			}
			return false;
		}

		public float laskeTila()
		{
			float tila = 0;
			foreach (VäritettyTavara<Tavara> tavara in sisältö)
			{
				if (tavara != null)
				{
					tila += tavara.tavara.tilavuus;
				}
			}
			return tila;
		}

		public float LaskePaino()
		{
			float paino = 0;
			foreach (VäritettyTavara<Tavara> tavara in sisältö)
			{
				if (tavara !=  null)
				{
					paino += tavara.tavara.paino;
				}
			}
			return paino;
		}
		
		public override string ToString()
		{
			string[] strings = new string[10];
			for (int i = 0; i < sisältö.Length; i++)
			{
				if (sisältö[i] != null)
				{
					strings[i] = sisältö[i].tavara.ToString();
				}
			}
			return $"Reppussa on seuraavat tavarat: {string.Join(" ", strings)}";
		}
	}
}
