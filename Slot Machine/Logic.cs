﻿namespace Slot_Machine
{
    internal class Logic
    {
        public static int GetWinningRows(int[,] slotMachine)
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
                    winningRowCount += 1;
                }
            }
            return winningRowCount;
        }

        public static bool isWinningRound(int numberOfWinningRows, int numberOfWinningColumns, int numberOfWinningFirstDiagonals, int numberOfWinningSecondDiagonals)
        {
            bool losingRound = true;
            if (numberOfWinningRows + numberOfWinningColumns + numberOfWinningFirstDiagonals + numberOfWinningSecondDiagonals > 0)
            {
                losingRound = false;
            }
            return losingRound;
        }
        public static int GetWinningColumns(int[,] slotMachine, int userBet)
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
                        winningColumnCount += 1;
                    }
                }
            }
            return winningColumnCount;
        }

        public static int GetWinningFirstDiagonal(int[,] slotMachine, int userBet)
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
                    winningFirstDiagonalCount += 1;
                }
            }
            return winningFirstDiagonalCount;
        }

        public static int GetWinningSecondDiagonal(int[,] slotMachine, int userBet)
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
