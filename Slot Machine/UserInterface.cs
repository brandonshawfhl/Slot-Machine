namespace Slot_Machine
{
    internal class UserInterface
    {
        /// <summary>
        /// Writes a message welcoming user to the game.
        /// </summary>
        public static void WriteWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Virtual Slot Machine!");
            Console.WriteLine("Play to win big!");
        }

        /// <summary>
        /// Writes a set message when the user matches a row and then a different message telling them how many rows they have matched if they match more than one.
        /// </summary>
        /// <param name="numberOfWinningRows">the number of matching rows</param>
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
                Console.WriteLine($"Congratulations! You matched {numberOfWinningRows} rows!");
            }
        }

        /// <summary>
        /// Writes a set message when the user matches a column and then a different message telling them how many 
        /// columns they have matched if they match more than one.
        /// </summary>
        /// <param name="numberOfWinningColumns">number of matching columns</param>
        public static void WriteWinningColumnMessage(int numberOfWinningColumns)
        {
            if (numberOfWinningColumns == 1)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Congratulations! You matched a column!");
            }

            else if (numberOfWinningColumns > 1)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Congratulations! You matched {numberOfWinningColumns} columns!");
            }
        }

        /// <summary>
        /// Writes a message telling the user when they match the first diagonal (top left to bottom right).
        /// </summary>
        /// <param name="numberOfWinningFirstDiagonals">number of matching first diagonals</param>
        public static void WriteWinningFirstDiagonalMessage(int numberOfWinningFirstDiagonals)
        {
            if (numberOfWinningFirstDiagonals == 1)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Congratulations! You matched the first diagonal!");
            }
        }

        /// <summary>
        /// Writes a message telling the user when they match the second diagonal (bottom left to top right).
        /// </summary>
        /// <param name="numberOfWinningSecondDiagonals">number of matching second diagonals</param>
        public static void WriteWinningSecondDiagonalMessage(int numberOfWinningSecondDiagonals)
        {
            if (numberOfWinningSecondDiagonals == 1)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Congratulations! You matched the second diagonal!");
            }
        }

        /// <summary>
        /// Writes a message when the user fails to match anything at all.
        /// </summary>
        /// <param name="losesRound">whether or not the user lost the round (true or false)</param>
        public static void WriteLosingSpinMessage(bool losesRound)
        {
            if (losesRound)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Sorry. Not this time.");
            }
        }

        /// <summary>
        /// Writes a message informing the user they have completely run out of money and the game is over.
        /// </summary>
        public static void WriteUserOutOfMoneyMessage()
        {
            Console.WriteLine("Sorry it looks like your are flat broke! You lose!");
        }

        /// <summary>
        /// Clears all of the previous output to the user.
        /// </summary>
        public static void ClearUserOutput()
        {
            Console.Clear();
        }

        /// <summary>
        /// Writes a message explainging the rules of the game,informs the user of how much money they have left,
        /// asks the user how much they would like to bet and then accepts user input dictating the amount of money
        /// they would like to bet. There are then conditions for what constitutes a valid bet. The bet must be
        /// at least $1 and less than or equal to the amount of money they currently retain.
        /// </summary>
        /// <param name="moneyCount">the amount of money the user currently retains</param>
        /// <returns>the amount of money the user would like to bet</returns>
        public static int GetValidBet(int moneyCount)
        {
            int validBet = 0;
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Bets less than {Constants.COLUMN_BET} will allow you to win only by matching rows.");
                Console.WriteLine($"Bets higher than {Constants.COLUMN_BET} will allow you to match columns as well.");
                Console.WriteLine($"Bets of at least {Constants.FIRST_DIAGONAL_BET} will allow for the first diagonal");
                Console.WriteLine($"and bets of {Constants.SECOND_DIAGONAL_BET} or more will allow for both!\n");
                Console.WriteLine($"You have ${moneyCount} left. How much money would you like to bet?");
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

        /// <summary>
        /// Asks if the user would like to play again and then gives instructions on how to answer the question.
        /// </summary>
        /// <returns>whether or not the user would like to play again (true or false)</returns>
        public static char IsPlayAgain()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like to play again?({Constants.USER_YES_CHOICE} or press any other key to exit the program)\n");
            char wantsToPlayAgain = Char.ToUpper(Console.ReadKey(true).KeyChar);
            return wantsToPlayAgain;
        }

        /// <summary>
        /// Outputs the array to the user.
        /// </summary>
        /// <param name="slotMachine">the array</param>
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

