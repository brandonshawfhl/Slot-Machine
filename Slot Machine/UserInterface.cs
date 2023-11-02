﻿namespace Slot_Machine
{
    internal class UserInterface
    {
        public static void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Virtual Slot Machine!");
            Console.WriteLine("Play to win big!");
        }

        public static void WinningRowMessage()
        {
            Console.WriteLine($"Congratulations! You matched a row!");
        }

        public static void WinningColumnMessage()
        {
            Console.WriteLine($"Congratulations! You matched a column!");
        }

        public static void WinningDiagonalMessage()
        {
            Console.WriteLine($"Congratulations! You matched a diagonal!");
        }

        public static void LosingSpinMessage()
        {
            Console.WriteLine($"Sorry. Not this time.");
        }

        public static void UserOutOfMoney()
        {
            Console.WriteLine("Sorry it looks like your are flat broke! You lose!");
        }

        public static void NotEnoughMoney()
        {
            Console.WriteLine("You don't have that much money!\n");
        }

        public static void BettingRules()
        {
            Console.WriteLine("How much money would you like to bet?");
            Console.WriteLine($"Bets less than {Constants.COLUMN_BET} will allow you to win only by matching rows.");
            Console.WriteLine($"Bets higher than {Constants.COLUMN_BET} will allow you to match columns as well.");
            Console.WriteLine($"Bets of at least {Constants.FIRST_DIAGONAL_BET} will allow for the first diagonal and bets of {Constants.SECOND_DIAGONAL_BET} or more will allow for both!");
        }

        public static string MoneyLeft(int moneyCount)
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

        } public static void Write2EmptyLines()
        {
            Console.WriteLine("\n\n");
        }

        public static void PrintSlotMachine()
        {

        }
    }
}
