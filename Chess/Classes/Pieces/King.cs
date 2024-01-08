using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    public class King : Piece
    {
        public King(Position position, Color color) : base(position, color)
        {

        }
        public override List<Position> GetPossibleMoves(Node node, string[,] board, bool CheckContol)
        {
            List<Position> possibleMoves = new List<Position>();

            Color oposite;

            if (Color == Color.White)
            {
                oposite = Color.Black;
            }
            else
            {
                oposite = Color.White;
            }

            Position position;

            try
            {
                position = new Position(Position.X + 1,Position.Y);
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
                position = new Position(Position.X + 1, Position.Y + 1);
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
                position = new Position(Position.X, Position.Y + 1);
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
                position = new Position(Position.X - 1, Position.Y + 1);
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
                position = new Position(Position.X - 1, Position.Y);
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
                position = new Position(Position.X - 1, Position.Y - 1);
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
                position = new Position(Position.X, Position.Y - 1);
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
                position = new Position(Position.X + 1, Position.Y - 1);
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
                    p = "k";
                }
                else
                {
                    p = "K";
                }
                possibleMoves = node.CheckMove(this, possibleMoves,p);
            }
            else if (possibleMoves.Count != 0 && CheckContol)
            {
                string p;
                if (Color == Color.Black)
                {
                    p = "k";
                }
                else
                {
                    p = "K";
                }
                possibleMoves = node.CheckMovePossible(this, possibleMoves, p);
            }

            return possibleMoves;
        }

        public override string PieceType()
        {
            return "king";
        }
    }
}
