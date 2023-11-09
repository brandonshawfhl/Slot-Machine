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

                    bool losesRound;

                    UserInterface.ClearUserOutput();

                    Logic.PopulateSlotMachine(slotMachine);
                    UserInterface.WriteSlotMachine(slotMachine);

                    //this section checks for a matching row
                    int numberOfWinningRows = Logic.CheckForWinningRows(slotMachine);
                    UserInterface.WriteWinningRowMessage(numberOfWinningRows);
                    if (numberOfWinningRows > 0)
                    {
                        moneyCount += (userBet * numberOfWinningRows * Constants.ROW_WINNING_MULTIPLIER);
                    }

                    //this section checks for a matching column
                    int numberOfWinningColumns = Logic.CheckForWinningColumns(slotMachine, userBet);
                    UserInterface.WriteWinningColumnMessage(numberOfWinningColumns);
                    if (numberOfWinningColumns > 0)
                    {
                        moneyCount += (userBet * numberOfWinningColumns * Constants.COLUMN_WINNING_MULTIPLIER);
                    }

                    //this section checks for the first way to match a diagonal (upper left to lower right)
                    int numberOfWinningFirstDiagonals = Logic.CheckForWinningFirstDiagonal(slotMachine, userBet);
                    UserInterface.WriteWinningFirstDiagonalMessage(numberOfWinningFirstDiagonals);
                    if (numberOfWinningFirstDiagonals > 0)
                    {
                        moneyCount += (userBet * numberOfWinningFirstDiagonals * Constants.DIAGONAL_WINNING_MULTIPIER);
                    }

                    //this section checks for the second way to match a diagonal (upper right to lower left)
                    int numberOfWinningSecondDiagonals = Logic.CheckForWinningSecondDiagonal(slotMachine, userBet);
                    UserInterface.WriteWinningSecondDiagonalMessage(numberOfWinningSecondDiagonals);
                    if (numberOfWinningSecondDiagonals > 0)
                    {
                        moneyCount += (userBet * numberOfWinningSecondDiagonals * Constants.DIAGONAL_WINNING_MULTIPIER);
                    }

                    losesRound = Logic.CheckForWinningRound(numberOfWinningRows, numberOfWinningColumns, numberOfWinningFirstDiagonals, numberOfWinningSecondDiagonals);
                    UserInterface.WriteLosingSpinMessage(losesRound);
                }
                UserInterface.WriteUserOutOfMoneyMessage();

                playAgain = UserInterface.CheckIfUserWantsToPlayAgain();
            } while (playAgain == Constants.USER_YES_CHOICE);
        }
    }
}