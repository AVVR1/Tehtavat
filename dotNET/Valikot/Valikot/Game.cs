using Raylib_cs;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using RayGuiCreator;
using System.Collections.Concurrent;
using ZeroElectric.Vinculum.Extensions;

namespace Valikot
{
	internal class Game
	{

		PauseMenu? myPauseMenu;
		OptionsMenu? myOptionsMenu;
		public enum GameState { GameLoop, MainMenu, PauseMenu, OptionsMenu };

		Stack<GameState> stateStack = new Stack<GameState>();

		GameState state;

		Vector2 direction = new Vector2(1, -1);

		float speed = 100.0f;

		float speedIncrease = 5f;

		Color color = Color.Yellow;
		

		Vector2 textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), "DVD", 20, 1);

		Vector2 pos;

		int screenWidth = 1080;
		int screenHeight = 720;

		public void Init()
		{
			Raylib.InitWindow(screenWidth, screenHeight, "VALIKOT");

			Raylib.SetExitKey(KeyboardKey.Null);

			state = GameState.MainMenu;
			stateStack.Push(GameState.MainMenu);

			pos = new Vector2(screenWidth / 2 - textSize.X / 2, screenHeight / 2 - textSize.Y / 2);

			myOptionsMenu = new OptionsMenu();
			myPauseMenu = new PauseMenu();

			myOptionsMenu.BackButtonPressedEvent += OnStateReturn;
			myOptionsMenu.StateButtonPressedEvent += OnStateChange;
			myPauseMenu.BackButtonPressedEvent += OnStateReturn;
			myPauseMenu.StateButtonPressedEvent += OnStateChange;
		}
		public void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
				switch(state)
				{
					case GameState.OptionsMenu:
						myOptionsMenu?.DrawMenu();
						break;

					case GameState.PauseMenu:
						myPauseMenu?.DrawMenu();
						break;

					case GameState.MainMenu:
						DrawMainMenu();
						break;

					case GameState.GameLoop:
						UpdateGame();
						DrawGame();
						break;
				}
			}
			Raylib.CloseWindow();
		}
		private void UpdateGame()
		{
			#region ehdot
			if (pos.X + textSize.X > screenWidth)
			{
				pos.X = screenWidth - textSize.X;
				direction.X = -direction.X;
				Collision();
			}
			if (pos.X < 0)
			{
				pos.X = 0;
				direction.X = -direction.X;
				Collision();
			}
			if (pos.Y + textSize.Y > screenHeight)
			{
				pos.Y = screenHeight - textSize.Y;
				direction.Y = -direction.Y;
				Collision();
			}
			if (pos.Y < 0)
			{
				pos.Y = 0;
				direction.Y = -direction.Y;
				Collision();
			}
			#endregion
			pos += direction * speed * Raylib.GetFrameTime();
			MenuCreator gameMenu = new MenuCreator(50, 50, 20, 200);

			if (Raylib.IsKeyPressed(KeyboardKey.Escape))
			{
				ChangeState(GameState.PauseMenu);
			}

		}
		private void DrawGame()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();
			Raylib.DrawText("DVD", ((int)pos.X), ((int)pos.Y), 20, color);
			Raylib.EndDrawing();
		}
		private void DrawMainMenu()
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Gold);
			MenuCreator mainMenu = new MenuCreator(50, 50, 20, 200);
			mainMenu.Label("Main Menu");
			mainMenu.Label("Instructions");
			if (mainMenu.Button("Start Game"))
			{
				ChangeState(GameState.GameLoop);
			}
			if (mainMenu.Button("Options"))
			{
				ChangeState(GameState.OptionsMenu);
			}
			if (mainMenu.Button("Exit"))
			{
				Raylib.CloseWindow();
			}
			Raylib.EndDrawing();
		}
		private void OnStateChange(object? sender, GameState nextState)
		{
			ChangeState(nextState);
		}
		private void OnStateReturn(object? sender, EventArgs e)
		{
			ReturnToPreviousState();
		}
		public void ChangeState(GameState nextState)
		{
			switch (nextState)
			{
				case GameState.GameLoop:
					
				break;

				case GameState.PauseMenu:

				break;

				case GameState.OptionsMenu:

				break;

				case GameState.MainMenu:

				break;
			}
			stateStack.Push(nextState);
			state = nextState;
		}
		private void ReturnToPreviousState()
		{
			stateStack.Pop();
			if (state == GameState.MainMenu)
			{
				stateStack.Clear();
			}
			state = stateStack.Peek();
		}
		private void Collision()
		{
			speed += speedIncrease;
			color = Raylib.ColorFromHSV(Raylib.GetRandomValue(0, 360), 1, 1);
		}
	}
}
