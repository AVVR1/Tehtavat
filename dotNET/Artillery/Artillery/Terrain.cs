using Raylib_cs;
using System.Numerics;

namespace Artillery
{
	internal class Terrain
	{
		int terrainPieceCount;
		public List<Rectangle> terrainPieces = new List<Rectangle>();
		public float terrainPieceWidth;
		public Terrain(int terrainPieceCount)
		{
			this.terrainPieceCount = terrainPieceCount;
		}
		public void Draw()
		{
			foreach (var terrainPiece in terrainPieces)
			{
				Raylib.DrawRectangleRec(terrainPiece, Color.DarkGreen);
			}
		}

		public void GenerateTerrain(int heightChangeAmount)
		{
			float pieceWidth = Raylib.GetScreenWidth() / (float)terrainPieceCount;
			Random random = new Random();
			float previousPieceHeight = 500;

			for (int i = 0; i < terrainPieceCount; i++)
			{
				float heightChange = random.Next(-heightChangeAmount, heightChangeAmount + 1);
				float newPieceHeight = previousPieceHeight + heightChange;

				if (newPieceHeight > Raylib.GetScreenHeight())
				{
					newPieceHeight = Raylib.GetScreenHeight() - 30;
				}
				terrainPieces.Add(new Rectangle(i * pieceWidth,newPieceHeight,new Vector2(pieceWidth, Raylib.GetScreenHeight() - newPieceHeight)));
				previousPieceHeight = newPieceHeight;
			}
			terrainPieceWidth = pieceWidth;
		}
	}
}
