namespace Slot_Machine
{
    internal class Logic
    {
        public static int CheckForWinningRows(int[,] slotMachine, int moneyCount, int userBet)
        {
            int winningRowCount = 0;
            bool winningRow;
            for (int rowNumber = 0; rowNumber < Constants.ROW_SIZE; rowNumber++)
            {
                winningRow = true;
                for (int columnNumber = 1; columnNumber < Constants.COLUMN_SIZE; columnNumber++)
                {
                    if (slotMachine[rowNumber, 0] != slotMachine[rowNumber, columnNumber])
                    {
                        winningRow = false;
                        break;
                    }
                }

                if (winningRow)
                {
                    moneyCount += (userBet * Constants.ROW_WINNING_MULTIPLIER);
                    winningRowCount += 1;
                }
            }
            return winningRowCount;
        }

        public static bool CheckForWinningRound(int numberOfWinningMatches)
        {
            bool losingRound = true;
            if (numberOfWinningMatches > 0)
            {
                losingRound = false;
            }
            return !losingRound;
        }
        public static int CheckForWinningColumns(int[,] slotMachine, int moneyCount, int userBet)
        {
            int winningColumnCount = 0;
            bool winningColumn;
            if (userBet > Constants.COLUMN_BET)
            {
                for (int columnNumber = 0; columnNumber < Constants.COLUMN_SIZE; columnNumber++)
                {
                    winningColumn = true;
                    for (int rowNumber = 1; rowNumber < Constants.ROW_SIZE; rowNumber++)
                    {
                        if (slotMachine[0, columnNumber] != slotMachine[rowNumber, columnNumber])
                        {
                            winningColumn = false;
                            break;
                        }
                    }

                    if (winningColumn)
                    {
                        moneyCount += (userBet * Constants.COLUMN_WINNING_MULTIPLIER);
                        winningColumnCount += 1;
                    }
                }
            }
            return winningColumnCount;
        }

        public static int CheckForWinningFirstDiagonal(int[,] slotMachine, int moneyCount, int userBet)
        {
            int winningFirstDiagonalCount = 0;
            bool winningFirstDiagonal;
            if (userBet >= Constants.FIRST_DIAGONAL_BET)
            {
                winningFirstDiagonal = true;
                for (int diagonalNumber = 1; diagonalNumber < Constants.DIAGONAL_SIZE; diagonalNumber++)
                {

                    if (slotMachine[0, 0] != slotMachine[diagonalNumber, diagonalNumber])
                    {
                        winningFirstDiagonal = false;
                        break;
                    }
                }

                if (winningFirstDiagonal)
                {
                    moneyCount += (userBet * Constants.DIAGONAL_WINNING_MULTIPIER);
                    winningFirstDiagonalCount += 1;
                }
            }
            return winningFirstDiagonalCount;
        }

        public static int CheckForWinningSecondDiagonal(int[,] slotMachine, int moneyCount, int userBet)
        {
            int winningSecondDiagonalCount = 0;
            bool winningSecondDiagonal = true;
            if (userBet >= Constants.SECOND_DIAGONAL_BET)
            {
                winningSecondDiagonal = true;
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
                    moneyCount += (userBet * Constants.DIAGONAL_WINNING_MULTIPIER);
                    winningSecondDiagonalCount += 1;
                }
            }
            return winningSecondDiagonalCount;
        }

        public static void PopulateSlotMachine(int[,] slotMachine)
        {

            for (int verticalNumber = 0; verticalNumber < Constants.ROW_SIZE; verticalNumber++)
            {
                for (int horizontalNumber = 0; horizontalNumber < Constants.COLUMN_SIZE; horizontalNumber++)
                {
                    slotMachine[verticalNumber, horizontalNumber] = Program.rng.Next(0, Constants.RANDOM_MAX);
                }
            }
        }
    }
}
