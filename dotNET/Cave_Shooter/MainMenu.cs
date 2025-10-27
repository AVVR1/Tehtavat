using RayGuiCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class MainMenu
	{
		public event EventHandler? BackButtonPressedEvent;
		public event EventHandler<GameState>? StateButtonPressedEvent;
		internal void DrawMenu()
		{
			MenuCreator mainMenu = new MenuCreator(50, 50, 20, 200);
			mainMenu.Label("Main Menu");

			if (mainMenu.Button("Start Game"))
			{
				StateButtonPressedEvent?.Invoke(this, GameState.GameLoop);
			}

			if (mainMenu.Button("Player Setup"))
			{
				StateButtonPressedEvent?.Invoke(this, GameState.PlayerSetupMenu);
			}

			if (mainMenu.Button("Options"))
			{
				StateButtonPressedEvent?.Invoke(this, GameState.OptionsMenu);
			}

			if (mainMenu.Button("Exit"))
			{
				//Close game logic
			}
		}
	}
}
