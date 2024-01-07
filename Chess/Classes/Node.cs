using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chess.Classes
{
    public class Node
    {

        public Node Father { get; set; }
        public List<Node> Children { get; set; }





        public Move Move { get; set; }
        public string[,] Board { get; set; }
        public Color Turn { get; set; }
        public string Castle { get; set; }
        public string EnPassant { get; set; }
        public int Draw { get; set; }
        public int Total { get; set; }
        public bool Check { get; set; }





        public Node()
        {
            Children = new List<Node>();
        }




        // For Pawn
        public bool IsMoveablePawn(Position position)
        {
            if (Board[position.X,position.Y] == "0")
            {
                return true;
            }

            return false;
        }
        // For Pawn
        public bool IsMoveablePawn(Position position, Color color)
        {
            if(color == Color.Black)
            {
                if (Regex.IsMatch(Board[position.X, position.Y], @"[a-z]"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (Regex.IsMatch(Board[position.X, position.Y], @"[A-Z]"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public State IsMoveable(Position position, Color color)
        {

            if (color == Color.Black)
            {
                if (Board[position.X,position.Y] == "0")
                {
                    return State.Possible;
                }
                else if (Regex.IsMatch(Board[position.X, position.Y], @"[a-z]"))
                {
                    return State.Take;
                }
                else
                {
                    return State.Impossible;
                }
            }
            else
            {
                if (Board[position.X, position.Y] == "0")
                {
                    return State.Possible;
                }
                else if (Regex.IsMatch(Board[position.X, position.Y], @"[A-Z]"))
                {
                    return State.Take;
                }
                else
                {
                    return State.Impossible;
                }
            }

        }

    }
}
