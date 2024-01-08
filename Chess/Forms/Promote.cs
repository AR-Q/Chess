using Chess.Classes;
using Chess.Classes.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Forms
{
    public partial class Promote : Form
    {
        Main father;
        Classes.Color Color;
        Position Position;
        int x, y;
        string castle;
        public Promote(Main main, Classes.Color color, Position position, int x, int y, string castle)
        {
            InitializeComponent();

            if(color == Classes.Color.White)
            {
                btnQueen.Image = global::Chess.Properties.Resources.queen_w;
                btnRook.Image = global::Chess.Properties.Resources.rook_w;
                btnKnight.Image = global::Chess.Properties.Resources.knight_w;
                btnBishop.Image = global::Chess.Properties.Resources.bishop_w;
            }
            else
            {
                btnQueen.Image = global::Chess.Properties.Resources.queen_b;
                btnRook.Image = global::Chess.Properties.Resources.rook_b;
                btnKnight.Image = global::Chess.Properties.Resources.knight_b;
                btnBishop.Image = global::Chess.Properties.Resources.bishop_b;
            }

            father = main;
            Color = color;
            Position = position;
            this.x = x;
            this.y = y;
            this.castle = castle;
        }

        private void btnQueen_Click(object sender, EventArgs e)
        {
            Piece piece = new Queen(Position, Color);
            father.promotePiece = piece;
            father.Promote(x, y, castle);
            this.Dispose();
        }

        private void btnRook_Click(object sender, EventArgs e)
        {
            Piece piece = new Rook(Position, Color);
            father.promotePiece = piece;
            father.Promote(x, y, castle);
            this.Dispose();
        }

        private void btnKnight_Click(object sender, EventArgs e)
        {
            Piece piece = new Knight(Position, Color);
            father.promotePiece = piece;
            father.Promote(x, y, castle);
            this.Dispose();
        }

        private void btnBishop_Click(object sender, EventArgs e)
        {
            Piece piece = new Bishop(Position, Color);
            father.promotePiece = piece;
            father.Promote(x, y, castle);
            this.Dispose();
        }
    }
}
