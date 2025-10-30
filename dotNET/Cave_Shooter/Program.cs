using Raylib_cs;

namespace Cave_Shooter
{
	public enum GameState { GameLoop, MainMenu, PauseMenu, OptionsMenu, PlayerSetupMenu };

    internal class Program
    {
		Game? game;
		MainMenu? mainMenu;
		PauseMenu? pauseMenu;
		OptionsMenu? optionsMenu;
		PlayerSetup? playerSetupMenu;

		Stack<GameState> stateStack = new Stack<GameState>();
		GameState state;

		private const int SCREENWIDTH = 1280;
		private const int SCREENHEIGHT = 720;

		static void Main(string[] args)
        {
			Program program = new Program();
			program.Init();
			program.Start();
			program.GameLoop();
        }

		private void Init()
		{
			Raylib.InitWindow(SCREENWIDTH, SCREENHEIGHT, "Cave Shooter");
			Raylib.SetTargetFPS(30);
			//Raylib.ToggleFullscreen();

			state = GameState.MainMenu;
			stateStack.Push(GameState.MainMenu);
		}

		private void Start()
		{
			game = new Game();
			mainMenu = new MainMenu();
			pauseMenu = new PauseMenu();
			optionsMenu = new OptionsMenu();
			playerSetupMenu = new PlayerSetup();

			mainMenu.StateButtonPressedEvent += OnStateChange;
			pauseMenu.BackButtonPressedEvent += OnStateReturn;
			pauseMenu.StateButtonPressedEvent += OnStateChange;
			optionsMenu.BackButtonPressedEvent += OnStateReturn;
			optionsMenu.StateButtonPressedEvent += OnStateChange;
			playerSetupMenu.BackButtonPressedEvent += OnStateReturn;
			playerSetupMenu.StateButtonPressedEvent += OnStateChange;
		}

		public void GameLoop()
		{
			while (!Raylib.WindowShouldClose())
			{
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.Black);
				switch (state)
				{
					case GameState.OptionsMenu:
						optionsMenu?.DrawMenu();
						break;

					case GameState.PauseMenu:
						pauseMenu?.DrawMenu();
						break;

					case GameState.MainMenu:
						mainMenu?.DrawMenu();
						break;

					case GameState.PlayerSetupMenu:
						playerSetupMenu?.DrawMenu();
						break;

					case GameState.GameLoop:
						game?.Update();
						game?.Draw();
						break;
				}
				Raylib.EndDrawing();
			}
			Raylib.CloseWindow();
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
					game?.Init(playerSetupMenu.getPlayerCount());
					game?.Start();
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
	}
}
