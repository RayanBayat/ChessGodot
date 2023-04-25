using Godot;
using System;

public partial class pieces : Node2D
{
	PackedScene piece;

	bool isblack;

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void addPiece(char type, bool isblack, string name, Vector2 position)
	{
		
		if (setPiece(type, isblack))
		{
			setupPiece(name, position);
		}

	}

	public void movePiece(string oldname, string newname, Vector2 position)
	{
		var piece = GetNode<Node2D>(oldname);
		var otherpiece = GetNode<Node2D>(newname);
		if (piece != null)
		{
			if ( otherpiece != null)
			{
				otherpiece.QueueFree();
			}
			piece.Position = position;
			piece.Name = newname;
		}
	}
	private void setupPiece(string name, Vector2 position)
	{
		var instance = piece.Instantiate();
		instance.Name = name;
		AddChild(instance);
		var pieceobject = GetNode<Node2D>(name);
		pieceobject.Position = position;
	}


	private bool setPiece(Char n, bool isblack)
	{
		bool returnvalue = false;
		if (!isblack)
		{
			switch (n)
		{
			case 'P':
				piece = GD.Load<PackedScene>("res://Pieces/wPawn.tscn");
				returnvalue = true;
				break;
			case 'R':
				piece = GD.Load<PackedScene>("res://Pieces/wRook.tscn");
				returnvalue = true;
				break;
			case 'N':
				piece = GD.Load<PackedScene>("res://Pieces/wKnight.tscn");
				returnvalue = true;
				break;
			case 'B':
				piece = GD.Load<PackedScene>("res://Pieces/wBishop.tscn");
				returnvalue = true;
				break;
			case 'Q':
				piece = GD.Load<PackedScene>("res://Pieces/wQueen.tscn");
				returnvalue = true;
				break;
			case 'K':
				piece = GD.Load<PackedScene>("res://Pieces/wKing.tscn");
				returnvalue = true;
				break;
			default:
				piece = null;
				returnvalue = false;
				break;
		}
		} else{
			switch(n)
			{
			case 'p':
				piece = GD.Load<PackedScene>("res://Pieces/bPawn.tscn");
				returnvalue = true;
				break;
			case 'r':
				piece = GD.Load<PackedScene>("res://Pieces/bRook.tscn");
				returnvalue = true;
				break;
			case 'n':
				piece = GD.Load<PackedScene>("res://Pieces/bKnight.tscn");
				returnvalue = true;
				break;
			case 'b':
				piece = GD.Load<PackedScene>("res://Pieces/bBishop.tscn");
				returnvalue = true;
				break;
			case 'q':
				piece = GD.Load<PackedScene>("res://Pieces/bQueen.tscn");
				returnvalue = true;
				break;
			case 'k':
				piece = GD.Load<PackedScene>("res://Pieces/bKing.tscn");
				returnvalue = true;
				break;
			default:
				piece = null;
				returnvalue = false;
				break;
			}
		}	

		return returnvalue;		
		
	}
}
