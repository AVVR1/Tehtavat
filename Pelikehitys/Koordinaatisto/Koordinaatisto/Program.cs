namespace Koordinaatisto
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Koordinaatti[] koordinaatit = new Koordinaatti[9];
			int i = 0;
			for (int x = -1; x < 2; x++)
			{
				for (int y = -1; y < 2; y++)
				{
					koordinaatit[i] = new Koordinaatti(x,y);
					i++;
				}
			}

            foreach (Koordinaatti koordinaatti in koordinaatit)
			{
				if (koordinaatti.TarkistaViereisetRuudukot())
				{
					Console.WriteLine($"Annettu koordinaatti {koordinaatti.X},{koordinaatti.Y} on kordinaatin 0,0 vieressä.");
				}
				else
				{
					Console.WriteLine($"Annettu koordinaatti {koordinaatti.X},{koordinaatti.Y} ei ole kordinaatin 0,0 vieressä.");
				}
			}
		}
	}
}
