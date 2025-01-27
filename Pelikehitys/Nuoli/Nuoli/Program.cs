using System.Runtime.CompilerServices;

namespace Nuoli
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Minkälainen kärki (puu, teräs vai timantti)?: ");
			Nuoli.ArrowHead kärki = Enum.Parse<Nuoli.ArrowHead>(Console.ReadLine());

			Console.Write("Minkälaiset sulat (lehti, kanansulka vai kotkansulka)?: ");
			Nuoli.Fletching sulat = Enum.Parse<Nuoli.Fletching>(Console.ReadLine());

			Console.Write("Nuolen pituus (60-100cm): ");
			byte ShaftLenghtCm = byte.Parse(Console.ReadLine());

			Nuoli nuoli = new Nuoli(kärki,sulat,ShaftLenghtCm);
			Console.WriteLine($"Tämän nuolen hinta on {nuoli.PalautaHinta()} kultaa.");
		}
	}
}
