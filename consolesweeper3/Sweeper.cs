using System;

namespace consolesweeper3
{
    public class Sweeper
    {
        private int gridSize = 0;
        public int inputSize = 0;
        private int[,] grid;
        private bool[,] hit;
        public bool gameIsAlive = true;
        private Random generator = new Random();


        public Sweeper(int inputSize)
        {
            gridSize = inputSize;

            grid = new int[gridSize, gridSize];
            hit = new bool[gridSize, gridSize];

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    grid[x, y] = 9;
                }
            }
            for (int i = 0; i < gridSize; i++)
            {
                bool signValue = true;
                while (signValue == true)
                {
                    int valueX = generator.Next(gridSize);
                    int valueY = generator.Next(gridSize);

                    if (grid[valueX, valueY] != 10)
                    {
                        grid[valueX, valueY] = 10;
                        signValue = false;
                    }
                }
            }
        }
        public bool CheckPositionValid(int x, int y)
        {
            if (x >= 0 && x <= gridSize && y >= 0 && y <= gridSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DoesPositionHaveBomb(int x, int y)
        {
            if (grid[x,y] == 10)
            {
                gameIsAlive = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void HitCoordinates(int x, int y)
        {
            hit[x,y] = true;
        }
        public void Print()
        {
            Console.Clear();

            for (int j = 0; j < gridSize; j++)
            {
                System.Console.Write("X" + j);
            }

            for (int x = 0; x < gridSize; x++)
            {
                System.Console.WriteLine();

                for (int y = 0; y < gridSize; y++)
                {
                    if (gameIsAlive == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        System.Console.Write("██");
                        Console.ResetColor();
                    }
                    else if (hit[x,y] == true)
                    {
                        int bombs = 0;

                        for (int x1 = 0; x1 < 3; x1++)
                        {
                            for (int y1 = 0; y1 < 3; y1++)
                            {
                                if (grid[x - 1 + x1, y + 1 - y1] == 10)
                                {
                                    bombs++;
                                }
                            } 
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write("█");
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        System.Console.Write(bombs);
                        Console.ResetColor();
                    }
                    else if (hit[x,y] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.Write("██");
                        Console.ResetColor();
                    }
                } 
                System.Console.Write("Y" + x);
            }
            System.Console.WriteLine();
        }
    }
}
