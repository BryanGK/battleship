﻿using System;

namespace battleship
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            Player player = new Player();
            Battleship battleship = new Battleship();

            Console.Clear();
            Console.WriteLine("====----====----====----====----====----====----====----====----====");
            Console.WriteLine("| .'`+~~    o_.      ~~+`'._.'`+~~        o-_  ~~+`'._.'`+~~    ., |");
            Console.WriteLine("|  _o -_~~+`'._.'`+~~   ..__      ~~+`'._.'`+~~      ..     ~~+`'  |");
            Console.WriteLine("|                                                                  |");
            Console.WriteLine("|    ___o.o-      Welcome to C# console Battleship.    _-o--~      |");
            Console.WriteLine("|                                                                  |");
            Console.WriteLine("| ~~+`'._.'`+~~             ~~+`'._.'`+~~     ..o-    ~~+`'._.'`+  |");
            Console.WriteLine("| _o    o_- .  ~~+`'._.'`+~~    o.       ~~+`'._.'`+~~     o._     |");
            Console.WriteLine("====----====----====----====----====----====----====----====----====\n\n");
            Console.WriteLine("             >  To start the game press the SPACEBAR  <");

            var startGame = Console.ReadKey(true).KeyChar;
            var gameover = true;

            if (startGame == ' ')
            {
                gameover = false;

                Console.Clear();
                Console.WriteLine("\n\n");

                gameBoard.drawGameBoard();

                Console.WriteLine("Shots remaining: " + (Player.MAX_SHOTS - player.shots) + "\n");
                Console.WriteLine("Battleship lives remaining: " + battleship.lives + "\n");

                battleship.RandomShipLocation();
            }

            while (!gameover)
            {
                Console.Write("Please enter X horizontal coordinate from 1-10: ");

                if (int.TryParse(Console.ReadLine(), out int valueX))
                    player.guessX = valueX;

                Console.Write("\nPlease enter Y vertical coordinate from 1-10: ");

                if (int.TryParse(Console.ReadLine(), out int valueY))
                    player.guessY = valueY;

                if ((player.guessX < 1 || player.guessX > 10) || (player.guessY < 1 || player.guessY > 10))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t~ That was not a valid target ~ Please select a number from 1-10.\n\n");
                    Console.ResetColor();

                    gameBoard.drawGameBoard();

                    Console.WriteLine("Shots remaining: " + (Player.MAX_SHOTS - player.shots) + "\n");
                    Console.WriteLine("Battleship lives remaining: " + battleship.lives + "\n");
                }
                else
                {
                    if ((player.guessX == battleship.location1[0]
                        || player.guessX == battleship.location2[0]
                        || player.guessX == battleship.location3[0]
                        || player.guessX == battleship.location4[0]
                        || player.guessX == battleship.location5[0])
                        && (player.guessY == battleship.location1[1]
                        || player.guessY == battleship.location2[1]
                        || player.guessY == battleship.location3[1]
                        || player.guessY == battleship.location4[1]
                        || player.guessY == battleship.location5[1]))
                    {
                        if (gameBoard.gameBoardArr[player.guessY, player.guessX] == ">X<")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t~~ You already tried that one ~~ Please select a number from 1-10.\n\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            gameBoard.gameBoardArr[player.guessY, player.guessX] = ">X<";
                            battleship.lives--;
                            player.hits++;
                            player.shots++;

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\t--> HIT! <--\n\n");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        if (gameBoard.gameBoardArr[player.guessY, player.guessX] == "> <")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t~~ You already tried that position ~~ Please select a number from 1-10.\n\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            gameBoard.gameBoardArr[player.guessY, player.guessX] = "> <";
                            player.shots++;

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\t\t\t\t\t--> MISS! <--\n\n");
                            Console.ResetColor();
                        }
                    }

                    gameBoard.drawGameBoard();

                    Console.WriteLine("Shots remaining: " + (Player.MAX_SHOTS - player.shots) + "\n");
                    Console.WriteLine("Battleship lives remaining: " + battleship.lives + "\n");

                    if (player.hits == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t====>>>>    BATTLESHIP SUNK!   <<<<=====\n");
                        Console.ResetColor();

                        gameover = true;
                    }
                    if (Player.MAX_SHOTS - player.shots < battleship.lives)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t<<<<===   Not enough shots left! They got away!  ====>>>>\n");
                        Console.ResetColor();

                        gameover = true;
                    }

                }
                if (gameover)
                {
                    Console.Write("Play again Y?\n\nAny other key to exit.");
                    var input = Console.ReadKey(true).KeyChar;
                    if (input == 'y' || input == 'Y')
                    {
                        Console.Clear();

                        gameover = false;
                        gameBoard = new GameBoard();
                        player.ResetPlayer();
                        battleship.ResetLives();
                        battleship.RandomShipLocation();

                        Console.WriteLine("\n\n");

                        gameBoard.drawGameBoard();

                        Console.WriteLine("Shots remaining: " + (Player.MAX_SHOTS - player.shots) + "\n");
                        Console.WriteLine("Battleship lives remaining: " + battleship.lives + "\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n\t\t~~+`'._.'`+~~ Thanks for playing, goodbye ~~+`'._.'`+~~");
                    }
                }
            }
        }
        
    }
}
