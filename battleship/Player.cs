using System;

namespace battleship
{
    class Player
    {
        public const int maxShots = 10;
        public int Shots { get; private set; }
        public int Hits { get; private set; }
        public int GuessX { get; private set; }
        public int GuessY { get; private set; }

        public void ResetPlayer()
        {
            Shots = 0;
            Hits = 0;
            GuessX = -1;
            GuessY = -1;
        }

        public void Shoot()
        {
            Shots++;
        }

        public void HitCount()
        {
            Hits++;
        }

        public void ReadGuess()
        {
            Console.Write("Please enter X horizontal coordinate from 1-10: ");

            if (int.TryParse(Console.ReadLine(), out int valueX))
                GuessX = valueX;

            Console.Write("\nPlease enter Y vertical coordinate from 1-10: ");

            if (int.TryParse(Console.ReadLine(), out int valueY))
                GuessY = valueY;
        }

        public bool IsValidGuess(string[,] gameBoard)
        {
            return GuessX >= 1 && GuessX <= 10
                    && GuessY >= 1 && GuessY <= 10
                    && gameBoard[GuessY, GuessX] == " O ";
        }
    }
}
