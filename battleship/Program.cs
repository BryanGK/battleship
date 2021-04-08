using System;

namespace battleship
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            Display display = new Display();
            Player player = new Player();
            Battleship battleship = new Battleship();

            display.TitleStart();

            if (Console.ReadKey(true).KeyChar == ' ')
            {
                battleship.SetIsBattleshipSunk();
                display.InitializeGameBoard(player, battleship);
                battleship.RandomShipLocation();
            }

            while (!battleship.IsBattleshipSunk)
            {
                player.ReadGuess();

                if (!player.IsValidGuess(display.gameBoard))
                {
                    display.NotValidGuess(player, battleship);
                }
                else
                {
                    if (battleship.IsTargetHit(player.GuessX, player.GuessY))
                    {
                        display.UpdateGameBoard(player.GuessX, player.GuessY, ">X<");
                        battleship.TakeHit();
                        player.HitCount();
                        player.Shoot();
                        display.TargetHit();
                    }
                    else
                    {
                        display.UpdateGameBoard(player.GuessX, player.GuessY, "> <");
                        player.Shoot();
                        display.TargetMiss();
                    }

                    display.ScoreBoard(player, battleship);

                    if (player.Hits == 5)
                    {
                        display.BattleshipSunk();
                        battleship.SetIsBattleshipSunk();
                    }

                    if (Player.maxShots - player.Shots < battleship.Lives)
                    {
                        display.BattleshipGotAway();
                        battleship.SetIsBattleshipSunk();
                    }
                }

                if (battleship.IsBattleshipSunk)
                {
                    display.PlayAgain();
                    var input = char.ToUpper(Console.ReadKey(true).KeyChar);
                    if (input == 'Y')
                    {
                        Console.Clear();
                        battleship.SetIsBattleshipSunk(); 
                        display.ResetGameBoard();
                        player.ResetPlayer();
                        battleship.ResetLives();
                        battleship.RandomShipLocation();
                        Console.WriteLine("\n\n");
                        display.ScoreBoard(player, battleship);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.Clear();
            display.TitleEnd();
        }
    }
}
