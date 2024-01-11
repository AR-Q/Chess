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

        public void ChangeCurrent(string FENBoard)
        {
            _current = FindNode(FENBoard);

            //TODO Add To Log
            _current.Move = Move.Undo;
            fileManager.WriteFile(_current);

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

    }
}
