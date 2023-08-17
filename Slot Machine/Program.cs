namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        const int SLOT_MACHINE_SIZE = 3;
        const int RANDOM_MAX = 9;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Virtual Slot Machine!");
            Console.WriteLine("Play to win big!\n");

            int[,] slotMachine = new int[SLOT_MACHINE_SIZE, SLOT_MACHINE_SIZE];

            for (int verticalNumber = 0; verticalNumber < SLOT_MACHINE_SIZE; verticalNumber++)
            {
                slotMachine[verticalNumber, 0] = rng.Next(0, RANDOM_MAX);
                slotMachine[verticalNumber, 1] = rng.Next(0, RANDOM_MAX);
                slotMachine[verticalNumber, 2] = rng.Next(0, RANDOM_MAX);
            }

            // I couldn't figure out how to initialize the list with the array positions so I .added them
            List<int> topLine = new List<int>();
            topLine.Add(slotMachine[0,0]);
            topLine.Add(slotMachine[0,1]);
            topLine.Add(slotMachine[0,2]);

            List<int> middleLine = new List<int>();
            middleLine.Add(slotMachine[1,0]);
            middleLine.Add(slotMachine[1,1]);
            middleLine.Add(slotMachine[1,2]);

            List<int> bottomLine = new List<int>();
            bottomLine.Add(slotMachine[2,0]);
            bottomLine.Add(slotMachine[2,1]);
            bottomLine.Add(slotMachine[2,2]);

            Console.Write("\t");
            Console.Write(topLine[0]);
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
            }

            if (middleLine[0] == middleLine[1] && middleLine[1] == middleLine[2])
            {
                Console.WriteLine("Congratulations! You won big!");
            }

            if (bottomLine[0] == bottomLine[1] && bottomLine[1] == bottomLine[2])
            {
                Console.WriteLine("Congratulations! You won big!");
            }
        }

    }
}