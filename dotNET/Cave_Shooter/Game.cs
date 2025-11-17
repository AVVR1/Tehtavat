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

		private Map map;

        public Game()
		{
			players = new List<Player>();
			map = new Map("Images/Map.png");
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
				players[i].CalculateSplitscreenSize(16/9, playerCount, i); // Calculate split screen sizes
				players[i].InitCamera();
			}
			//map.MapDrawCircle(new Vector2(map.texture.Width / 2, 0), 100, Material.Terrain.Color);
			map.MapDrawRectangle(new Rectangle(200,200,100,100), Material.Terrain.Color);
			map.UpdateTexture();
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
			foreach (Player player in players)
			{
				player.Update();
			}
		}

		internal void Draw()
		{
			foreach (Player player in players)
			{
				DrawScene(player);
            }
			DrawUI();
		}

		private void DrawScene(Player player)
		{
			Raylib.BeginTextureMode(player.screenCameraTexture);
			Raylib.BeginMode2D(player.camera);
			Raylib.ClearBackground(Color.Black);
			// Draw map
			map.Draw();
			// Draw players
			foreach (Player subject in players)
			{
				subject.DrawPlayer();
			}
			Raylib.EndMode2D();
			Raylib.EndTextureMode();

			Raylib.DrawTextureRec(player.screenCameraTexture.Texture, new Rectangle(Vector2.Zero, player.splitScreenRect.Size), player.splitScreenRect.Position, Color.White);
		}

		private void DrawUI()
		{

		}

		private void InitTextures()
		{
			Player.InitTexture();
		}
	}
}