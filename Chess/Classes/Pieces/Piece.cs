using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    public abstract class Piece
    {
        public Color Color { get; set; }
        public Position Position { get; set; }

        public Piece(Position position, Color color)
        {
            Position = position;
            Color = color;
        }

        public abstract List<Position> GetPossibleMoves(Node node, string[,] board);

        public abstract string PieceType();
    }
}
