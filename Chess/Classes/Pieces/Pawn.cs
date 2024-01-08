using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Position position, Color color) : base(position, color)
        {

        }

        public override List<Position> GetPossibleMoves(Node node, string[,] board, bool CheckContol)
        {
            List<Position> possibleMoves = new List<Position>();

            if(Color == Color.Black)
            {
                Position position;

                try
                {
                    position = new Position(Position.X, Position.Y + 1);
                    if (node.IsMoveablePawn(position,board))
                    {
                        possibleMoves.Add(position);

                        position = new Position(Position.X, Position.Y + 2);
                        if (Position.Y == 1 && node.IsMoveablePawn(position,board))
                        {
                            possibleMoves.Add(position);
                        }
                    }
                }
                catch
                {

                }
                

                try
                {
                    position = new Position(Position.X + 1, Position.Y + 1);

                    if (node.IsMoveablePawn(position, Color.White, board))
                    {
                        possibleMoves.Add(position);
                    }

                    if (node.EnPassant != "-")
                    {
                        int x = node.EnPassant[0] - 48;
                        int y = node.EnPassant[1] - 48;

                        if (x == position.X && y == position.Y)
                        {
                            possibleMoves.Add(position);
                        }
                    }
                }
                catch
                {

                }

                try
                {
                    position = new Position(Position.X - 1, Position.Y + 1);

                    if (node.IsMoveablePawn(position, Color.White, board))
                    {
                        possibleMoves.Add(position);
                    }

                    if (node.EnPassant != "-")
                    {
                        int x = node.EnPassant[0] - 48;
                        int y = node.EnPassant[1] - 48;

                        if (x == position.X && y == position.Y)
                        {
                            possibleMoves.Add(position);
                        }
                    }
                }
                catch
                {

                }

                

            }
            else
            {
                Position position;

                try
                {
                    position = new Position(Position.X, Position.Y - 1);
                    if (node.IsMoveablePawn(position,board))
                    {
                        possibleMoves.Add(position);

                        position = new Position(Position.X, Position.Y - 2);
                        if (Position.Y == 6 && node.IsMoveablePawn(position,board))
                        {
                            possibleMoves.Add(position);
                        }
                    }
                }
                catch
                {

                }


                try
                {
                    position = new Position(Position.X + 1, Position.Y - 1);

                    if (node.IsMoveablePawn(position, Color.Black,board))
                    {
                        possibleMoves.Add(position);
                    }

                    if (node.EnPassant != "-")
                    {
                        int x = node.EnPassant[0] - 48;
                        int y = node.EnPassant[1] - 48;

                        if (x == position.X && y == position.Y)
                        {
                            possibleMoves.Add(position);
                        }
                    }
                }
                catch
                {

                }

                try
                {
                    position = new Position(Position.X - 1, Position.Y - 1);

                    if (node.IsMoveablePawn(position, Color.Black,board))
                    {
                        possibleMoves.Add(position);
                    }

                    if (node.EnPassant != "-")
                    {
                        int x = node.EnPassant[0] - 48;
                        int y = node.EnPassant[1] - 48;

                        if (x == position.X && y == position.Y)
                        {
                            possibleMoves.Add(position);
                        }
                    }
                }
                catch
                {

                }
            }

            if(possibleMoves.Count != 0 && node.Check)
            {
                string p;
                if(Color == Color.Black)
                {
                    p = "p";
                }
                else
                {
                    p = "P";
                }
                possibleMoves = node.CheckMove(this, possibleMoves,p);
            }
            else if (possibleMoves.Count != 0 && CheckContol)
            {
                string p;
                if (Color == Color.Black)
                {
                    p = "p";
                }
                else
                {
                    p = "P";
                }
                possibleMoves = node.CheckMovePossible(this, possibleMoves, p);
            }

            return possibleMoves;
        }
        public override string PieceType()
        {
            return "pawn";
        }
    }
}
