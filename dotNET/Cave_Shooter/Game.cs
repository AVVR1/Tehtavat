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
		private Map map;
		private List<Player> players;
		private Keybinds[] playerKeybinds =
		[
			new Keybinds(KeyboardKey.W, KeyboardKey.S, KeyboardKey.E, KeyboardKey.A, KeyboardKey.D),
			new Keybinds(KeyboardKey.Up, KeyboardKey.Down, KeyboardKey.PageDown, KeyboardKey.Left, KeyboardKey.Right),
			new Keybinds(GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown,GamepadButton.RightFaceDown),
			new Keybinds(GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown, GamepadButton.RightFaceDown)
		];
		private int playerCount;
		private BulletManager bulletManager;

		public DebugView debugView;
		
        public Game()
		{
			players = new List<Player>();
			debugView = new DebugView();
			map = new Map("Images/Map.png");
			bulletManager = new BulletManager(map);
		}

		public void Init(int playerCount)
		{
			//Create players
			this.playerCount = playerCount;
			players = new List<Player>();
			for (int i = 0; i < playerCount; i++)
			{
				//TODO: add selected weapon
				players.Add(new Player(new Weapon(), new Keyboard(playerKeybinds[i])));
				players[i].CalculateSplitscreenSize(16/9, playerCount+1, i); // Calculate split screen sizes
				players[i].InitCamera();
				players[i].currentMap = map;
				players[i].OnShoot += ShootBullet;

				// add game for testing purposes
				players[i].testGame = this;
			}
			// init debug camera
			debugView.camera.Offset = new Vector2(debugView.screenCameraTexture.Texture.Width / 2, debugView.screenCameraTexture.Texture.Height / 2);
			debugView.CalculateSplitscreenSize(16 / 9, playerCount+1, playerCount);

			map.MapDrawRectangle(new Rectangle(-50,400,400,50), Material.Terrain.Color);
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
			bulletManager.UpdateBullets();
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
			DrawDebug();
			Raylib.DrawRectangleRec(debugView.splitScreenRect, Color.Blue);
			
			DrawUI();
		}

		private void ShootBullet(Vector2 position, Vector2 direction)
		{
			bulletManager.NewBullet(position, direction);
			Console.WriteLine("SHOOOOOT");
		}

		private void DrawScene(Player player)
		{
			Raylib.BeginTextureMode(player.screenCameraTexture);
			Raylib.BeginMode2D(player.camera);
			Raylib.ClearBackground(Color.Black);
			// Draw map
			map.Draw();
			// Draw players
			bulletManager.DrawBullets();
			foreach (Player subject in players)
			{
				subject.DrawPlayer();
			}
			Raylib.EndMode2D();
			Raylib.EndTextureMode();

			Raylib.DrawTextureRec(player.screenCameraTexture.Texture, new Rectangle(Vector2.Zero, player.splitScreenRect.Size), player.splitScreenRect.Position, Color.White);
		}

		private void DrawDebug()
		{
			Raylib.BeginTextureMode(debugView.screenCameraTexture);
			Raylib.BeginMode2D(debugView.camera);
			Raylib.ClearBackground(Color.Black);
			map.Draw();
			Raylib.EndMode2D();
			Raylib.EndTextureMode();

			Raylib.DrawTextureRec(debugView.screenCameraTexture.Texture, new Rectangle(Vector2.Zero, debugView.splitScreenRect.Size), debugView.splitScreenRect.Position, Color.White);
			debugView.DrawDebugUI();
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