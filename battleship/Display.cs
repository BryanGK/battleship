using System;

namespace battleship
{
    class Display
    {
        public string[,] gameBoard = new string[11, 11]
        {
            { " # ", " 1.", " 2.", " 3.", " 4.", " 5.", " 6.", " 7.", " 8.", " 9.", " 10." },
            { " 1.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
            { " 2.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
            { " 3.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
            { " 4.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
            { " 5.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
            { " 6.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
            { " 7.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
            { " 8.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
            { " 9.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
            { "10.", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O ", " O " },
        };

        public void GameBoard()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == "> <")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        displayGridIcon(i, j);
                    }
                    else if (gameBoard[i, j] == ">X<")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        displayGridIcon(i, j);
                    }
                    else if (gameBoard[i, j] == " O ")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        displayGridIcon(i, j);
                    }
                    else
                        Console.Write(gameBoard[i, j] + " \t");
                }
                Console.WriteLine("\n \n");
            }
        }

        public void TitleStart()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\t====----====----====----====----====----====----====----====----====");
            Console.WriteLine("\t| .'`+~~    o_.      ~~+`'._.'`+~~        o-_  ~~+`'._.'`+~~    ., |");
            Console.WriteLine("\t|  _o -_~~+`'._.'`+~~   ..__      ~~+`'._.'`+~~      ..     ~~+`'  |");
            Console.WriteLine("\t|                                                                  |");
            Console.Write("\t|    ___o.o-");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("      Welcome to C# console Battleship.");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("    _-o--~      |");
            Console.WriteLine("\t|                                                                  |");
            Console.WriteLine("\t| ~~+`'._.'`+~~             ~~+`'._.'`+~~     ..o-    ~~+`'._.'`+  |");
            Console.WriteLine("\t| _o    o_- .  ~~+`'._.'`+~~    o.       ~~+`'._.'`+~~     o._     |");
            Console.WriteLine("\t====----====----====----====----====----====----====----====----====\n\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t             >  To start the game press the SPACEBAR  <\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t                      Any other key will exit");
            Console.ResetColor();
        }

        public void InitializeGameBoard(Player player, Battleship battleship)
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            ScoreBoard(player, battleship);
        }

        public void NotValidGuess(Player player, Battleship battleship)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t~ That was not a valid target ~ Please select a number from 1-10.\n\n");
            Console.ResetColor();
            ScoreBoard(player, battleship);
        }

        public void TargetHit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t   --> HIT! <--\n\n");
            Console.ResetColor();
        }

        public void TargetMiss()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t   <-- MISS! -->\n\n");
            Console.ResetColor();
        }

        public void BattleshipSunk()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t====>>>>    BATTLESHIP SUNK!   <<<<=====\n");
            Console.ResetColor();
        }

        public void BattleshipGotAway()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t<<<<===   Not enough shots left! They got away!  ====>>>>\n");
            Console.ResetColor();
        }

        public void ScoreBoard(Player player, Battleship battleship)
        {
            GameBoard();
            Console.WriteLine($"Shots remaining: {Player.maxShots - player.Shots}\n\nBattleship lives remaining: {battleship.Lives}\n");
        }

        public void PlayAgain()
        {
            Console.Write("\n\n\t\t\t\t     Play again Y?\n\n\t\t\t\tAny other key to exit.");
        }

        public void UpdateGameBoard(int guessX, int guessY, string icon)
        {
            gameBoard[guessY, guessX] = icon;
        }

        public void ResetGameBoard()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == ">X<" || gameBoard[i, j] == "> <")
                    {
                        gameBoard[i, j] = " O ";
                    }
                }
            }
        }

        public void TitleEnd()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n\n\n\n\t\t~~+`'._.'`+~~ ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Thanks for playing, goodbye");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("  ~~+`'._.'`+~~ ");

        }

        private void displayGridIcon(int i, int j)
        {
            Console.Write(gameBoard[i, j] + " \t");
            Console.ResetColor();
        }
    }
}
