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

        public override List<Position> GetPossibleMoves(Node node)
        {
            List<Position> possibleMoves = new List<Position>();

            if(Color == Color.Black)
            {
                Position position = new Position(Position.X, Position.Y + 1);
                if (node.IsMoveablePawn(position)){
                    possibleMoves.Add(position);

                    position = new Position(Position.X, Position.Y + 2);
                    if (Position.Y == 1 && node.IsMoveablePawn(position))
                    {
                        possibleMoves.Add(position);
                    }
                }

                try
                {
                    position = new Position(Position.X + 1, Position.Y + 1);

                    if (node.IsMoveablePawn(position, Color.Black))
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

                    if (node.IsMoveablePawn(position, Color.Black))
                    {
                        possibleMoves.Add(position);
                    }
                }
                catch
                {

                }

            }
            else
            {
                Position position = new Position(Position.X, Position.Y - 1);
                if (node.IsMoveablePawn(position))
                {
                    possibleMoves.Add(position);

                    position = new Position(Position.X, Position.Y - 2);
                    if (Position.Y == 6 && node.IsMoveablePawn(position))
                    {
                        possibleMoves.Add(position);
                    }
                }

                position = new Position(Position.X + 1, Position.Y - 1);

                if (node.IsMoveablePawn(position, Color.White))
                {
                    possibleMoves.Add(position);
                }

                position = new Position(Position.X - 1, Position.Y - 1);

                if (node.IsMoveablePawn(position, Color.White))
                {
                    possibleMoves.Add(position);
                }
            }

            return possibleMoves;
        }
        public override string PieceType()
        {
            return "pawn";
        }
    }
}
