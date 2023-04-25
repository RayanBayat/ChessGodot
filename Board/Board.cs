using Godot;
using System;
using System.Collections.Generic;

public partial class Board : TileMap
{
    private const int TotalTiles = 8;
    private const int TileSize = 50;
    private const int InitialX = 25;
    private const int InitialY = 25;
    private Dictionary<int, Vector2> theBoardCoordinates = new Dictionary<int, Vector2>();

    public override void _Ready()
    {
		setupBoard();
    }

	private void setupBoard()
	{
		int X = InitialX, Y = InitialY;
        for (int i = 1; i <= TotalTiles; i++)
        {
			for (int j = 1; j <= TotalTiles; j++)
			{
            Vector2 coordinate = new Vector2(X, Y);
            theBoardCoordinates.Add(((i-1)*TotalTiles)+j, coordinate);

            X += TileSize;
            
			// GD.Print("square " + i + "position " + coordinate.X + " " + coordinate.Y);
			}
			Y += TileSize;
			X = InitialX;
        }
	}
	public Vector2 getCoordPos(int num)
	{
		Vector2 value;
		theBoardCoordinates.TryGetValue(num, out value);
		return value;
	}

	public string numtoname(int num)
	{
		if (num > 0 && num <= 64)
		{
			int tmprow = (num-1) % 8;
			
			char row = (char)('a' + tmprow );
			int tmpcol = (num - tmprow) / 8;
			int col = 8 - tmpcol;
			string result = row.ToString() + col.ToString();
			return result;
		}
		return null;

	}

	public int nametonum(string name)
	{
		int row = name[0] - 'a'+1;
		int col = (8 - (name[1] - '0')) * 8;
		
		return col + row;
	}
}
