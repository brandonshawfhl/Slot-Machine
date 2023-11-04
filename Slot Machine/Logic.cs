namespace Slot_Machine
{
    internal class Logic
    {
        public static int SubtractBet(int moneyCount, int userBet)
        {
            moneyCount -= userBet;
            return moneyCount;
        }

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
            return winningRowCount & moneyCount;
        }

        public static bool WinningRound(int numberOfWinningMatches, bool losesRound)
        {
            if (numberOfWinningMatches > 0)
            {
                losesRound = false;
            }
            return losesRound;
        }
    }
}
