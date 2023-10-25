﻿using System.Diagnostics;

namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        const int ROW_SIZE = 3;
        const int COLUMN_SIZE = 3;
        const int DIAGONAL_SIZE = 3;
        const int RANDOM_MAX = 10;
        const int STARTING_MONEY = 100;
        const int COLUMN_BET = 10;
        const int FIRST_DIAGONAL_BET = 30;
        const int SECOND_DIAGONAL_BET = 40;
        const int ROW_WINNING_MULTIPLIER = 2;
        const int COLUMN_WINNING_MULTIPLIER = 3;
        const int DIAGONAL_WINNING_MULTIPIER = 4;
        const char USER_YES_CHOICE = 'Y';
        static void Main(string[] args)
        {
            char playAgain = USER_YES_CHOICE;
            int userBet = 0;

            //loop for playing the game more than once
            do
            {
                UserInterface.WelcomeMessage();
                int moneyCount = STARTING_MONEY;
                // loop for running the slots until user runs out of money
                while (moneyCount > 0)
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine($"You have ${moneyCount} left to bet.\n");

                    while (true)
                    {
                        UserInterface.BettingRules();
                        userBet = Convert.ToInt32(Console.ReadLine());


                        if (userBet <= 0)
                        {
                            UserInterface.BetLessThan1();
                        }

                        else if (userBet > moneyCount)
                        {
                            UserInterface.NotEnoughMoney();
                        }

                        else
                        {
                            break;
                        }
                    }

                    moneyCount -= userBet;
                    bool losesRound = true;

                    Console.Clear();
                    int[,] slotMachine = new int[ROW_SIZE, COLUMN_SIZE];

                    for (int verticalNumber = 0; verticalNumber < ROW_SIZE; verticalNumber++)
                    {
                        Console.Write("\n\t");
                        for (int horizontalNumber = 0; horizontalNumber < COLUMN_SIZE; horizontalNumber++)
                        {
                            slotMachine[verticalNumber, horizontalNumber] = rng.Next(0, RANDOM_MAX);
                            Console.Write(slotMachine[verticalNumber, horizontalNumber]);
                        }
                    }

                    //this section checks for a matching row
                    bool winningRow = true;
                    for (int rowNumber = 0; rowNumber < ROW_SIZE; rowNumber++)
                    {
                        winningRow = true;
                        for (int columnNumber = 1; columnNumber < COLUMN_SIZE; columnNumber++)
                        {
                            if (slotMachine[rowNumber, 0] != slotMachine[rowNumber, columnNumber])
                            {
                                winningRow = false;
                                break;
                            }
                        }

                        if (winningRow == true)
                        {
                            UserInterface.WinningRowMessage();
                            moneyCount += (userBet * ROW_WINNING_MULTIPLIER);
                            losesRound = false;
                        }
                    }

                    //this section checks for a matching column
                    if (userBet > COLUMN_BET)
                    {
                        bool winningColumn = true;
                        for (int columnNumber = 0; columnNumber < COLUMN_SIZE; columnNumber++)
                        {
                            winningColumn = true;
                            for (int rowNumber = 1; rowNumber < ROW_SIZE; rowNumber++)
                            {
                                if (slotMachine[0, columnNumber] != slotMachine[rowNumber, columnNumber])
                                {
                                    winningColumn = false;
                                    break;
                                }
                            }

                            if (winningColumn == true)
                            {
                                UserInterface.WinningColumnMessage();
                                moneyCount += (userBet * COLUMN_WINNING_MULTIPLIER);
                                losesRound = false;
                            }
                        }
                    }

                    //this section checks for the first way to match a diagonal (upper left to lower right)
                    if (userBet >= FIRST_DIAGONAL_BET)
                    {
                        bool winningFirstDiagonal = true;
                        for (int diagonalNumber = 1; diagonalNumber < DIAGONAL_SIZE; diagonalNumber++)
                        {

                            if (slotMachine[0, 0] != slotMachine[diagonalNumber, diagonalNumber])
                            {
                                winningFirstDiagonal = false;
                                break;
                            }
                        }

                        if (winningFirstDiagonal == true)
                        {
                           UserInterface.WinningDiagonalMessage();
                            moneyCount += (userBet * DIAGONAL_WINNING_MULTIPIER);
                            losesRound = false;
                        }
                    }

                    //this section checks for the second way to match a diagonal (upper right to lower left)
                    if (userBet >= SECOND_DIAGONAL_BET)
                    {
                        bool winningSecondDiagonal = true;
                        for (int diagonalNumber = 1; diagonalNumber < ROW_SIZE; diagonalNumber++)
                        {
                            if (slotMachine[0, (ROW_SIZE - 1)] != slotMachine[diagonalNumber, ROW_SIZE - 1 - diagonalNumber])
                            {
                                winningSecondDiagonal = false;
                                break;
                            }
                        }

                        if (winningSecondDiagonal == true)
                        {
                            UserInterface.WinningDiagonalMessage();
                            moneyCount += (userBet * DIAGONAL_WINNING_MULTIPIER);
                            losesRound = false;
                        }
                    }

                    if (losesRound == true)
                    {
                        UserInterface.LosingSpinMessage();
                    }
                }

                UserInterface.UserOutOfMoney();

                Console.WriteLine("\n");
                Console.WriteLine($"Would you like to play again?({USER_YES_CHOICE} or press any other key to exit the program)\n");
                playAgain = Char.ToUpper(Console.ReadKey(true).KeyChar);
            } while (playAgain == USER_YES_CHOICE);
        }
    }
}