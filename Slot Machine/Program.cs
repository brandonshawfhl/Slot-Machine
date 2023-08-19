using System.Runtime.CompilerServices;

namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        const int COLUMN_SIZE = 3;
        const int ROW_SIZE = 3;
        const int RANDOM_MAX = 10;
        const int WINNINGS = 10;
        static void Main(string[] args)
        {
            int moneyCount = 100;
            Console.WriteLine("Welcome to Virtual Slot Machine!");
            Console.WriteLine("Play to win big!");
            Console.WriteLine($"You have ${moneyCount} left to bet.\n");
            Console.WriteLine("How much money would you like to bet?");
            int userBet = 0;
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

            Console.Write("\t");
            Console.Write(slotMachine[0, 0]);
            Console.Write(topLine[1]);
            Console.WriteLine(topLine[2]);
            Console.Write("\t");
            Console.Write(middleLine[0]);
            Console.Write(middleLine[1]);
            Console.WriteLine(middleLine[2]);
            Console.Write("\t");
            Console.Write(bottomLine[0]);
            Console.Write(bottomLine[1]);
            Console.WriteLine(bottomLine[2]);

            if (topLine[0] == topLine[1] && topLine[1] == topLine[2])
            {
                Console.WriteLine("Congratulations! You won big!");
                moneyCount = moneyCount + WINNINGS;
            }

            if (middleLine[0] == middleLine[1] && middleLine[1] == middleLine[2])
            {
                Console.WriteLine("Congratulations! You won big!");
                moneyCount = moneyCount + WINNINGS;
            }

            if (bottomLine[0] == bottomLine[1] && bottomLine[1] == bottomLine[2])
            {
                Console.WriteLine("Congratulations! You won big!");
                moneyCount = moneyCount + WINNINGS;
            }

            Console.WriteLine("Sorry. Not this time!");
        }
    }
}