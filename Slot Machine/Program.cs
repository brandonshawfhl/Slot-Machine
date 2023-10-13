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
                    int moneyBeforeSpin = moneyCount;

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
                    bool winningLine = true;
                    for (int columnNumber = 0; columnNumber < COLUMN_SIZE; columnNumber++)
                    {
                        for (int rowNumber = 1; rowNumber < ROW_SIZE; rowNumber++)
                        {
                            if (slotMachine[0, columnNumber] != slotMachine[rowNumber, columnNumber])
                            {
                                winningLine = false;
                                break;
                            }
                        }
                    }

                    if (winningLine == true)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine($"Congratulations! You matched a row!");
                        moneyCount += userBet;
                        break;
                    }

                    //this section checks for a matching column
                    bool winningColumn = true;

                    for (int rowNumber = 0; rowNumber < ROW_SIZE; rowNumber++)
                    {
                        for (int columnNumber = 1; columnNumber < COLUMN_SIZE; columnNumber++)
                        {
                            if (slotMachine[rowNumber, 0] != slotMachine[rowNumber, columnNumber])
                            {
                                winningColumn = false;
                                break;
                            }
                        }
                    }

                    if (winningColumn == true)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine($"Congratulations! You matched a column!");
                        moneyCount += userBet;
                    }

                    //this section checks for the first way to match a diagonal (upper left to lower right)
                    bool winningFirstDiagonal = true;
                    for (int diagonalNumber = 1; diagonalNumber < DIAGONAL_SIZE; diagonalNumber++)
                    {

                        if (slotMachine[0, 0] != slotMachine[diagonalNumber, diagonalNumber])
                        {
                            winningFirstDiagonal = false;
                            break;
                        }
                    }

                    //this section checks for the second way to match a diagonal (upper right to lower left)
                    bool winningSecondDiagonal = true;
                    for (int diagonalNumber = 1; diagonalNumber < ROW_SIZE; diagonalNumber++)
                    {
                        if (slotMachine[0, (ROW_SIZE - 1)] != slotMachine[diagonalNumber, ROW_SIZE - 1 - diagonalNumber])
                        {
                            winningSecondDiagonal = false;
                            break;
                        }
                    }

                    if (winningFirstDiagonal == true || winningSecondDiagonal == true)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine($"Congratulations! You matched a diagonal!");
                        moneyCount += userBet;
                    }

                    else
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