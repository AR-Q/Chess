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
            SetDefaultColor(Buttons);
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    Buttons[i, j].Image = null;
                }
            }

            foreach (var piece in board)
            {
                SetPiece(piece, Buttons[piece.Position.Y, piece.Position.X]);
            }
        }

        public static void SetupTakenPiece(ListView listView)
        {
            var imageList = new ImageList();
            imageList.Images.Add("Blackking", new Bitmap(Chess.Properties.Resources.king_b));
            imageList.Images.Add("Blackqueen", new Bitmap(Chess.Properties.Resources.queen_b));
            imageList.Images.Add("Blackbishop", new Bitmap(Chess.Properties.Resources.bishop_b));
            imageList.Images.Add("Blackknight", new Bitmap(Chess.Properties.Resources.knight_b));
            imageList.Images.Add("Blackrook", new Bitmap(Chess.Properties.Resources.rook_b));
            imageList.Images.Add("Blackpawn", new Bitmap(Chess.Properties.Resources.pawn_b));
            imageList.Images.Add("Whiteking", new Bitmap(Chess.Properties.Resources.king_w));
            imageList.Images.Add("Whitequeen", new Bitmap(Chess.Properties.Resources.queen_w));
            imageList.Images.Add("Whitebishop", new Bitmap(Chess.Properties.Resources.bishop_w));
            imageList.Images.Add("Whiteknight", new Bitmap(Chess.Properties.Resources.knight_w));
            imageList.Images.Add("Whiterook", new Bitmap(Chess.Properties.Resources.rook_w));
            imageList.Images.Add("Whitepawn", new Bitmap(Chess.Properties.Resources.pawn_w));
            imageList.ImageSize = new Size(145, 145);
            listView.LargeImageList = imageList;
        }

        public static void SetupTakenPiece(List<Piece> pieces, ListView listView)
        {
            SetupTakenPiece(listView);
            listView.Items.Clear();
            foreach (var item in pieces)
            {
                string imgKey = item.Color.ToString() + item.PieceType();
                ListViewItem listViewItem = new ListViewItem(imgKey);
                listViewItem.ImageKey = imgKey;
                listView.Items.Add(imgKey);
            }
            
        }

        public static void SetupTree(TreeView tree, ChessTree chessTree)
        {
            tree.Nodes.Clear();
            SetupTree(tree.Nodes, chessTree.GetRoot(), 0);
            tree.ExpandAll();
        }

        public static void SetupTree(TreeNodeCollection treeNodeCollection, Node node, int x)
        {
            if(node == null)
            {
                return;
            }

            treeNodeCollection.Add(node.FENBoard());

            int i = 0;
            foreach (var item in node.Children)
            {
                SetupTree(treeNodeCollection[x].Nodes, item, i);
                i++;
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
                        buttons[i, j].BackColor = System.Drawing.Color.FromArgb(242, 225, 195);
                    }
                    else
                    {
                        buttons[i, j].BackColor = System.Drawing.Color.FromArgb(195, 160, 130);
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
