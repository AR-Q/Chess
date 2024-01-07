using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chess.Classes
{
    public class ChessTree
    {
        private Node _root;

        private Node _current;


        public ChessTree()
        {
            _root = null;
            _current = null;
        }


        public void AddNode(Node node)
        {
            if(_current == null)
            {
                _current = node;
                _root = node;
                return;
            }

            _current.Children.Add(node);
            node.Father = _current;

            _current = node;

            //TODO Add To Log
        }

        public void Undo()
        {
            _current = _current.Father;
            //TODO Add To Log
        }

        public void ChangeCurrent(Node node)
        {
            // TODO
        }

        public Node GetCurrentNode()
        {
            return _current;
        }

    }
}
