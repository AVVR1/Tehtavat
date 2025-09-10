using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayGuiCreator;

namespace Valikot
{
	internal class OptionsMenu
	{
		public event EventHandler? BackButtonPressedEvent;
		public event EventHandler<Game.GameState>? StateButtonPressedEvent;

		public void DrawMenu()
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.DarkBlue);
			MenuCreator optionsMenu = new MenuCreator(50, 50, 20, 200);
			optionsMenu.Label("Options");
			if (optionsMenu.Button("Back"))
			{
				BackButtonPressedEvent?.Invoke(this, EventArgs.Empty);
			}
			if (optionsMenu.Button("Main Menu"))
			{
				StateButtonPressedEvent?.Invoke(this, Game.GameState.MainMenu);
			}
			Raylib.EndDrawing();
		}
	}
}
