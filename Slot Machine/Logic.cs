﻿namespace Slot_Machine
{
    internal class Logic
    {
        public static int moneyCount = Constants.STARTING_MONEY;
        public static bool losesRound;
        public static int [,] slotMachine = new int[Constants.ROW_SIZE, Constants.COLUMN_SIZE];
        public static bool winningRow = true;
        public static bool winningColumn = true;
        public static bool winningFirstDiagonal = true;
        public static bool winningSecondDiagonal = true;

        public static void CheckForValidBet()
        {
            
        }
    }
}
