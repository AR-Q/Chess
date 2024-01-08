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

            try
            {
                if (Color == Color.White && !node.Check)
                {
                    if (node.Castle.Contains("K"))
                    {
                        if (node.Board[7, 7] == "R" && node.Board[7, 5] == "0" && node.Board[7, 6] == "0")
                        {
                            if (node.IsUnderCheck(new List<Position>() { new Position(5, 7), new Position(6, 7) }, Color.White))
                            {
                                possibleMoves.Add(new Position(6, 7));
                            }
                        }
                    }

                    if (node.Castle.Contains("Q"))
                    {
                        if (node.Board[7, 0] == "R" && node.Board[7, 1] == "0" && node.Board[7, 2] == "0" && node.Board[7, 3] == "0")
                        {
                            if (node.IsUnderCheck(new List<Position>() { new Position(1, 7), new Position(2, 7), new Position(3, 7) }, Color.White))
                            {
                                possibleMoves.Add(new Position(2, 7));
                            }
                        }
                    }
                }
                else if(Color == Color.Black && !node.Check)
                {
                    if (node.Castle.Contains("k") && !node.Check)
                    {
                        if (node.Board[0, 7] == "r" && node.Board[0, 5] == "0" && node.Board[0, 6] == "0")
                        {
                            if (node.IsUnderCheck(new List<Position>() { new Position(5, 0), new Position(6, 0) }, Color.Black))
                            {
                                possibleMoves.Add(new Position(6, 7));
                            }
                        }
                    }

                    if (node.Castle.Contains("q") && !node.Check)
                    {
                        if (node.Board[0, 0] == "r" && node.Board[0, 1] == "0" && node.Board[0, 2] == "0" && node.Board[0, 3] == "0")
                        {
                            if (node.IsUnderCheck(new List<Position>() { new Position(1, 0), new Position(2, 0), new Position(3, 0) }, Color.Black))
                            {
                                possibleMoves.Add(new Position(2, 0));
                            }
                        }
                    }
                }
            }
            catch
            {
                //
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
