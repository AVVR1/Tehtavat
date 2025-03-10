namespace Koordinaatisto
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Koordinaatti[] koordinaatit = new Koordinaatti[9];
			Random random = new Random();

			int i = 0;
			for (int x = -1; x < 2; x++)
			{
				for (int y = -1; y < 2; y++)
				{
					koordinaatit[i] = new Koordinaatti(x,y);
					i++;
				}
			}

			Koordinaatti verrattavaKoordinaatti = new Koordinaatti(random.Next(-1,2),random.Next(-1,2));

            foreach (Koordinaatti koordinaatti in koordinaatit)
			{
				if (koordinaatti.TarkistaViereisetRuudukot(verrattavaKoordinaatti))
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"Annettu koordinaatti {koordinaatti.X},{koordinaatti.Y} on kordinaatin {verrattavaKoordinaatti.X},{verrattavaKoordinaatti.Y} vieressä.");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Annettu koordinaatti {koordinaatti.X},{koordinaatti.Y} ei ole kordinaatin {verrattavaKoordinaatti.X},{verrattavaKoordinaatti.Y} vieressä.");
				}
			}
			Console.ResetColor();
		}
	}
}
