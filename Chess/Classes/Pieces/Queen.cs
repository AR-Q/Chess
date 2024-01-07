using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    public class Queen : Piece
    {
        public Queen(Position position, Color color) : base(position, color)
        {

        }
        public override List<Position> GetPossibleMoves(Node node)
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

            for (int i = Position.X + 1; i <= 7; i++)
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

            int x = Position.X + 1;
            int y = Position.Y + 1;

            while (x <= 7 && y <= 7)
            {
                Position position = new Position(x, y);
                if (node.IsMoveable(position, oposite) == State.Possible)
                {
                    possibleMoves.Add(position);
                    x++;
                    y++;
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

            x = Position.X + 1;
            y = Position.Y - 1;

            while (x <= 7 && y >= 0)
            {
                Position position = new Position(x, y);
                if (node.IsMoveable(position, oposite) == State.Possible)
                {
                    possibleMoves.Add(position);
                    x++;
                    y--;
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

            x = Position.X - 1;
            y = Position.Y + 1;

            while (x >= 0 && y <= 7)
            {
                Position position = new Position(x, y);
                if (node.IsMoveable(position, oposite) == State.Possible)
                {
                    possibleMoves.Add(position);
                    x--;
                    y++;
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

            x = Position.X - 1;
            y = Position.Y - 1;

            while (x >= 0 && y >= 0)
            {
                Position position = new Position(x, y);
                if (node.IsMoveable(position, oposite) == State.Possible)
                {
                    possibleMoves.Add(position);
                    x--;
                    y--;
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
            return "queen";
        }
    }
}
