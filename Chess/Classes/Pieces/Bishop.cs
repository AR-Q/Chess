using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Position position, Color color) : base(position, color)
        {

        }

        public override List<Position> GetPossibleMoves(Node node, string[,] board)
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

            int x = Position.X + 1;
            int y = Position.Y + 1;

            while (x <= 7 && y <= 7)
            {
                Position position = new Position(x, y);
                if (node.IsMoveable(position, oposite, board) == State.Possible)
                {
                    possibleMoves.Add(position);
                    x++;
                    y++;
                }
                else if (node.IsMoveable(position, oposite, board) == State.Take)
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
                if (node.IsMoveable(position, oposite, board) == State.Possible)
                {
                    possibleMoves.Add(position);
                    x++;
                    y--;
                }
                else if (node.IsMoveable(position, oposite, board) == State.Take)
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
                if (node.IsMoveable(position, oposite, board) == State.Possible)
                {
                    possibleMoves.Add(position);
                    x--;
                    y++;
                }
                else if (node.IsMoveable(position, oposite, board) == State.Take)
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
                if (node.IsMoveable(position, oposite, board) == State.Possible)
                {
                    possibleMoves.Add(position);
                    x--;
                    y--;
                }
                else if (node.IsMoveable(position, oposite, board) == State.Take)
                {
                    possibleMoves.Add(position);
                    break;
                }
                else
                {
                    break;
                }
            }

            if (possibleMoves.Count != 0 && node.Check)
            {
                string p;
                if (Color == Color.Black)
                {
                    p = "b";
                }
                else
                {
                    p = "B";
                }
                possibleMoves = node.CheckMove(this, possibleMoves,p);
            }

            return possibleMoves;
        }

        public override string PieceType()
        {
            return "bishop";
        }
    }
}
