using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    public class Knight : Piece
    {
        public Knight(Position position, Color color) : base(position, color)
        {

        }

        public override List<Position> GetPossibleMoves(Node node, string[,] board)
        {
            List<Position> possibleMoves = new List<Position>();
            Position position;
            Color oposite;

            if(Color == Color.White)
            {
                oposite = Color.Black;
            }
            else
            {
                oposite = Color.White;
            }

            try
            {
                position = new Position(Position.X + 1, Position.Y + 2);
                if (node.IsMoveable(position, oposite, board) != State.Impossible)
                {
                    possibleMoves.Add(position);
                }
            }
            catch
            {

            }

            try
            {
                position = new Position(Position.X - 1, Position.Y + 2);
                if (node.IsMoveable(position, oposite, board) != State.Impossible)
                {
                    possibleMoves.Add(position);
                }
            }
            catch
            {

            }

            try
            {
                position = new Position(Position.X + 1, Position.Y - 2);
                if (node.IsMoveable(position, oposite, board) != State.Impossible)
                {
                    possibleMoves.Add(position);
                }
            }
            catch
            {

            }

            try
            {
                position = new Position(Position.X - 1, Position.Y - 2);
                if (node.IsMoveable(position, oposite, board) != State.Impossible)
                {
                    possibleMoves.Add(position);
                }
            }
            catch
            {

            }

            try
            {
                position = new Position(Position.X + 2, Position.Y + 1);
                if (node.IsMoveable(position, oposite, board) != State.Impossible)
                {
                    possibleMoves.Add(position);
                }
            }
            catch
            {

            }

            try
            {
                position = new Position(Position.X + 2, Position.Y - 1);
                if (node.IsMoveable(position, oposite, board) != State.Impossible)
                {
                    possibleMoves.Add(position);
                }
            }
            catch
            {

            }

            try
            {
                position = new Position(Position.X - 2, Position.Y + 1);
                if (node.IsMoveable(position, oposite, board) != State.Impossible)
                {
                    possibleMoves.Add(position);
                }
            }
            catch
            {

            }

            try
            {
                position = new Position(Position.X - 2, Position.Y - 1);
                if (node.IsMoveable(position, oposite, board) != State.Impossible)
                {
                    possibleMoves.Add(position);
                }
            }
            catch
            {

            }

            if (possibleMoves.Count != 0 && node.Check)
            {
                string p;
                if (Color == Color.Black)
                {
                    p = "n";
                }
                else
                {
                    p = "N";
                }
                possibleMoves = node.CheckMove(this, possibleMoves,p);
            }

            return possibleMoves;
        }

        public override string PieceType()
        {
            return "knight";
        }
    }
}
