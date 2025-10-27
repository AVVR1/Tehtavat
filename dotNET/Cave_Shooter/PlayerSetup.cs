using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RayGuiCreator;
using ZeroElectric.Vinculum;

namespace Cave_Shooter
{
	internal class PlayerSetup
	{
		public event EventHandler? BackButtonPressedEvent;
		public event EventHandler<GameState>? StateButtonPressedEvent;

		float playerCount = 2;
		public void DrawMenu()
		{

			MenuCreator playerSetupMenu = new MenuCreator(50, 50, 20, 200);
			playerSetupMenu.Label("Player Setup");
			playerSetupMenu.Label("Player Count");
			playerSetupMenu.Slider("2","4", ref playerCount, 2, 4);
			playerCount = MathF.Round(playerCount,0);

			if (playerSetupMenu.Button("Back"))
			{
				BackButtonPressedEvent?.Invoke(this, EventArgs.Empty);
			}
		}

		public int getPlayerCount()
		{
			return (int)playerCount;
		}
	}
}
