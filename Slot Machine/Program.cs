namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        const int RANDOM_MAX = 9;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Virtual Slot Machine!");
            Console.WriteLine("Play to win big!\n");

            int[,] slotMachine = new int[3, 3];

            for (int verticalNumber = 0; verticalNumber < 3; verticalNumber++)
            {
                slotMachine[verticalNumber, 0] = rng.Next(0, RANDOM_MAX);
                slotMachine[verticalNumber, 1] = rng.Next(0, RANDOM_MAX);
                slotMachine[verticalNumber, 2] = rng.Next(0, RANDOM_MAX);
            }

            List<int> topLine = new List<int>();  
            List<int> middleLine = new List<int>();
            List<int> bottomLine = new List<int>();


            Console.Write("\t");
            Console.Write(slotMachine[0, 0] + " ");
            Console.Write(slotMachine[0, 1] + " ");
            Console.WriteLine(slotMachine[0, 2]);
            Console.Write("\t");
            Console.Write(slotMachine[1, 0] + " ");
            Console.Write(slotMachine[1, 1] + " ");
            Console.WriteLine(slotMachine[1, 2]);
            Console.Write("\t");
            Console.Write(slotMachine[2, 0] + " ");
            Console.Write(slotMachine[2, 1] + " ");
            Console.WriteLine(slotMachine[2, 2]);
        }

    }
}