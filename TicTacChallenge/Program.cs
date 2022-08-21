using System;

namespace TicTacChallenge
{
    class Program
    {
        
        static string[,] x = new string[3, 3];
        static string[,] o = new string[3, 3];

        static char player1 = 'X';
        static char player2 = 'O';

        static bool noOneWon = true;
        static bool draw = false;

        static void Main(string[] args)
        {
            bool playerX = true;

            while (true)
            {
                gameRound(playerX);

                if (draw == false && playerX == false)
                {
                    Console.WriteLine("Congratulations, Player " + player1);
                }
                else if(draw == false && playerX == true)
                {
                    Console.WriteLine("Congratulations, Player " + player2);
                }
                else
                {
                    Console.WriteLine("It's a draw, no onw won");
                }
                Console.WriteLine("press any key to play again");
                Console.ReadLine();
            }

        }

        private static void gameRound(bool playerX)
        {
            // Start with drawing empty board
            DrawBoard board = new DrawBoard();
            noOneWon = true;
            draw = false;

            // ask players to make move
            while (noOneWon == true && draw == false)
            {
                bool canBePlaced = false;
                int playerCell;
                while (canBePlaced != true)
                {
                    if (playerX)
                    {
                        playerCell = askForMove(player1);
                    }
                    else
                    {
                        playerCell = askForMove(player2);
                    }

                    if (board.checkIfNumber(playerCell) == true)
                    {
                        board.setNumber(playerCell, playerX);
                        canBePlaced = true;
                    }
                    else
                    {
                        Console.WriteLine("Can't place it in the occupied slot");
                    }
                }


                board.reDrawBoard();
                noOneWon = !board.checkIfWon();
                draw = board.checkIfDraw();

                playerX = !playerX;
            }

        }

        private static int askForMove(char player)
        {
            int playerCell = -1;
            while (playerCell < 0)
            {
                Console.WriteLine("Player " + player + " choose cell");
            
                int.TryParse(Console.ReadLine(), out playerCell);
            }
            return playerCell;
        }
        

    }
 }
