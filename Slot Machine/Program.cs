using System.Runtime.CompilerServices;

namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        const int COLUMN_SIZE = 3;
        const int ROW_SIZE = 3;
        const int RANDOM_MAX = 10;
        const char USER_YES_CHOICE = 'Y';
        static void Main(string[] args)
        {
            char playAgain = USER_YES_CHOICE;
            int moneyCount = 100;

            int userBet = 0;
            int userWinnings = userBet * 3;
            //loop for playing the game more than once
            do
            {
                Console.WriteLine("Welcome to Virtual Slot Machine!");
                Console.WriteLine("Play to win big!");
                // loop for running the slots until user runs out of money
                while (moneyCount > 0)
                {
                    Console.Clear();

                    if (moneyCount <= 0)
                    {
                        Console.WriteLine("Sorry it looks like your are flat broke! You lose!");
                    }
                    Console.WriteLine($"You have ${moneyCount} left to bet.\n");
                    Console.WriteLine("How much money would you like to bet?");
                    while (true)
                    {
                        userBet = Convert.ToInt32(Console.ReadLine());
                        if (userBet <= 0)
                        {
                            Console.WriteLine("Please bet at least $1.");
                        }
                    }
                    moneyCount = moneyCount - userBet;
                    int moneyBeforeSpin = moneyCount;

                    int[,] slotMachine = new int[COLUMN_SIZE, ROW_SIZE];

                    for (int verticalNumber = 0; verticalNumber < COLUMN_SIZE; verticalNumber++)
                    {
                        for (int horizontalNumber = 0; horizontalNumber < ROW_SIZE; horizontalNumber++)
                        {
                            slotMachine[verticalNumber, horizontalNumber] = rng.Next(0, RANDOM_MAX);
                        }
                    }

                    Console.WriteLine("\t" + slotMachine[0, 0] + slotMachine[0, 1] + slotMachine[0, 2]);
                    Console.WriteLine("\t" + slotMachine[1, 0] + slotMachine[1, 1] + slotMachine[1, 2]);
                    Console.WriteLine("\t" + slotMachine[2, 0] + slotMachine[2, 1] + slotMachine[2, 2]);

                    for (int rowNumber = 0; rowNumber < ROW_SIZE; rowNumber++)
                    {
                        for (int columnNumber = rowNumber; columnNumber < COLUMN_SIZE; columnNumber++)
                        {
                            if (slotMachine[columnNumber, rowNumber] != slotMachine[columnNumber + 1, rowNumber])
                            {
                                break;
                            }
                            Console.WriteLine($"Congratulations! Row {rowNumber} was a winner for you!");
                            moneyCount = moneyCount + userWinnings;
                        }
                    }

                    for (int columnNumber = 0; columnNumber < COLUMN_SIZE; columnNumber++)
                    {
                        for (int rowNumber = columnNumber; rowNumber < ROW_SIZE; rowNumber++)
                        {
                            if (slotMachine[rowNumber, columnNumber] != slotMachine[rowNumber + 1, columnNumber])
                            {
                                break;
                            }
                            Console.WriteLine($"Congratulations! Column {columnNumber} was a winner for you!");
                            moneyCount = moneyCount + userWinnings;
                        }
                    }

                    for (int diagonalNumber = 0; diagonalNumber < COLUMN_SIZE; diagonalNumber++)
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

                Console.WriteLine("\n");
                Console.WriteLine($"Would you like to play again?({USER_YES_CHOICE} or press any other key to exit the program)\n");
                playAgain = Char.ToUpper(Console.ReadKey(true).KeyChar);

            } while (playAgain == USER_YES_CHOICE);
        }
    }
}