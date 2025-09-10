using RayGuiCreator;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valikot
{
	internal class PauseMenu
	{
		public event EventHandler? BackButtonPressedEvent;
		public event EventHandler<Game.GameState>? StateButtonPressedEvent;

		public void DrawMenu()
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Gray);
			MenuCreator pauseMenu = new MenuCreator(50, 50, 20, 200);
			pauseMenu.Label("Paused");
			if (pauseMenu.Button("Back to game"))
			{
				BackButtonPressedEvent?.Invoke(this, EventArgs.Empty);
			}
			if (pauseMenu.Button("Options"))
			{
				StateButtonPressedEvent?.Invoke(this, Game.GameState.OptionsMenu);
			}
			if (pauseMenu.Button("Quit to main menu"))
			{
				StateButtonPressedEvent?.Invoke(this, Game.GameState.MainMenu);
			}
			Raylib.EndDrawing();
		}
	}
}