using System;

namespace TicTacChallenge
{
    class DrawBoard
    {
        static string topLine = "   |   |   ";
        static string bottomLine = "___|___|___";

        static int[,] matrix =
                     {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 }
                };

        public DrawBoard()
        {
            Console.Clear();
            this.resetMatrix();
            this.drawBoard(matrix);
        }

        public void reDrawBoard()
        {
            Console.Clear();
            this.drawBoard(matrix);
        }


        private void resetMatrix()
        {
            int counter = 1;
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = counter;
                    counter++;
                }
            }
        }

        public int[] searchForNumber(int number)
        {
            int[] coordinates = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j] == number && matrix[i,j] > 0)
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                        return coordinates;
                    }
                }
            }

            return coordinates;
        }

        public bool checkIfNumber(int number)
        {
            bool isVacant = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == number && matrix[i, j] > 0)
                    {
                        isVacant = true;
                        return isVacant;
                    }
                }
            }
            return isVacant;
        }

        public bool checkIfDraw()
        {
            bool draw = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j=0;j<matrix.GetLength(1); j++)
                {
                    if(matrix[i,j] > 0)
                    {
                        draw = false;
                    }
                }
            }
            return draw;
        }

        public void setNumber(int choice, bool player1)
        {
            int[] coordinates = searchForNumber(choice);
            if (player1) {
                matrix[coordinates[0], coordinates[1]] = -1; 
            }
            else
            {
                matrix[coordinates[0], coordinates[1]] = -2;
            }
        }

        private void drawBoard(int[,] matrix)
        {
            int rowCounter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(topLine);
                int counter = 0;
                string tempString = "";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == -2)
                    {
                        tempString += " O ";
                    }
                    else if(matrix[i, j] == -1)
                    {
                        tempString += " X ";
                    }
                    else
                    {
                        tempString += " " + matrix[i, j] + " ";
                    }

                    if (counter < 2)
                    {
                        tempString += "|";
                        counter++;
                    }
                }
                Console.WriteLine(tempString);
                rowCounter++;
                if (rowCounter < 3)
                {
                    Console.WriteLine(bottomLine);
                }
                else
                {
                    Console.WriteLine(topLine);
                }
            }

        }

        public bool checkIfWon()
        {
            bool isWon = false;
            if(checkRows(matrix) == true)
            {
                isWon = true;
            }
            if(checkColumns(matrix) == true)
            {
                isWon = true;
            }
            if(checkDiag(matrix) == true)
            {
                isWon = true;
            }
            return isWon;
        }

        private bool checkRows(int[,] matrix)
        {
            bool rowMatch = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int j = 1;
                if ((matrix[i, j - 1] == matrix[i, j]) & (matrix[i, j] == matrix[i, j + 1]))
                {
                    rowMatch = true;
                }
            }
            return rowMatch;
        }

        private bool checkColumns(int[,] matrix)
        {
            bool columnMatch = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int i = 1;
                if ((matrix[i-1,j] == matrix[i,j]) & (matrix[i,j] == matrix[i + 1, j]))
                {
                    columnMatch = true;
                }
            }
            return columnMatch;
        }

        private bool checkDiag(int[,] matrix)
        {
            bool diagMatch = false;
            int i = 1;
            if ((matrix[i-1,i-1] == matrix[i,i]) & (matrix[i,i] == matrix[i+1, i + 1]))
            {
                diagMatch = true;
            }
            if (matrix[i-1, i+1] == matrix[i,i] & (matrix[i,i] == matrix[i+1, i - 1]))
            {
                diagMatch = true;
            }
            return diagMatch;
        }
        
    }
}
