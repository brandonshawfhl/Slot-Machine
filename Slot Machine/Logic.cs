namespace Slot_Machine
{
    internal class Logic
    {
        public static char playAgain = Constants.USER_YES_CHOICE;
        public static int userBet = 0;
        public static int moneyCount = Constants.STARTING_MONEY;
        public static bool losesRound;
        public static int[,] slotMachine = new int[Constants.ROW_SIZE, Constants.COLUMN_SIZE];
        public static bool winningRow = true;
        public static bool winningColumn = true;
        public static bool winningFirstDiagonal = true;
        public static bool winningSecondDiagonal = true;
    }
}
