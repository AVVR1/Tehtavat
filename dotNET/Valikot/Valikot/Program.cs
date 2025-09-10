using Raylib_cs;
using System.Runtime.CompilerServices;

namespace Valikot
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Game game = new Game();
			game.Init();
			game.GameLoop();
		}
    }
}