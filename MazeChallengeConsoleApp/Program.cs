using System;

namespace MazeChallengeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = GenerateMatrix(20, 100);
            PrintMatrix(matrix);

            Console.ReadKey();
        }

        static void FindExitPath(char[,] matrix, int row, int col)
        {
            //IMPLEMENTAR A SOLUÇÃO PARA O DESAFIO AQUI!
            //Implemente uma solução que encontre a saída do labirinto

            //PS1: Não precisa ser o caminho mais curto, apenas uma saída.
            //PS2: Pintar o caminho da saida com algum caractere. Ex: '*'
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + "");
                }
                Console.WriteLine();
            }
        }

        static char[,] GenerateMatrix(int rowSize, int colSize)
        {
            char[,] matrix = new char[rowSize, colSize];

            //Vertical Walls
            for (int row = 0; row < rowSize; row++)
            {
                matrix[row, 0] = '#';
                matrix[row, colSize - 1] = '#';
            }

            //Horizontal Walls
            for (int col = 0; col < colSize; col++)
            {
                matrix[0, col] = '#';
                matrix[rowSize - 1, col] = '#';
            }

            //Generate Middle
            var rand = new Random();
            for (int row = 1; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 1; col < matrix.GetLength(1) - 1; col++)
                {
                    if (rand.Next(40) > 5)
                    {
                        matrix[row, col] = '#';
                    }

                }
                Console.WriteLine();
            }

            //Generate the Exit
            int startRow = 0; //The entrance
            int startCol = rand.Next(1, colSize - 1);
            matrix[startRow, startCol] = ' ';
            startRow++;
            GeneratePath(rand, matrix, startRow, startCol);

            return matrix;
        }

        static void GeneratePath(Random rand, char[,] matrix, int row, int col)
        {
            while (row < matrix.GetLength(0))
            {
                matrix[row, col] = ' ';

                if (row == matrix.GetLength(0) - 1)
                    return;

                int randResult = rand.Next(300);

                if (randResult > 160)
                {
                    col = rand.Next(col, matrix.GetLength(1) - 1);
                    for (int curCol = col; curCol <= col; curCol++)
                        matrix[row, curCol] = ' ';
                }
                else if (randResult >= 10 && randResult <= 160)
                {
                    col = rand.Next(1, col);
                    for (int curCol = col; curCol < col; curCol++)
                        matrix[row, curCol] = ' ';
                }

                row++;
                if (row < matrix.GetLength(0))
                    matrix[row, col] = ' ';
                row++;
            }
        }
    }
}
