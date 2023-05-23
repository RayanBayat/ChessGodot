using System;
using Godot;
using System.Collections.Generic;

namespace piece
{
    public class Piece
    {
        private int _position; // Note: Removed the underscore before "position" as it was causing a syntax error
		private int _value;
		private List<int> _allowedblocks = new List<int>();
		private bool _isblack;


		public int Position { get { return _position; } set { _position = value; } }
		public int Value { get { return _value; } set { _value = value; } }
		public List<int> AllowedBlocks { get { return _allowedblocks; } set { _allowedblocks = value; } }
		public bool IsBlack { get { return _isblack; } set { _isblack = value; } }



		public virtual void calculateAllowedMoves(){}
    }

	public class Pawn : Piece 
	{
		private bool _hasmoved;
		public bool HasMoved { get { return _hasmoved; } set { _hasmoved = value; } }

		public Pawn(int pos, bool isB)
		{
			base.Position = pos;
			base.IsBlack = isB;
			base.Value = 1;
			HasMoved = false;
		}

		public override void calculateAllowedMoves()
		{
			base.AllowedBlocks.Add(1);
		}
	}
}
