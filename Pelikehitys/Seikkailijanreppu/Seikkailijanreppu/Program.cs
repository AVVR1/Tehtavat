using System.Xml;

namespace Seikkailijanreppu
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int rajoitus = 10;
			float tila = 20;
			float kesto = 30;
			Reppu reppu = new Reppu(10,20,30);

			List<Type> tavarat = new List<Type> { typeof(Nuoli), typeof(Jousi), typeof(Vesi), typeof(Ruoka_annos), typeof(Miekka), typeof(Köysi) };

			while (true)
			{
                Console.WriteLine($"Repussa on tällä hetkellä {reppu.määrä}/{rajoitus} tavaraa, {reppu.LaskePaino()}/{kesto} painoa ja {reppu.laskeTila()}/{tila} tilaa");
                Console.WriteLine("Mitä haluat lisätä?");
				for (int i = 0; i < tavarat.Count; i++)
				{
					Console.WriteLine(i+1 + " - " + tavarat[i].Name);
				}
				string valinta = Console.ReadLine();
				Tavara valittuTavara = valinta switch
				{
					"1" => new Nuoli(),
					"2" => new Jousi(),
					"3" => new Vesi(),
					"4" => new Ruoka_annos(),
					"5" => new Miekka(),
					"6" => new Köysi()
				};

				if (reppu.Lisää(valittuTavara))
				{
					
				}
			}
		}
	}
}
