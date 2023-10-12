﻿using System.Runtime.CompilerServices;

namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        const int ROW_SIZE = 3;
        const int COLUMN_SIZE = 3;
        const int DIAGONAL_SIZE = 3;
        const int RANDOM_MAX = 10;
        const char USER_YES_CHOICE = 'Y';
        static void Main(string[] args)
        {
            char playAgain = USER_YES_CHOICE;
            int moneyCount = 100;

            int userBet = 0;
            int userWinnings = userBet;
            //loop for playing the game more than once
            do
            {
                Console.WriteLine("Welcome to Virtual Slot Machine!");
                Console.WriteLine("Play to win big!");
                // loop for running the slots until user runs out of money
                while (moneyCount > 0)
                {
                    Console.WriteLine($"You have ${moneyCount} left to bet.\n");
                    Console.WriteLine("How much money would you like to bet?");

                    bool betIsNotValid = true;
                    while (betIsNotValid == true)
                    {
                        userBet = Convert.ToInt32(Console.ReadLine());

                        if (userBet <= 0)
                        {
                            Console.WriteLine("Please bet at least $1.\n");
                        }

                        if (userBet > moneyCount)
                        {
                            Console.WriteLine("You don't have that much money!\n");
                        }

                        if (userBet > 0 && userBet < moneyCount)
                        {
                            betIsNotValid = false;
                        }
                    }

                    moneyCount = moneyCount - userBet;
                    int moneyBeforeSpin = moneyCount;

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
                    bool winningLine = true;

                    for (int columnNumber = 0; columnNumber < COLUMN_SIZE; columnNumber++)
                    {
                        for (int rowNumber = 1; rowNumber < ROW_SIZE; rowNumber++)
                        {
                            if (slotMachine[0, columnNumber] != slotMachine[rowNumber, columnNumber])
                            {
                                winningLine = false;
                                break;
                            }
                        }
                    }

                    if (winningLine == true)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine($"Congratulations! You matched a row!");
                        moneyCount = moneyCount + userWinnings;
                        break;
                    }

                    //this section checks for a matching column
                    bool winningColumn = true;

                    for (int rowNumber = 0; rowNumber < ROW_SIZE; rowNumber++)
                    {
                        for (int columnNumber = 1; columnNumber < COLUMN_SIZE; columnNumber++)
                        {
                            if (slotMachine[rowNumber, 0] != slotMachine[rowNumber, columnNumber])
                            {
                                winningColumn = false;
                                break;
                            }
                        }
                    }

                    if (winningColumn == true)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine($"Congratulations! You matched a column!");
                        moneyCount = moneyCount + userWinnings;
                    }

                    //this section checks for the first way to match a diagonal (upper left to lower right)
                    bool winningFirstDiagonal = true;

                    for (int diagonalNumber = 1; diagonalNumber < DIAGONAL_SIZE; diagonalNumber++)
                    {

                        if (slotMachine[0, 0] != slotMachine[diagonalNumber, diagonalNumber])
                        {
                            winningFirstDiagonal = false;
                            break;
                        }
                    }

                    //this section checks for the second way to match a diagonal (upper right to lower left)
                    bool winningSecondDiagonal = true;

                    for (int rowNumber = 1; rowNumber <= ROW_SIZE; rowNumber++)
                    {
                        for (int columnNumber = 1; columnNumber >= 0; columnNumber--)
                        {
                            if (slotMachine[0, (COLUMN_SIZE - 1)] != slotMachine[rowNumber, columnNumber])
                            {
                                winningSecondDiagonal = false;
                                break;
                            }
                        }
                    }

                    if (winningFirstDiagonal == true || winningSecondDiagonal == true)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine($"Congratulations! You matched a diagonal!");
                        moneyCount = moneyCount + userWinnings;
                    }

                    if (moneyCount <= moneyBeforeSpin)
                    {
                        Console.WriteLine("Sorry. Not this time!");
                    }
                }

                if (moneyCount <= 0)
                {
                    Console.WriteLine("Sorry it looks like your are flat broke! You lose!");
                    break;
                }

                Console.WriteLine("\n");
                Console.WriteLine($"Would you like to play again?({USER_YES_CHOICE} or press any other key to exit the program)\n");
                playAgain = Char.ToUpper(Console.ReadKey(true).KeyChar);

            } while (playAgain == USER_YES_CHOICE);
        }
    }
}