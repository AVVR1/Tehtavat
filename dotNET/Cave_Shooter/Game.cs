using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class Game
	{
		private int playerCount;
		private List<Player> players;

		public Game()
		{
			players = new List<Player>();
		}

		public void Init(int playerCount)
		{
			//Create players
			this.playerCount = playerCount;
			players = new List<Player>();
			for (int i = 0; i < playerCount; i++)
			{
				//TODO: add selected weapon and Input device;
				players.Add(new Player(new Weapon(), new Keyboard()));
			}
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
			foreach (Player p in players)
			{
				p.Update();
			}
		}

		internal void Draw()
		{
			foreach (Player p in players)
			{
				p.Draw();
			}
		}

		private void InitTextures()
		{
			Player.InitTexture();
		}
	}
}