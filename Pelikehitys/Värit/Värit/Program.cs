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
					Console.WriteLine(i + 1 + " - " + tavarat[i].Name);
				}
				string valinta = Console.ReadLine();
				VäritettyTavara<Tavara> valittuTavara = valinta switch
				{
					"1" => new VäritettyTavara<Tavara>(new Nuoli(), ConsoleColor.DarkGray),
					"2" => new VäritettyTavara<Tavara>(new Jousi(), ConsoleColor.Green),
					"3" => new VäritettyTavara<Tavara>(new Vesi(), ConsoleColor.Blue),
					"4" => new VäritettyTavara<Tavara>(new Ruoka_annos(), ConsoleColor.Yellow),
					"5" => new VäritettyTavara<Tavara>(new Miekka(), ConsoleColor.Red),
					"6" => new VäritettyTavara<Tavara>(new Köysi(), ConsoleColor.DarkYellow)
				};

				if (reppu.Lisää(valittuTavara))
				{
					Console.Clear();
					valittuTavara.NaytaTavara();
					Console.WriteLine(reppu);
				}
				else
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Tavaraa ei voi laittaa reppuun");
					Console.ResetColor();
				}
			}
		}
	}
}
