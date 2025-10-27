using RayGuiCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class PauseMenu
	{
		public event EventHandler? BackButtonPressedEvent;
		public event EventHandler<GameState>? StateButtonPressedEvent;

		internal void DrawMenu()
		{
			MenuCreator pauseMenu = new MenuCreator(50, 50, 20, 200);
			pauseMenu.Label("Paused");
			if (pauseMenu.Button("Back to game"))
			{
				BackButtonPressedEvent?.Invoke(this, EventArgs.Empty);
			}
			if (pauseMenu.Button("Options"))
			{
				StateButtonPressedEvent?.Invoke(this, GameState.OptionsMenu);
			}
			if (pauseMenu.Button("Quit to main menu"))
			{
				StateButtonPressedEvent?.Invoke(this, GameState.MainMenu);
			}
		}
	}
}
