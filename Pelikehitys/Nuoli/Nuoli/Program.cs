namespace Nuoli
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Nuoli nuoli = new Nuoli();

			Console.Write("Minkälainen kärki (puu, teräs vai timantti)?: ");

			nuoli.kärki = Enum.Parse<Nuoli.ArrowHead>(Console.ReadLine());


			Console.Write("Minkälaiset sulat (lehti, kanansulka vai kotkansulka)?: ");

			nuoli.sulat = Enum.Parse<Nuoli.Fletching>(Console.ReadLine());

			Console.Write("Nuolen pituus (60-100cm): ");

			nuoli.shaftLenghtCm = byte.Parse(Console.ReadLine());

			Console.WriteLine($"Tämän nuolen hinta on {nuoli.PalautaHinta()} kultaa.");
		}
	}
}
