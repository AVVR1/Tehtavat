using ClassLibrary1;
using Raylib_cs;
using System.Numerics;
using RayGuiCreator;

namespace Asteroids
{
	internal class Program
	{
        static void Main(string[] args)
		{
			Program game = new Program();
			game.Init();
		}

		PauseMenu? myPauseMenu;
		OptionsMenu? myOptionsMenu;

		public enum GameState { GameLoop, MainMenu, PauseMenu, OptionsMenu };

		GameState state;

		private Stack<GameState> stateStack = new Stack<GameState>();

		Color color = Color.Black;

		Player? player;

        void Init()
		{
			Raylib.InitWindow(800, 600, "ASTEROIDS");
			Raylib.SetExitKey(KeyboardKey.Null);

			state = GameState.MainMenu;
			stateStack.Push(GameState.MainMenu);

			myOptionsMenu = new OptionsMenu();
			myPauseMenu = new PauseMenu();

			player = new Player();

			myOptionsMenu.BackButtonPressedEvent += OnStateReturn;
			myOptionsMenu.StateButtonPressedEvent += OnStateChange;
			myPauseMenu.BackButtonPressedEvent += OnStateReturn;
			myPauseMenu.StateButtonPressedEvent += OnStateChange;
			Start();
			//kaikki ladattu --> Gameloop
			GameLoop();
		}

		void Start()
		{
			AsteroidManager.InitTextures();
			Bullet.InitTexture();
			Ufo.InitTexture();
			player.texture = Raylib.LoadTexture("Images/playerShip2_blue.png");
        }

		void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
				switch (state)
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
					Update();
					Draw();
					break;
				}
			}
			Raylib.UnloadTexture(player.texture);
			AsteroidManager.UnloadTextures();
			Raylib.CloseWindow();
		}

		void Update()
		{
			player.Update();
			AsteroidManager.UpdateAsteroids();
			Bullet.UpdateBullets();
			Ufo.UpdateUfos();		
			Ufo.SpawnTimer(player.position);
			CollisionManager.CheckCollisions();
			AsteroidManager.CheckForNextWave(player.position);

			if (Raylib.IsKeyPressed(KeyboardKey.Escape))
			{
				ChangeState(GameState.PauseMenu);
			}

			if (player.RestartTimer())
			{
				ResetData();
				Program game = new Program();
				game.Init();
			}
		}

		void Draw()
		{
			Raylib.ClearBackground(Color.Black);
			Raylib.BeginDrawing();

			Bullet.DrawBullets();
			Ufo.DrawUfos();
			AsteroidManager.DrawAsteroids();
			Raylib.DrawText($"Points: {player.points}", 10, 5, 20, Color.White);
			Raylib.DrawText($"Lives: ", 10, 30, 20, Color.White); Raylib.DrawText($"{player.lives}", 70, 30, 20, Color.Red);
			if (player.isAlive)
			{
				if (player.drawTexture)
				{
					player.Draw();
				}
			}
			else
            {
                Raylib.DrawText("GAME OVER", 250, 275, 50, Color.Red);
            }

			Raylib.EndDrawing();
        }

		private void DrawMainMenu()
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(color);
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
				return;
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

		private void ResetData()
		{
			AsteroidManager.difficulty = 0;
			CollisionManager.collidables.Clear();
			AsteroidManager.asteroids.Clear();
			Ufo.ufoList.Clear();
			Bullet.bullets.Clear();
		}
	}
}