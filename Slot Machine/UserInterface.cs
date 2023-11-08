namespace Slot_Machine
{
    internal class UserInterface
    {
        public static void WriteWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Virtual Slot Machine!");
            Console.WriteLine("Play to win big!");
        }

        public static void WriteWinningRowMessage(int numberOfWinningRows)
        {
            if (numberOfWinningRows == 1)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Congratulations! You matched a row!");
            }

            else if (numberOfWinningRows > 1)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Congratulations! You matched multiple rows!");
            }
        }

        public static void WriteWinningColumnMessage(int numberOfWinningColumns)
        {
            if (numberOfWinningColumns == 1)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Congratulations! You matched a column!");
            }

            else if (numberOfWinningColumns == 1)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Congratulations! You matched multiple columns!");
            }
        }

        public static void WriteWinningDiagonalMessage(int numberOfWinningDiagonals)
        {
            if (numberOfWinningDiagonals == 1)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Congratulations! You matched a diagonal!");
            }
        }

        public static void WriteLosingSpinMessage(bool losesRound)
        {
            if (losesRound)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Sorry. Not this time.\n\n");
            }
        }

        public static void WriteUserOutOfMoneyMessage()
        {
            Console.WriteLine("Sorry it looks like your are flat broke! You lose!");
        }

        public static string WriteMoneyLeftMessage(int moneyCount)
        {
            return $"You have${moneyCount} left to bet.\n";
        }

        public static void ClearUserOutput()
        {
            Console.Clear();
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine("\n");

        }
        public static void Write2EmptyLines()
        {
            Console.WriteLine("\n\n");
        }

        public static int BetIsValid(int moneyCount)
        {
            int validBet = 0;
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Bets less than {Constants.COLUMN_BET} will allow you to win only by matching rows.");
                Console.WriteLine($"Bets higher than {Constants.COLUMN_BET} will allow you to match columns as well.");
                Console.WriteLine($"Bets of at least {Constants.FIRST_DIAGONAL_BET} will allow for the first diagonal");
                Console.WriteLine($"and bets of {Constants.SECOND_DIAGONAL_BET} or more will allow for both!\n");
                Console.WriteLine("How much money would you like to bet?");
                validBet = Convert.ToInt32(Console.ReadLine());

                if (validBet <= 0)
                {
                    Console.WriteLine("Please bet at least $1.\n");
                }

                else if (validBet > moneyCount)
                {
                    Console.WriteLine("You don't have that much money!\n");
                }

                else
                {
                    break;
                }
            }
            return validBet;
        }

        public static char CheckIfUserWantsToPlayAgain()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like to play again?({Constants.USER_YES_CHOICE} or press any other key to exit the program)\n");
            char wantsToPlayAgain = Char.ToUpper(Console.ReadKey(true).KeyChar);
            return wantsToPlayAgain;
        }

        public static void WriteSlotMachine(int[,] slotMachine)
        {
            for (int verticalNumber = 0; verticalNumber < Constants.ROW_SIZE; verticalNumber++)
            {
                Console.Write("\n\t");
                for (int horizontalNumber = 0; horizontalNumber < Constants.COLUMN_SIZE; horizontalNumber++)
                {
                    Console.Write(slotMachine[verticalNumber, horizontalNumber]);
                }
            }
        }
    }
}

