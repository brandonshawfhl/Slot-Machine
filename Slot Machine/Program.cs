﻿using System.Diagnostics;

namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        
        static void Main(string[] args)
        {
            char playAgain = Constants.USER_YES_CHOICE;
            int userBet = 0;

            //loop for playing the game more than once
            do
            {
                UserInterface.WelcomeMessage();
                // loop for running the slots until user runs out of money
                while (moneyCount > 0)
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine($"You have ${Logic.moneyCount} left to bet.\n");

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
                    int[,] slotMachine = new int[Constants.ROW_SIZE, Constants.COLUMN_SIZE];

                    for (int verticalNumber = 0; verticalNumber < Constants.ROW_SIZE; verticalNumber++)
                    {
                        Console.Write("\n\t");
                        for (int horizontalNumber = 0; horizontalNumber < Constants.COLUMN_SIZE; horizontalNumber++)
                        {
                            slotMachine[verticalNumber, horizontalNumber] = rng.Next(0, Constants.RANDOM_MAX);
                            Console.Write(slotMachine[verticalNumber, horizontalNumber]);
                        }
                    }

                    //this section checks for a matching row
                    bool winningRow = true;
                    for (int rowNumber = 0; rowNumber < Constants.ROW_SIZE; rowNumber++)
                    {
                        winningRow = true;
                        for (int columnNumber = 1; columnNumber < Constants.COLUMN_SIZE; columnNumber++)
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
                            moneyCount += (userBet * Constants.ROW_WINNING_MULTIPLIER);
                            losesRound = false;
                        }
                    }

                    //this section checks for a matching column
                    if (userBet > Constants.COLUMN_BET)
                    {
                        bool winningColumn = true;
                        for (int columnNumber = 0; columnNumber < Constants.COLUMN_SIZE; columnNumber++)
                        {
                            winningColumn = true;
                            for (int rowNumber = 1; rowNumber < Constants.ROW_SIZE; rowNumber++)
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
                                moneyCount += (userBet * Constants.COLUMN_WINNING_MULTIPLIER);
                                losesRound = false;
                            }
                        }
                    }

                    //this section checks for the first way to match a diagonal (upper left to lower right)
                    if (userBet >= Constants.FIRST_DIAGONAL_BET)
                    {
                        bool winningFirstDiagonal = true;
                        for (int diagonalNumber = 1; diagonalNumber < Constants.DIAGONAL_SIZE; diagonalNumber++)
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
                            moneyCount += (userBet * Constants.DIAGONAL_WINNING_MULTIPIER);
                            losesRound = false;
                        }
                    }

                    //this section checks for the second way to match a diagonal (upper right to lower left)
                    if (userBet >= Constants.SECOND_DIAGONAL_BET)
                    {
                        bool winningSecondDiagonal = true;
                        for (int diagonalNumber = 1; diagonalNumber < Constants.ROW_SIZE; diagonalNumber++)
                        {
                            if (slotMachine[0, (Constants.ROW_SIZE - 1)] != slotMachine[diagonalNumber, Constants.ROW_SIZE - 1 - diagonalNumber])
                            {
                                winningSecondDiagonal = false;
                                break;
                            }
                        }

                        if (winningSecondDiagonal == true)
                        {
                            UserInterface.WinningDiagonalMessage();
                            moneyCount += (userBet * Constants.DIAGONAL_WINNING_MULTIPIER);
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
                Console.WriteLine($"Would you like to play again?({Constants.USER_YES_CHOICE} or press any other key to exit the program)\n");
                playAgain = Char.ToUpper(Console.ReadKey(true).KeyChar);
            } while (playAgain == Constants.USER_YES_CHOICE);
        }
    }
}