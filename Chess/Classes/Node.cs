using Chess.Classes.Pieces;
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

        public Node(Node node)
        {
            Move = node.Move;
            Board = node.Board;
            Turn = node.Turn;
            Castle = node.Castle;
            EnPassant = node.EnPassant;
            Draw = node.Draw;
            Total = node.Total;
            Check = node.Check;
        }





        // For Pawn
        public bool IsMoveablePawn(Position position, string[,] board)
        {
            if (board[position.Y, position.X] == "0")
            {
                return true;
            }

            return false;
        }
        // For Pawn
        public bool IsMoveablePawn(Position position, Color color, string[,] board)
        {
            if (color == Color.Black)
            {
                if (Regex.IsMatch(board[position.Y, position.X], @"[a-z]"))
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
                if (Regex.IsMatch(board[position.Y, position.X], @"[A-Z]"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        public State IsMoveable(Position position, Color color, string[,] board)
        {

            if (color == Color.Black)
            {
                if (board[position.Y, position.X] == "0")
                {
                    return State.Possible;
                }
                else if (Regex.IsMatch(board[position.Y, position.X], @"[a-z]"))
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
                if (board[position.Y, position.X] == "0")
                {
                    return State.Possible;
                }
                else if (Regex.IsMatch(board[position.Y, position.X], @"[A-Z]"))
                {
                    return State.Take;
                }
                else
                {
                    return State.Impossible;
                }
            }

        }

        public string FENBoard()
        {
            string res = "";

            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    res += Board[i, j];
                }
                res += "/";
            }

            return res.Substring(0, res.Length - 1);
        }

        public List<Position> CheckMove(Piece piece, List<Position> possibleMoves,string p)
        {
            List<Position> result = new List<Position>();

            string[,] tempBoard = new string[8, 8];


            foreach (var pm in possibleMoves)
            {
                for (int i = 0; i <= 7; i++)
                {
                    for (int j = 0; j <= 7; j++)
                    {
                        tempBoard[i, j] = Board[i, j];
                    }
                }

                tempBoard[piece.Position.Y, piece.Position.X] = "0";
                tempBoard[pm.Y, pm.X] = p;
                List<Piece> pieces = GetPieces(tempBoard);

                if (Turn == Color.White)
                {
                    List<Position> positions = new List<Position>();
                    Node node = new Node(this);
                    node.Board = tempBoard;
                    node.Check = false;

                    foreach (var piece2 in pieces.Where(p => p.Color == Color.Black))
                    {
                        positions.AddRange(piece2.GetPossibleMoves(node,tempBoard));
                    }

                    Piece king = pieces.FirstOrDefault(x => x.PieceType() == "king" && x.Color == Color.White);

                    if (!positions.Any(p => p.X == king.Position.X && p.Y == king.Position.Y))
                    {
                        result.Add(pm);
                    }
                }
                else
                {
                    List<Position> positions = new List<Position>();
                    Node node = new Node(this);
                    node.Board = tempBoard;
                    node.Check = false;

                    foreach (var piece2 in pieces.Where(p => p.Color == Color.White))
                    {
                        positions.AddRange(piece2.GetPossibleMoves(node, tempBoard));
                    }

                    Piece king = pieces.FirstOrDefault(x => x.PieceType() == "king" && x.Color == Color.Black);

                    if (!positions.Any(p => p.X == king.Position.X && p.Y == king.Position.Y))
                    {
                        result.Add(pm);
                    }
                }

            }

            return result;
        }

        public List<Piece> GetPieces(string[,] board)
        {
            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (board[i, j] != "0")
                    {
                        pieces.Add(CreatePiece(i, j, board[i, j]));
                    }
                }
            }

            return pieces;
        }

        public Piece CreatePiece(int x, int y, string p)
        {
            Position position = new Position(y, x);
            Piece piece;

            switch (p)
            {
                case "p":
                    piece = new Pawn(position, Color.Black);
                    break;

                case "r":
                    piece = new Rook(position, Color.Black);
                    break;

                case "n":
                    piece = new Knight(position, Color.Black);
                    break;

                case "b":
                    piece = new Bishop(position, Color.Black);
                    break;

                case "k":
                    piece = new King(position, Color.Black);
                    break;

                case "q":
                    piece = new Queen(position, Color.Black);
                    break;

                case "P":
                    piece = new Pawn(position, Color.White);
                    break;

                case "R":
                    piece = new Rook(position, Color.White);
                    break;

                case "N":
                    piece = new Knight(position, Color.White);
                    break;

                case "B":
                    piece = new Bishop(position, Color.White);
                    break;

                case "K":
                    piece = new King(position, Color.White);
                    break;

                case "Q":
                    piece = new Queen(position, Color.White);
                    break;

                default:
                    throw new Exception("Error : Unknoun Piece");
            }

            return piece;
        }
    }

}
