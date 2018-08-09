﻿using System;

namespace Maze
{
    class maze
    {
        int rowSize = 5, colSize = 5;
        string outputStr = "";
        public maze()
        {
            int[,] maze = new int[5, 5] {
                { 1,1,1,1,1},
                { 0,0,1,0,0},
                { 1,1,1,1,1}
                ,{ 1,0,0,0,0}
                ,{ 1,1,1,1,1}
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

            mazeOutput(maze, output, 0, 0, 'D');

            Console.WriteLine("\nOutput ");
            print(output);

            //Console.WriteLine(outputStr);
        }

        private bool mazeOutput(int[,] input, int[,] output, int row, int col, char side)
        {
            if (row == rowSize - 1 && colSize - 1 == col)
            {
                output[row, col] = 1;
                return true;
            }

            if (checkValidation(input, row, col))
            {
                output[row, col] = 1;

                if (side != 'U')
                    if (mazeOutput(input, output, row + 1, col, 'D'))
                    {
                        outputStr += 'D';
                        return true;
                    }

                if (side != 'R')
                    if (mazeOutput(input, output, row, col + 1, 'L'))
                    {
                        outputStr += 'L';
                        return true;
                    }

                if (side != 'L')
                    if (mazeOutput(input, output, row, col - 1, 'R'))
                    {
                        outputStr += 'R';
                        return true;
                    }

                if (side != 'D')
                    if (mazeOutput(input, output, row - 1, col, 'U'))
                    {
                        outputStr += 'U';
                        return true;
                    }
                output[row, col] = 0;
                return false;
            }
            return false;
        }

        private bool checkValidation(int[,] input, int row, int col)
        {
            if (row < rowSize && row >= 0 && col < colSize && col >= 0)
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
