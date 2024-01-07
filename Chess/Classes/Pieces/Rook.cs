using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    public class Rook : Piece
    {
        public Rook(Position position, Color color) : base(position, color)
        {

        }
        public override List<Position> GetPossibleMoves(Node node)
        {
            List<Position> possibleMoves = new List<Position>();

            Color oposite;

            if(Color == Color.White)
            {
                oposite = Color.Black;
            }
            else
            {
                oposite = Color.White;
            }

            for(int i = Position.X + 1; i <= 7; i++)
            {
                Position position = new Position(i, Position.Y);
                if(node.IsMoveable(position,oposite) == State.Possible)
                {
                    possibleMoves.Add(position);
                }
                else if(node.IsMoveable(position, oposite) == State.Take)
                {
                    possibleMoves.Add(position);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = Position.X - 1; i >= 0; i--)
            {
                Position position = new Position(i, Position.Y);
                if (node.IsMoveable(position, oposite) == State.Possible)
                {
                    possibleMoves.Add(position);
                }
                else if (node.IsMoveable(position, oposite) == State.Take)
                {
                    possibleMoves.Add(position);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = Position.Y + 1; i <= 7; i++)
            {
                Position position = new Position(Position.X, i);
                if (node.IsMoveable(position, oposite) == State.Possible)
                {
                    possibleMoves.Add(position);
                }
                else if (node.IsMoveable(position, oposite) == State.Take)
                {
                    possibleMoves.Add(position);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = Position.Y - 1; i >= 0; i--)
            {
                Position position = new Position(Position.X, i);
                if (node.IsMoveable(position, oposite) == State.Possible)
                {
                    possibleMoves.Add(position);
                }
                else if (node.IsMoveable(position, oposite) == State.Take)
                {
                    possibleMoves.Add(position);
                    break;
                }
                else
                {
                    break;
                }
            }

            return possibleMoves;
        }

        public override string PieceType()
        {
            return "rook";
        }
    }
}
