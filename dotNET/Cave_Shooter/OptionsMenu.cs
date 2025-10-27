using RayGuiCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class OptionsMenu
	{
		public event EventHandler? BackButtonPressedEvent;
		public event EventHandler<GameState>? StateButtonPressedEvent;

		internal void DrawMenu()
		{
			MenuCreator optionsMenu = new MenuCreator(50, 50, 20, 200);
			optionsMenu.Label("Options");
			if (optionsMenu.Button("Back"))
			{
				BackButtonPressedEvent?.Invoke(this, EventArgs.Empty);
			}
			if (optionsMenu.Button("Main Menu"))
			{
				StateButtonPressedEvent?.Invoke(this, GameState.MainMenu);
			}
		}
	}
}
