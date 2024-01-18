using Chess.Classes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Chess.Classes
{
    public class ChessTree
    {
        private Node _root;

        private Node _current;
        private string path;

        public FileManager fileManager;

        public ChessTree(string path)
        {
            _root = null;
            _current = null;
            this.path = path;

            fileManager = new FileManager(path);
        }

        public Node GetRoot()
        {
            return _root;
        }
        public void AddNode(Node node)
        {
            if(_current == null)
            {
                _current = node;
                _root = node;
                fileManager.WriteFile(node);
                return;
            }

            _current.Children.Add(node);
            node.Father = _current;

            _current = node;
            fileManager.WriteFile(node);

            //TODO Add To Log
        }

        public void Undo()
        {
            if(_current.Father == null)
            {
                return;
            }
            _current = _current.Father;
            //TODO Add To Log
            _current.Move = Move.Undo;
            fileManager.WriteFile(_current);
        }

        public void ChangeCurrent(string FENBoard, bool Write = true)
        {
            _current = FindNode(FENBoard);

            //TODO Add To Log

            if (Write)
            {

                _current.Move = Move.Undo;
                fileManager.WriteFile(_current);

            }
        }

        public void ChangeCurrentLoad(string FENBoard)
        {
            _current = FindNodeLoad(FENBoard);

            //TODO Add To Log
            _current.Move = Move.Undo;

        }

        private Node FindNodeLoad(string FENBoard)
        {
            return FindNodeLoad(_root, FENBoard);
        }

        private Node FindNodeLoad(Node node, string FENBoard)
        {
            string a = node.FENBoard();
            if (a == FENBoard)
            {
                return node;
            }

            foreach (var item in node.Children)
            {
                var res = FindNodeLoad(item, FENBoard);

                if (res != null)
                {
                    return res;
                }
            }

            return null;
        }

        private Node FindNode(string FENBoard)
        {
            return FindNode(_root, FENBoard);
        }

        private Node FindNode(Node node, string FENBoard)
        {
            string a = "TreeNode: " + node.FENBoard();
            if (a == FENBoard)
            {
                return node;
            }

            foreach (var item in node.Children)
            {
                var res = FindNode(item, FENBoard);

                if(res != null)
                {
                    return res;
                }
            }

            return null;
        }

        public Node GetCurrentNode()
        {
            return _current;
        }

        public void Load()
        {
            fileManager.ReadFile(this);
        }

        public Node LoadNode(string line)
        {
            if(line == null)
            {
                return null;
            }
            string[] array = line.Split("|");

            Node node = new Node();

            node.Move = GetMove(array[0]);
            node.Board = GetBoard(array[1]);
            node.Turn = GetColorload(array[2]);
            node.Castle = array[3];
            node.EnPassant = array[4];
            node.Draw = Convert.ToInt32(array[5]);
            node.Total = Convert.ToInt32(array[6]);
            node.Check = Convert.ToBoolean(array[7]);

            return node;
        }

        private Move GetMove(string a)
        {
            if(a == "#")
            {
                return Move.Start;
            }
            else if(a == "*")
            {
                return Move.Move;
            }
            else
            {
                return Move.Undo;
            }
        }

        private string[,] GetBoard(string a)
        {
            
            string[,] board = new string[8,8];
            int x = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i,j] = a[x].ToString();
                    x++;
                }
                x++;
            }
            return board;
        }

        private Color GetColorload(string a)
        {
            if (a == "w")
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }

        public List<Piece> GetEatenPieece(Node undo)
        {
            List<Piece> rootPiece = _current.GetPieces(_root.Board);
            List<Piece> undoPiece = undo.GetPieces(undo.Board);

            foreach (var up in undoPiece)
            {
                Piece piece = rootPiece.FirstOrDefault(p => p.Color == up.Color && p.PieceType() == up.PieceType());
                if(piece != null)
                {
                    rootPiece.Remove(piece);
                }
            }

            return rootPiece;
        }
    }
}
