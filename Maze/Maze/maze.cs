using System;

namespace Maze
{
    class maze
    {
        int rowSize = 4, colSize = 4;

        public maze()
        {
            int[,] maze = new int[4, 4] {
                { 1,0,0,0},
                { 1,1,0,0},
                { 0,1,1,1}
                ,{ 1,1,0,1}
            };

            Console.WriteLine("\nInput ");
            print(maze);

            solve(maze);

            Console.Read();
        }
        private void solve(int[,] maze)
        {
            int[,] output = new int[rowSize, colSize];
            for (int i = 0; i < rowSize; i++)
                for (int j = 0; j < colSize; j++)
                    output[i, j] = 0;

            mazeOutput(maze, output, 0, 0);

            Console.WriteLine("\nOutput ");
            print(output);
        }

        private bool mazeOutput(int[,] input, int[,] output, int row, int col)
        {

            if (row == rowSize - 1 && colSize - 1 == col)
            {
                output[row, col] = 1;
                return true;
            }

            if (checkValidation(input, row, col))
            {
                output[row, col] = 1;

                if (mazeOutput(input, output, row + 1, col))
                    return true;

                if (mazeOutput(input, output, row, col + 1))
                    return true;

                output[row, col] = 0;
                return false;
            }

            return false;

        }

        private bool checkValidation(int[,] input, int row, int col)
        {
            if (row < rowSize && col < colSize)
                if (input[row, col] == 1)
                    return true;
            return false;
        }

        private void print(int[,] matrix)
        {
            
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
