using Chess.Classes.Pieces;
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
        public ChessTree ChessTree { get; set; }

        public Game(Button[,] Buttons)
        {
            Pieces = new List<Piece>();
            ChessTree = new ChessTree();

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
    }
}
