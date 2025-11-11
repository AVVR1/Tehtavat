using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class Game
	{
		private Keybinds[] playerKeybinds =
		[
			new Keybinds(KeyboardKey.W, KeyboardKey.S, KeyboardKey.E, KeyboardKey.A, KeyboardKey.D),
			new Keybinds(KeyboardKey.Up, KeyboardKey.Down, KeyboardKey.PageDown, KeyboardKey.Left, KeyboardKey.Right),
			new Keybinds(GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown,GamepadButton.RightFaceDown),
			new Keybinds(GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown)
		];

		private int playerCount;
		private List<Player> players;

        // Camera

        private List<Camera2D> cameras;
        private List<RenderTexture2D> screenCameras;
        private List<Rectangle> splitScreenRects;
        private List<Vector2> splitScreenPositions;

        public Game()
		{
			players = new List<Player>();
			cameras = new List<Camera2D>();
			screenCameras = new List<RenderTexture2D>();
			splitScreenRects = new List<Rectangle>();
			splitScreenPositions = new List<Vector2>();
		}

		public void Init(int playerCount)
		{
			//Create players
			this.playerCount = playerCount;
			players = new List<Player>();
			for (int i = 0; i < playerCount; i++)
			{
				//TODO: add selected weapon and Input device;
				players.Add(new Player(new Weapon(), new Keyboard(playerKeybinds[i])));
				CalculateSplitscreenSize(16/9, playerCount, i); // Calculate split screen sizes
				InitCamera(i);
			}
		}

        public void InitCamera(int index)
        {
			Camera2D cam = cameras[index];
			cam.Offset = new Vector2(screenCameras[index].Texture.Width / 2, screenCameras[index].Texture.Height / 2);
			cam.Zoom = 1;
            cam.Rotation = 0;
			cameras[index] = cam;
        }

        public void CalculateSplitscreenSize(float preferredRatio, int playerCount, int playerIndex)
        {
            int w = Raylib.GetScreenWidth();
            int h = Raylib.GetScreenHeight();
            float targetAspect = w / h / preferredRatio;
            int rows = (int)MathF.Round(MathF.Sqrt(playerCount / targetAspect));
            int columns = (int)MathF.Ceiling((float)playerCount / rows);
            int splitScreenWidth = w / columns;
            int splitScreenHeight = h / rows;
            int splitScreenX = playerIndex % columns * splitScreenWidth;
            int splitScreenY = (int)(MathF.Ceiling(playerIndex / columns) * splitScreenHeight);
			splitScreenRects[playerIndex] = new Rectangle(0, 0, splitScreenWidth, -splitScreenHeight);
			splitScreenPositions[playerIndex] = new Vector2(splitScreenX, splitScreenY);
			screenCameras[playerIndex] = Raylib.LoadRenderTexture(splitScreenWidth, splitScreenHeight);
        }

        public void Start()
		{
			InitTextures();
			//Create map

		}

		private void Stop()
		{
			//Unload textures
			//Reset variables
			//Exit
		}

		internal void Update()
		{
			for (int i = 0; i < players.Count; i++)
			{
				players[i].Update(cameras[i]);
			}
		}

		internal void Draw()
		{
            for (int i = 0; i < players.Count; i++)
            {
				Raylib.BeginTextureMode(screenCameras[i]);
				Raylib.BeginMode2D(cameras[i]);
				players[i].Draw(players);
                Raylib.EndMode2D();
                Raylib.EndTextureMode();
				Raylib.DrawTextureRec(screenCameras[i].Texture, splitScreenRects[i], splitScreenPositions[i], Color.White);
            }
		}

		private void InitTextures()
		{
			Player.InitTexture();
		}
	}
}