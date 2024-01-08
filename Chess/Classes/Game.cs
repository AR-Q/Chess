using Chess.Classes.Pieces;
using Chess.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    public class Game
    {
        public List<Piece> Pieces { get; set; }
        public List<Piece> TakenPiece { get; set; }
        public ChessTree ChessTree { get; set; }
        public FileManager fileManager;

        public Game(Button[,] Buttons, string filePath)
        {
            
            Pieces = new List<Piece>();
            TakenPiece = new List<Piece>();
            ChessTree = new ChessTree(filePath);
            

            Node node = new Node
            {
                /*Board = new string[8, 8],*/
                Castle = "KQkq",
                Check = false,
                Draw = 0,
                EnPassant = "-",
                Total = 0,
                Turn = Color.White,
                Move = Move.Start,
                Board = new string[,] { { "r","n","b","q","k","b","n","r"},
                                          {"p","p","p","p","p","p","p","p"},
                                          {"0","0","0","0","0","0","0","0"},
                                          {"0","0","0","0","0","0","0","0"},
                                          {"0","0","0","0","0","0","0","0"},
                                          {"0","0","0","0","0","0","0","0"},
                                          {"P","P","P","P","P","P","P","P"},
                                          {"R","N","B","Q","K","B","N","R"},
                                       }
            };

            ChessTree.AddNode(node);


            Pieces.Add(new Rook(new Position(0,0), Color.Black));
            Pieces.Add(new Knight(new Position(1,0), Color.Black));
            Pieces.Add(new Bishop(new Position(2,0), Color.Black));
            Pieces.Add(new Queen(new Position(3,0), Color.Black));
            Pieces.Add(new King(new Position(4,0), Color.Black));
            Pieces.Add(new Bishop(new Position(5,0), Color.Black));
            Pieces.Add(new Knight(new Position(6,0), Color.Black));
            Pieces.Add(new Rook(new Position(7,0), Color.Black));

            Pieces.Add(new Pawn(new Position(0,1), Color.Black));
            Pieces.Add(new Pawn(new Position(1,1), Color.Black));
            Pieces.Add(new Pawn(new Position(2,1), Color.Black));
            Pieces.Add(new Pawn(new Position(3,1), Color.Black));
            Pieces.Add(new Pawn(new Position(4,1), Color.Black));
            Pieces.Add(new Pawn(new Position(5,1), Color.Black));
            Pieces.Add(new Pawn(new Position(6,1), Color.Black));
            Pieces.Add(new Pawn(new Position(7,1), Color.Black));

            Pieces.Add(new Rook(new Position(0, 7), Color.White));
            Pieces.Add(new Knight(new Position(1, 7), Color.White));
            Pieces.Add(new Bishop(new Position(2, 7), Color.White));
            Pieces.Add(new Queen(new Position(3, 7), Color.White));
            Pieces.Add(new King(new Position(4, 7), Color.White));
            Pieces.Add(new Bishop(new Position(5, 7), Color.White));
            Pieces.Add(new Knight(new Position(6, 7), Color.White));
            Pieces.Add(new Rook(new Position(7, 7), Color.White));

            Pieces.Add(new Pawn(new Position(0, 6), Color.White));
            Pieces.Add(new Pawn(new Position(1, 6), Color.White));
            Pieces.Add(new Pawn(new Position(2, 6), Color.White));
            Pieces.Add(new Pawn(new Position(3, 6), Color.White));
            Pieces.Add(new Pawn(new Position(4, 6), Color.White));
            Pieces.Add(new Pawn(new Position(5, 6), Color.White));
            Pieces.Add(new Pawn(new Position(6, 6), Color.White));
            Pieces.Add(new Pawn(new Position(7, 6), Color.White));

            Setups.SetupBoard(Pieces , Buttons);
        }

        public Color GetTurn()
        {
            if(ChessTree.GetCurrentNode().Turn == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }


        public string[,] GetFENBoard()
        {
            string[,] board = new string[8, 8];

            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    board[i, j] = "0";
                }
            }

            foreach (var piece in Pieces)
            {
                switch (piece.PieceType())
                {
                    case "pawn":
                        if (piece.Color == Color.White)
                        {
                            board[piece.Position.Y, piece.Position.X] = "P";
                        }
                        else
                        {
                            board[piece.Position.Y, piece.Position.X] = "p";
                        }
                        break;

                    case "rook":
                        if (piece.Color == Color.White)
                        {
                            board[piece.Position.Y, piece.Position.X] = "R";
                        }
                        else
                        {
                            board[piece.Position.Y, piece.Position.X] = "r";
                        }
                        break;

                    case "knight":
                        if (piece.Color == Color.White)
                        {
                            board[piece.Position.Y, piece.Position.X] = "N";
                        }
                        else
                        {
                            board[piece.Position.Y, piece.Position.X] = "n";
                        }
                        break;

                    case "bishop":
                        if (piece.Color == Color.White)
                        {
                            board[piece.Position.Y, piece.Position.X] = "B";
                        }
                        else
                        {
                            board[piece.Position.Y, piece.Position.X] = "b";
                        }
                        break;

                    case "king":
                        if (piece.Color == Color.White)
                        {
                            board[piece.Position.Y, piece.Position.X] = "K";
                        }
                        else
                        {
                            board[piece.Position.Y, piece.Position.X] = "k";
                        }
                        break;

                    case "queen":
                        if (piece.Color == Color.White)
                        {
                            board[piece.Position.Y, piece.Position.X] = "Q";
                        }
                        else
                        {
                            board[piece.Position.Y, piece.Position.X] = "q";
                        }
                        break;

                    default:
                        throw new Exception("Error : Unknoun Piece");
                }
            }

            return board;
        }

        public bool isChecked()
        {
            if(GetTurn() == Color.White)
            {
                List<Position> positions = new List<Position>();

                foreach (var piece in Pieces.Where(p => p.Color == Color.Black))
                {
                    positions.AddRange(piece.GetPossibleMoves(ChessTree.GetCurrentNode(),ChessTree.GetCurrentNode().Board,false));
                }

                Piece king = Pieces.FirstOrDefault(x => x.PieceType() == "king" && x.Color == Color.White);

                if(positions.Any(p => p.X == king.Position.X && p.Y == king.Position.Y))
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
                List<Position> positions = new List<Position>();

                foreach (var piece in Pieces.Where(p => p.Color == Color.White))
                {
                    positions.AddRange(piece.GetPossibleMoves(ChessTree.GetCurrentNode(), ChessTree.GetCurrentNode().Board,false));
                }

                Piece king = Pieces.FirstOrDefault(x => x.PieceType() == "king" && x.Color == Color.Black);

                if (positions.Any(p => p.X == king.Position.X && p.Y == king.Position.Y))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsMate()
        {
            if (GetTurn() == Color.Black && ChessTree.GetCurrentNode().Check)
            {
                List<Position> positions = new List<Position>();

                foreach (var piece in Pieces.Where(p => p.Color == Color.White))
                {
                    positions.AddRange(piece.GetPossibleMoves(ChessTree.GetCurrentNode(), ChessTree.GetCurrentNode().Board, false));
                }

                if(positions.Count == 0)
                {
                    End end = new End(Color.Black);
                    end.Show();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (GetTurn() == Color.White && ChessTree.GetCurrentNode().Check)
            {
                List<Position> positions = new List<Position>();

                foreach (var piece in Pieces.Where(p => p.Color == Color.Black))
                {
                    List<Position> temp = piece.GetPossibleMoves(ChessTree.GetCurrentNode(), ChessTree.GetCurrentNode().Board, true);
                    positions.AddRange(temp);
                }

                if (positions.Count == 0)
                {
                    End end = new End(Color.White);
                    end.Show();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
