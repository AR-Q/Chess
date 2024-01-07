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

        public override List<Position> GetPossibleMoves(Node node)
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
                if (node.IsMoveable(position, oposite) != State.Impossible)
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
                if (node.IsMoveable(position, oposite) != State.Impossible)
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
                if (node.IsMoveable(position, oposite) != State.Impossible)
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
                if (node.IsMoveable(position, oposite) != State.Impossible)
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
                if (node.IsMoveable(position, oposite) != State.Impossible)
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
                if (node.IsMoveable(position, oposite) != State.Impossible)
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
                if (node.IsMoveable(position, oposite) != State.Impossible)
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
                if (node.IsMoveable(position, oposite) != State.Impossible)
                {
                    possibleMoves.Add(position);
                }
            }
            catch
            {

            }



            return possibleMoves;
        }

        public override string PieceType()
        {
            return "knight";
        }
    }
}
