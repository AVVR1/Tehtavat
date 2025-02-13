namespace Robotti
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Robotti robotti = new Robotti();

			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine($"Mitä komentoja syötetään robotille? Vaihtoehdot: Käynnistä, Sammuta, Ylös, Alas, Oikea, Vasen.");
				string käsky = Console.ReadLine();
				robotti.Käskyt[i] = käsky.ToLower() switch
				{
					"käynnistä" => new Käynnistä(),
					"sammuta" => new Sammuta(),
					"ylös" => new YlösKäsky(),
					"alas" => new AlasKäsky(),
					"oikea" => new OikeaKäsky(),
					"vasen" => new VasenKäsky(),
					_ => null
				};
			}
			robotti.Suorita();
		}
	}
}
