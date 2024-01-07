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
    public partial class Main : Form
    {

        Game Game;
        public Button[,] Buttons;

        public Main()
        {
            InitializeComponent();
            Buttons = new Button[8, 8];
            SetButtons();
            Game = new Game(Buttons);
        }

        public void SetButtons()
        {
            Buttons[0, 0] = btn00;
            Buttons[0, 1] = btn01;
            Buttons[0, 2] = btn02;
            Buttons[0, 3] = btn03;
            Buttons[0, 4] = btn04;
            Buttons[0, 5] = btn05;
            Buttons[0, 6] = btn06;
            Buttons[0, 7] = btn07;

            Buttons[1, 0] = btn10;
            Buttons[1, 1] = btn11;
            Buttons[1, 2] = btn12;
            Buttons[1, 3] = btn13;
            Buttons[1, 4] = btn14;
            Buttons[1, 5] = btn15;
            Buttons[1, 6] = btn16;
            Buttons[1, 7] = btn17;

            Buttons[2, 0] = btn20;
            Buttons[2, 1] = btn21;
            Buttons[2, 2] = btn22;
            Buttons[2, 3] = btn23;
            Buttons[2, 4] = btn24;
            Buttons[2, 5] = btn25;
            Buttons[2, 6] = btn26;
            Buttons[2, 7] = btn27;

            Buttons[3, 0] = btn30;
            Buttons[3, 1] = btn31;
            Buttons[3, 2] = btn32;
            Buttons[3, 3] = btn33;
            Buttons[3, 4] = btn34;
            Buttons[3, 5] = btn35;
            Buttons[3, 6] = btn36;
            Buttons[3, 7] = btn37;

            Buttons[4, 0] = btn40;
            Buttons[4, 1] = btn41;
            Buttons[4, 2] = btn42;
            Buttons[4, 3] = btn43;
            Buttons[4, 4] = btn44;
            Buttons[4, 5] = btn45;
            Buttons[4, 6] = btn46;
            Buttons[4, 7] = btn47;

            Buttons[5, 0] = btn50;
            Buttons[5, 1] = btn51;
            Buttons[5, 2] = btn52;
            Buttons[5, 3] = btn53;
            Buttons[5, 4] = btn54;
            Buttons[5, 5] = btn55;
            Buttons[5, 6] = btn56;
            Buttons[5, 7] = btn57;

            Buttons[6, 0] = btn60;
            Buttons[6, 1] = btn61;
            Buttons[6, 2] = btn62;
            Buttons[6, 3] = btn63;
            Buttons[6, 4] = btn64;
            Buttons[6, 5] = btn65;
            Buttons[6, 6] = btn66;
            Buttons[6, 7] = btn67;

            Buttons[7, 0] = btn70;
            Buttons[7, 1] = btn71;
            Buttons[7, 2] = btn72;
            Buttons[7, 3] = btn73;
            Buttons[7, 4] = btn74;
            Buttons[7, 5] = btn75;
            Buttons[7, 6] = btn76;
            Buttons[7, 7] = btn77;
        }


        public void BtnClick(int x,int y)
        {
            Piece piece = Game.Pieces.FirstOrDefault(p => p.Position.X == y && p.Position.Y == x);

            if(piece != null)
            {
                List<Position> positions = piece.GetPossibleMoves(Game.ChessTree.GetCurrentNode());

                foreach (var position in positions)
                {
                    Buttons[position.Y, position.X].BackColor = System.Drawing.Color.SkyBlue;
                }
            }
        }

        private void btn00_Click(object sender, EventArgs e)
        {

        }

        private void btn01_Click(object sender, EventArgs e)
        {

        }

        private void btn02_Click(object sender, EventArgs e)
        {

        }

        private void btn03_Click(object sender, EventArgs e)
        {

        }

        private void btn04_Click(object sender, EventArgs e)
        {

        }

        private void btn05_Click(object sender, EventArgs e)
        {

        }

        private void btn06_Click(object sender, EventArgs e)
        {

        }

        private void btn07_Click(object sender, EventArgs e)
        {

        }

        private void btn10_Click(object sender, EventArgs e)
        {

        }

        private void btn11_Click(object sender, EventArgs e)
        {

        }

        private void btn12_Click(object sender, EventArgs e)
        {

        }

        private void btn13_Click(object sender, EventArgs e)
        {

        }

        private void btn14_Click(object sender, EventArgs e)
        {

        }

        private void btn15_Click(object sender, EventArgs e)
        {

        }

        private void btn16_Click(object sender, EventArgs e)
        {

        }

        private void btn17_Click(object sender, EventArgs e)
        {

        }

        private void btn20_Click(object sender, EventArgs e)
        {

        }

        private void btn21_Click(object sender, EventArgs e)
        {

        }

        private void btn22_Click(object sender, EventArgs e)
        {

        }

        private void btn23_Click(object sender, EventArgs e)
        {

        }

        private void btn24_Click(object sender, EventArgs e)
        {

        }

        private void btn25_Click(object sender, EventArgs e)
        {

        }

        private void btn26_Click(object sender, EventArgs e)
        {

        }

        private void btn27_Click(object sender, EventArgs e)
        {

        }

        private void btn30_Click(object sender, EventArgs e)
        {

        }

        private void btn31_Click(object sender, EventArgs e)
        {

        }

        private void btn32_Click(object sender, EventArgs e)
        {

        }

        private void btn33_Click(object sender, EventArgs e)
        {

        }

        private void btn34_Click(object sender, EventArgs e)
        {

        }

        private void btn35_Click(object sender, EventArgs e)
        {

        }

        private void btn36_Click(object sender, EventArgs e)
        {

        }

        private void btn37_Click(object sender, EventArgs e)
        {

        }

        private void btn40_Click(object sender, EventArgs e)
        {

        }

        private void btn41_Click(object sender, EventArgs e)
        {

        }

        private void btn42_Click(object sender, EventArgs e)
        {

        }

        private void btn43_Click(object sender, EventArgs e)
        {

        }

        private void btn44_Click(object sender, EventArgs e)
        {

        }

        private void btn45_Click(object sender, EventArgs e)
        {

        }

        private void btn46_Click(object sender, EventArgs e)
        {

        }

        private void btn47_Click(object sender, EventArgs e)
        {

        }

        private void btn50_Click(object sender, EventArgs e)
        {

        }

        private void btn51_Click(object sender, EventArgs e)
        {

        }

        private void btn52_Click(object sender, EventArgs e)
        {

        }

        private void btn53_Click(object sender, EventArgs e)
        {

        }

        private void btn54_Click(object sender, EventArgs e)
        {

        }

        private void btn55_Click(object sender, EventArgs e)
        {

        }

        private void btn56_Click(object sender, EventArgs e)
        {

        }

        private void btn57_Click(object sender, EventArgs e)
        {

        }

        private void btn60_Click(object sender, EventArgs e)
        {

        }

        private void btn61_Click(object sender, EventArgs e)
        {

        }

        private void btn62_Click(object sender, EventArgs e)
        {

        }

        private void btn63_Click(object sender, EventArgs e)
        {

        }

        private void btn64_Click(object sender, EventArgs e)
        {
            BtnClick(6, 4);
        }

        private void btn65_Click(object sender, EventArgs e)
        {

        }

        private void btn66_Click(object sender, EventArgs e)
        {

        }

        private void btn67_Click(object sender, EventArgs e)
        {

        }

        private void btn70_Click(object sender, EventArgs e)
        {

        }

        private void btn71_Click(object sender, EventArgs e)
        {

        }

        private void btn72_Click(object sender, EventArgs e)
        {

        }

        private void btn73_Click(object sender, EventArgs e)
        {

        }

        private void btn74_Click(object sender, EventArgs e)
        {

        }

        private void btn75_Click(object sender, EventArgs e)
        {

        }

        private void btn76_Click(object sender, EventArgs e)
        {
            BtnClick(7, 6);
        }

        private void btn77_Click(object sender, EventArgs e)
        {

        }
    }
}
