namespace Slot_Machine
{
    internal class UserInterface
    {
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
        


       

    }
}
