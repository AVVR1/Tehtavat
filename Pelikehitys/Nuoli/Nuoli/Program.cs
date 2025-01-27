using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Nuoli
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Nuoli nuoli = new Nuoli(Nuoli.ArrowHead.puu, Nuoli.Fletching.lehti, 0);

            Console.Write("Haluatko valita valmiin nuolipohjan (y/n)?: ");
			if (Console.ReadLine().ToLower() == "y")
			{
				Console.Write("Valitse nuolipohja (eliitti, aloittelija, perus): ");
				string valinta = Console.ReadLine();
				if (valinta == "eliitti")
				{
					nuoli = Nuoli.LuoEliittiNuoli();
				}
				else if (valinta == "aloittelija")
				{
					nuoli = Nuoli.LuoAloittelijaNuoli();
				}
				else if (valinta == "perus")
				{
					nuoli = Nuoli.LuoPerusNuoli();
				}
				else
				{
					Console.WriteLine("Virheellinen valinta");
					return;
				}
			}
			else
			{
				Console.Write("Minkälainen kärki (puu, teräs vai timantti)?: ");
				Nuoli.ArrowHead kärki = Enum.Parse<Nuoli.ArrowHead>(Console.ReadLine());

				Console.Write("Minkälaiset sulat (lehti, kanansulka vai kotkansulka)?: ");
				Nuoli.Fletching sulat = Enum.Parse<Nuoli.Fletching>(Console.ReadLine());

				Console.Write("Nuolen pituus (60-100cm): ");
				byte ShaftLenghtCm = byte.Parse(Console.ReadLine());

				nuoli = new Nuoli(kärki, sulat, ShaftLenghtCm);
			}
			Console.WriteLine($"Tämän nuolen hinta on {nuoli.PalautaHinta()} kultaa.");
		}
	}
}
