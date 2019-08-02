using System;

namespace MazeChallengeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] maze = GenerateMaze(20, 100);
            FindExitPath(maze);
            PrintMaze(maze);

            Console.ReadKey();
        }

        static void FindExitPath(char[,] maze)
        {
            //IMPLEMENTAR A SOLUÇÃO PARA O DESAFIO AQUI!
            //Implemente uma solução que encontre a saída do labirinto

            //PS1: Não precisa ser o caminho mais curto, apenas uma saída.
            //PS2: Pintar o caminho da saida com algum caractere. Ex: '*'

            //First Step: Find the ENTRANCE.
            int startCol = 0;
            for (int i = 1; i < maze.GetLength(1); i++)
                if (maze[0, i] == ' ')
                {
                    startCol = i;
                    break;
                }

            //Second Step: FindTheExit
            RecursivelyFindExitPath(maze, 0, startCol);
        }

        private static bool RecursivelyFindExitPath(char[,] maze, int row, int col)
        {
            //Se quiser trabalhar de forma recursiva, basta preencher esta função!!!!
        }

        static void PrintMaze(char[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row, col] == '*')
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(maze[row, col]);
                }
                Console.WriteLine();
            }
        }

        static char[,] GenerateMaze(int rowSize, int colSize)
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

            //Generate the Entrance and the Exit
            int startRow = 0; //Entrance row
            int startCol = rand.Next(1, colSize - 1);
            matrix[startRow, startCol] = ' ';
            startRow++;
            GeneratePath(rand, matrix, startRow, startCol);

            return matrix;
        }

        static void GeneratePath(Random rand, char[,] maze, int row, int col)
        {
            while (row < maze.GetLength(0))
            {
                maze[row, col] = ' ';

                if (row == maze.GetLength(0) - 1)
                    return;

                int randResult = rand.Next(300);

                if (randResult > 160)
                {
                    int nextCol = rand.Next(col, maze.GetLength(1) - 1);
                    for (; col <= nextCol; col++)
                        maze[row, col] = ' ';
                    col--;
                }
                else if (randResult >= 10 && randResult <= 160)
                {
                    int nextCol = rand.Next(1, col);
                    for (; col >= nextCol; col--)
                        maze[row, col] = ' ';
                    col++;
                }

                row++;
                if (row < maze.GetLength(0))
                    maze[row, col] = ' ';
                row++;
            }
        }
    }
}
