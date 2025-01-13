namespace ConsoleApp1
{
    public enum Ovi { Auki, Kiinni, Lukossa };
    internal class Program
    {
        static void Main(string[] args)
        {
            Ovi ovi = Ovi.Kiinni;
            while (true)
            {
                Console.Write($"Ovi on {ovi}. Mitä haluat tehdä? ");
                string action = Console.ReadLine();
                if (action == "avaa" && ovi == Ovi.Kiinni)
                {
                    ovi = Ovi.Auki;
                } else if (action == "lukitse" && ovi == Ovi.Kiinni)
                {
                    ovi = Ovi.Lukossa;
                } else if (action == "sulje" && ovi == Ovi.Auki)
                {
                    ovi = Ovi.Kiinni;
                } else if (action == "poista lukitus" && ovi == Ovi.Lukossa)
                {
                    ovi = Ovi.Kiinni;
                }
            }
        }
    }
}
