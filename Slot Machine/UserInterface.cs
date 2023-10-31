namespace Slot_Machine
{
    internal class UserInterface
    {
        const int COLUMN_BET = 10;
        const int FIRST_DIAGONAL_BET = 30;
        const int SECOND_DIAGONAL_BET = 40;

        public static void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Virtual Slot Machine!");
            Console.WriteLine("Play to win big!");
        }

        public static void WinningRowMessage()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine($"Congratulations! You matched a row!");
        }

        public static void WinningColumnMessage()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine($"Congratulations! You matched a column!");
        }

        public static void WinningDiagonalMessage()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine($"Congratulations! You matched a diagonal!");
        }

        public static void LosingSpinMessage()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine($"Sorry. Not this time.");
        }

        public static void UserOutOfMoney()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Sorry it looks like your are flat broke! You lose!");
        }

        public static void BetLessThan1()
        {
            Console.WriteLine("Please bet at least $1.\n");
        }

        public static void NotEnoughMoney()
        {
            Console.WriteLine("You don't have that much money!\n");
        }

        public static void BettingRules()
        {
            Console.WriteLine("How much money would you like to bet?");
            Console.WriteLine($"Bets less than {COLUMN_BET} will allow you to win only by matching rows.");
            Console.WriteLine($"Bets higher than {COLUMN_BET} will allow you to match columns as well.");
            Console.WriteLine($"Bets of at least {FIRST_DIAGONAL_BET} will allow for the first diagonal and bets of {SECOND_DIAGONAL_BET} or more will allow for both!");
        }

        public static string MoneyLeft(int moneyCount)
        {
            return $"\n\n\n You have${moneyCount} left to bet.\n";
        }

        public static void PrintSlotMachine()
        {
            
        }
    }
}
