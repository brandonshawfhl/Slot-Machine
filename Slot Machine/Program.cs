using System.Diagnostics;

namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();

        static void Main(string[] args)
        {
            char playAgain = Constants.USER_YES_CHOICE;

            int[,] slotMachine = new int[Constants.ROW_SIZE, Constants.COLUMN_SIZE];

            //loop for playing the game more than once
            do
            {
                UserInterface.WriteWelcomeMessage();
                int userBet = 0;
                int moneyCount = Constants.STARTING_MONEY;
                moneyCount = Constants.STARTING_MONEY;
                // loop for running the slots until user runs out of money
                while (moneyCount > 0)
                {
                    userBet = UserInterface.BetIsValid(moneyCount);
                    moneyCount -= userBet;

                    bool losesRound = true;

                    UserInterface.ClearUserOutput();

                    for (int verticalNumber = 0; verticalNumber < Constants.ROW_SIZE; verticalNumber++)
                    {
                        Console.Write("\n\t");
                        for (int horizontalNumber = 0; horizontalNumber < Constants.COLUMN_SIZE; horizontalNumber++)
                        {
                            slotMachine[verticalNumber, horizontalNumber] = Program.rng.Next(0, Constants.RANDOM_MAX);
                            Console.Write(slotMachine[verticalNumber, horizontalNumber]);
                        }
                    }

                    //this section checks for a matching row
                    int numberOfWinningRows = Logic.CheckForWinningRows(slotMachine, userBet, moneyCount);
                    losesRound = Logic.CheckForWinningRound(numberOfWinningRows);
                    UserInterface.WriteWinningRowMessage(numberOfWinningRows);

                    //this section checks for a matching column
                    int numberOfWinningColumns = Logic.CheckForWinningColumns(slotMachine, moneyCount, userBet);
                    losesRound = Logic.CheckForWinningRound(numberOfWinningColumns);
                    UserInterface.WriteWinningColumnMessage(numberOfWinningColumns);

                    //this section checks for the first way to match a diagonal (upper left to lower right)
                    int numberOfWinningFirstDiagonals = Logic.CheckForWinningFirstDiagonal(slotMachine, moneyCount, userBet);
                    losesRound = Logic.CheckForWinningRound(numberOfWinningFirstDiagonals);
                    UserInterface.WriteWinningDiagonalMessage();

                    //this section checks for the second way to match a diagonal (upper right to lower left)
                    if (userBet >= Constants.SECOND_DIAGONAL_BET)
                    {
                        bool winningSecondDiagonal = true;
                        for (int diagonalNumber = 1; diagonalNumber < Constants.ROW_SIZE; diagonalNumber++)
                        {
                            if (slotMachine[0, (Constants.ROW_SIZE - 1)] != slotMachine[diagonalNumber, Constants.ROW_SIZE - 1 - diagonalNumber])
                            {
                                winningSecondDiagonal = false;
                                break;
                            }
                        }

                        if (winningSecondDiagonal)
                        {
                            UserInterface.Write2EmptyLines();
                            UserInterface.WriteWinningDiagonalMessage();
                            moneyCount += (userBet * Constants.DIAGONAL_WINNING_MULTIPIER);
                            losesRound = false;
                        }
                    }

                    if (losesRound)
                    {
                        UserInterface.Write2EmptyLines();
                        UserInterface.WriteLosingSpinMessage();
                    }
                }
                UserInterface.WriteUserOutOfMoneyMessage();

                Console.WriteLine("\n");
                Console.WriteLine($"Would you like to play again?({Constants.USER_YES_CHOICE} or press any other key to exit the program)\n");
                playAgain = Char.ToUpper(Console.ReadKey(true).KeyChar);
            } while (playAgain == Constants.USER_YES_CHOICE);
        }
    }
}