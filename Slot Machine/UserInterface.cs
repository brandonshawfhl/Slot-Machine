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

        public static string WinningRowMessage(string matchType)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine($"Congratulations! You matched a row!");
        }

    }
}
