using System.Runtime.CompilerServices;

namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        const int COLUMN_SIZE = 3;
        const int ROW_SIZE = 3;
        const int RANDOM_MAX = 10;
        static void Main(string[] args)
        {
            int moneyCount = 100;
            Console.WriteLine("Welcome to Virtual Slot Machine!");
            Console.WriteLine("Play to win big!");
            Console.WriteLine($"You have ${moneyCount} left to bet.\n");
            Console.WriteLine("How much money would you like to bet?");
            int userBet = 0;
            int userWinnings = userBet * 3;
            while (true)
            {
                userBet = Convert.ToInt32(Console.ReadLine());
                if (userBet <= 0)
                {
                    Console.WriteLine("Please bet at least $1.");
                }
            }
            moneyCount = moneyCount - userBet;

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

           

            Console.WriteLine("Sorry. Not this time!");
        }
    }
}