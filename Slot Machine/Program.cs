using System.Runtime.CompilerServices;

namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        const int ROW_SIZE = 3;
        const int COLUMN_SIZE = 3;
        const int ROW_NUMBER = 2;
        const int COLUMN_NUMBER = 2;
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

                    bool betIsNotValid = (userBet <= 0 || userBet > moneyCount);
                    do
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

                        else
                        {
                            betIsNotValid = false;
                        }
                    }
                    while (betIsNotValid == true);

                    moneyCount = moneyCount - userBet;
                    int moneyBeforeSpin = moneyCount;

                    Console.Clear();
                    int[,] slotMachine = new int[ROW_SIZE, COLUMN_SIZE];

                    for (int verticalNumber = 0; verticalNumber <= ROW_NUMBER; verticalNumber++)
                    {
                        Console.Write("\n\t");

                        for (int horizontalNumber = 0; horizontalNumber <= COLUMN_NUMBER; horizontalNumber++)
                        {
                            slotMachine[verticalNumber, horizontalNumber] = rng.Next(0, RANDOM_MAX);
                            Console.Write(slotMachine[verticalNumber, horizontalNumber]);
                        }
                    }

                    for (int columnNumber = 0; columnNumber <= COLUMN_NUMBER; columnNumber++)
                    {
                        for (int rowNumber = 0; rowNumber <= ROW_NUMBER; rowNumber++)
                        {
                            if (slotMachine[0, columnNumber] != slotMachine[rowNumber, columnNumber])
                            {
                                break;
                            }
                            Console.WriteLine($"Congratulations! Row {rowNumber} was a winner for you!");
                            moneyCount = moneyCount + userWinnings;
                        }
                    }

                    for (int rowNumber = 0; rowNumber <= ROW_NUMBER; rowNumber++)
                    {
                        for (int columnNumber = 0; columnNumber <= COLUMN_NUMBER; columnNumber++)
                        {
                            if (slotMachine[rowNumber, 0] != slotMachine[rowNumber, columnNumber])
                            {
                                break;
                            }
                            Console.WriteLine($"Congratulations! Column {columnNumber} was a winner for you!");
                            moneyCount = moneyCount + userWinnings;
                        }
                    }

                    for (int diagonalNumber = 0; diagonalNumber < ROW_NUMBER; diagonalNumber++)
                    {
                        if (slotMachine[diagonalNumber, diagonalNumber] != slotMachine[diagonalNumber + 1, diagonalNumber + 1])
                            break;
                    }
                    Console.WriteLine($"Congratulations! A diagonal was a winner for you!");
                    moneyCount = moneyCount + userWinnings;

                    if (moneyCount == moneyBeforeSpin)
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