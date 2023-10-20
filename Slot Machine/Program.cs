using System.Diagnostics;

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
                Console.Clear();
                int moneyCount = STARTING_MONEY;
                Console.WriteLine("Welcome to Virtual Slot Machine!");
                Console.WriteLine("Play to win big!");
                // loop for running the slots until user runs out of money
                while (moneyCount > 0)
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine($"You have ${moneyCount} left to bet.\n");

                    while (true)
                    {
                        Console.WriteLine("How much money would you like to bet?");
                        Console.WriteLine($"Bets less than {COLUMN_BET} will allow you to win only by matching rows.");
                        Console.WriteLine($"Bets higher than {COLUMN_BET} will allow you to match columns as well.");
                        Console.WriteLine($"Bets of at least {FIRST_DIAGONAL_BET} will allow for the first diagonal and bets of {SECOND_DIAGONAL_BET} or more will allow for both!");
                        userBet = Convert.ToInt32(Console.ReadLine());

                        if (userBet > 0 && userBet <= moneyCount)
                        {
                            break;
                        }

                        if (userBet <= 0)
                        {
                            Console.WriteLine("Please bet at least $1.\n");
                        }

                        if (userBet > moneyCount)
                        {
                            Console.WriteLine("You don't have that much money!\n");
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
                            Console.WriteLine("\n\n");
                            Console.WriteLine($"Congratulations! You matched a row!");
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
                                Console.WriteLine("\n\n");
                                Console.WriteLine($"Congratulations! You matched a column!");
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
                            Console.WriteLine("\n\n");
                            Console.WriteLine($"Congratulations! You matched a diagonal!");
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
                            Console.WriteLine("\n\n");
                            Console.WriteLine($"Congratulations! You matched a diagonal!");
                            moneyCount += (userBet * DIAGONAL_WINNING_MULTIPIER);
                            losesRound = false;
                        }
                    }

                    if (losesRound == true)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Sorry. Not this time!");
                    }
                }

                Console.WriteLine("\n\n");
                Console.WriteLine("Sorry it looks like your are flat broke! You lose!");

                Console.WriteLine("\n");
                Console.WriteLine($"Would you like to play again?({USER_YES_CHOICE} or press any other key to exit the program)\n");
                playAgain = Char.ToUpper(Console.ReadKey(true).KeyChar);
            } while (playAgain == USER_YES_CHOICE);
        }
    }
}