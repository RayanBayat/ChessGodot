using Godot;
using System;

public partial class game : Node2D
{
	[Export]String Snippet = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

	Board board;
	// Called when the node enters the scene tree for the first time.
	// private Board board;
	public override void _Ready()
	{
		
		board = GetNode<Board>("Board");
		setUp();
		// makeMove("d7c8");
		
		// if (event.Pressed)
		// 	{
		// 		// Mouse Held
		// 		mouse_offset = Position - GetGlobalMousePosition();
		// 		selected = true;
		// 	}
	}

	public override void _Input(InputEvent @event)
	{
		// Mouse in viewport coordinates.
		if (@event is InputEventMouseButton eventMouseButton)
			GD.Print("Mouse Click/Unclick at: ", eventMouseButton.Position);
		else if (@event is InputEventMouseMotion eventMouseMotion)
			GD.Print("Mouse Motion at: ", eventMouseMotion.Position);

		// Print the size of the viewport.
		GD.Print("Viewport Resolution is: ", GetViewportRect().Size);
	}
	public void setUp()
	{
		
		int column = 1, row = 1,counter = 1;
		for (int i = 0; i < Snippet.Length; i++)
		{

			if (Snippet[i] == '/')
			{
				row = 1;
				column++;	
			}
			else if (char.IsNumber(Snippet[i]))
			{
				counter += (Snippet[i]- '0');

			}
			else if (Snippet[i] == ' ')
			{
				break;
			}
			else{
			bool isblack = char.IsLower(Snippet[i]);
			Vector2 a = board.GetNode<Board>(".").getCoordPos(counter);
			var Pieces = GetNode<Node2D>("Pieces");
			string name = board.GetNode<Board>(".").numtoname(counter);
			Pieces.GetNode<pieces>(".").addPiece(Snippet[i],isblack,name,a);
			counter++;	
			}
		}
	}


	public void makeMove(string move)
	{
		int num = board.GetNode<Board>(".").nametonum(move.Substring(2,2));
		Vector2 a = board.GetNode<Board>(".").getCoordPos(num);
		var Pieces = GetNode<Node2D>("Pieces");
		Pieces.GetNode<pieces>(".").movePiece(move.Substring(0,2),move.Substring(2,2),a);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
