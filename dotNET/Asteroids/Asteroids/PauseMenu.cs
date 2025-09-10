using RayGuiCreator;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	internal class PauseMenu
	{
		public event EventHandler? BackButtonPressedEvent;
		public event EventHandler<Program.GameState>? StateButtonPressedEvent;

		public void DrawMenu()
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.DarkGray);
			MenuCreator pauseMenu = new MenuCreator(50, 50, 20, 200);
			pauseMenu.Label("Paused");
			if (pauseMenu.Button("Back to game"))
			{
				BackButtonPressedEvent?.Invoke(this, EventArgs.Empty);
			}
			if (pauseMenu.Button("Options"))
			{
				StateButtonPressedEvent?.Invoke(this, Program.GameState.OptionsMenu);
			}
			if (pauseMenu.Button("Quit to main menu"))
			{
				StateButtonPressedEvent?.Invoke(this, Program.GameState.MainMenu);
			}
			Raylib.EndDrawing();
		}
	}
}