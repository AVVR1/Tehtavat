namespace ConsoleApp1
{
    public enum MainCourse { nauta, kana, kasvikset }
    public enum SideDish { peruna, riisi, pasta }
    public enum Sauce { curry, hapanimelä, pippuri, chili }

    public class Ateria
    {
        public MainCourse mainCourse;
        public SideDish sideDish;
        public Sauce sauce;

        public Ateria(MainCourse mainCourse, SideDish sideDish, Sauce sauce)
        {
            this.mainCourse = mainCourse;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pääraaka-aine (");
            for (int i = 0; i < Enum.GetNames(typeof(MainCourse)).Length; i++)
            {
                Console.Write(Enum.GetNames(typeof(MainCourse)));
            }
            Console.Write("): ");
        }
    }
}
