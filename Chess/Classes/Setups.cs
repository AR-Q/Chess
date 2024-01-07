using Chess.Classes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    public static class Setups
    {
        public static void SetupBoard(List<Piece> board, Button[,] Buttons)
        {
            /*Buttons[0, 0].BackgroundImage = global::Chess.Properties.Resources.rook_b;*/

            foreach (var piece in board)
            {
                SetPiece(piece, Buttons[piece.Position.Y, piece.Position.X]);
            }
        }

        public static Node ConvertToNode(string line)
        {
            Node node = new Node();


            return node;
        }

        public static void SetDefaultColor(Button[,] buttons)
        {
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if((i + j) % 2 == 0)
                    {
                        buttons[i, j].BackColor = System.Drawing.Color.White;
                    }
                    else
                    {

                        buttons[i, j].BackColor = System.Drawing.SystemColors.ControlDarkDark;
                    }
                }
            }
        }

        public static string ConvertToString(Node node)
        {
            string res = "";

            if(node.Move == Move.Start)
            {
                res = "#";
            }
            else if (node.Move == Move.Move)
            {
                res = "*";
            }
            else if (node.Move == Move.Undo)
            {
                res = "-";
            }
            else 
            {
                res = "+";
            }
            res += "|";

            res += node.FENBoard() + "|";

            if(node.Turn == Color.White)
            {
                res += "w";
            }
            else
            {
                res += "b";
            }

            res += "|";

            res += node.Castle + "|";

            res += node.EnPassant + "|";

            res += Convert.ToString(node.Draw) + "|";

            res += Convert.ToString(node.Total);

            return res;
        }


        public static void SetPiece(Piece piece , Button button)
        {
            switch (piece.PieceType())
            {
                case "pawn":
                    if(piece.Color == Color.White)
                    {
                        button.Image = global::Chess.Properties.Resources.pawn_w;
                    }
                    else
                    {
                        button.Image = global::Chess.Properties.Resources.pawn_b;
                    }
                    break;

                case "rook":
                    if (piece.Color == Color.White)
                    {
                        button.Image = global::Chess.Properties.Resources.rook_w;
                    }
                    else
                    {
                        button.Image = global::Chess.Properties.Resources.rook_b;
                    }
                    break;

                case "knight":
                    if (piece.Color == Color.White)
                    {
                        button.Image = global::Chess.Properties.Resources.knight_w;
                    }
                    else
                    {
                        button.Image = global::Chess.Properties.Resources.knight_b;
                    }
                    break;

                case "bishop":
                    if (piece.Color == Color.White)
                    {
                        button.Image = global::Chess.Properties.Resources.bishop_w;
                    }
                    else
                    {
                        button.Image = global::Chess.Properties.Resources.bishop_b;
                    }
                    break;

                case "king":
                    if (piece.Color == Color.White)
                    {
                        button.Image = global::Chess.Properties.Resources.king_w;
                    }
                    else
                    {
                        button.Image = global::Chess.Properties.Resources.king_b;
                    }
                    break;

                case "queen":
                    if (piece.Color == Color.White)
                    {
                        button.Image = global::Chess.Properties.Resources.queen_w;
                    }
                    else
                    {
                        button.Image = global::Chess.Properties.Resources.queen_b;
                    }
                    break;

                default:
                    throw new Exception("Error : Unknoun Piece");
                    break;

            }
        }
    }
}
