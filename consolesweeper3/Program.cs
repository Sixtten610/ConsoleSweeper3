using System;

namespace consolesweeper3
{
    class Program
    {
        static void Main(string[] args)
        {
            Sweeper sweeper = new Sweeper(FetchGridSize());
            Game(sweeper);
        }

        static void Game(Sweeper sweeper)
        {
            bool loop = true;
            while (loop == true)
            {
                sweeper.Print();
                
                int x = GetCoordinate("y ");
                int y = GetCoordinate("x ");

                if (sweeper.CheckPositionValid(x,y) == true)
                {
                    sweeper.HitCoordinates(x,y);
                    if (sweeper.DoesPositionHaveBomb(x,y) == true)
                    {
                        loop = false;
                        GameOver();
                    }
                }
            }
        }

        static int GetCoordinate(string s)
        {
            System.Console.Write(s);
            return FetchGridSize();
        }

        static int FetchGridSize()
        {
            System.Console.Write("enter number: ");
            bool loop = true;
            while (loop == true)
            {
                int n = GetNumber();

                if (n >= 0)
                {
                    return n;
                }
            }
            return 1;

        }

        static int GetNumber()
        {
            bool loop = true;
            while (loop == true)
            {
                string input = Console.ReadLine();
                int output = 0;

                bool convert = int.TryParse(input, out output);
                if (convert)
                {
                    return output;
                }
            }

            return 1;
        }

        static void GameOver()
        {
            Console.Clear();
            System.Console.WriteLine("you lost");
            Console.ReadLine();
        }
    }
}
