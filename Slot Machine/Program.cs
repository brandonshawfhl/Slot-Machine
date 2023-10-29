using System.Diagnostics;

namespace Slot_Machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        
        static void Main(string[] args)
        {
            Logic.userBet = 0;
           
            //loop for playing the game more than once
            do
            {
                UserInterface.WelcomeMessage();
                // loop for running the slots until user runs out of money
                while (Logic.moneyCount > 0)
                {
                  UserInterface.MoneyLeft();

                    while (true)
                    {
                        UserInterface.BettingRules();
                        Logic.userBet = Convert.ToInt32(Console.ReadLine());


                        if (Logic.userBet <= 0)
                        {
                            UserInterface.BetLessThan1();
                        }

                        else if (Logic.userBet > Logic.moneyCount)
                        {
                            UserInterface.NotEnoughMoney();
                        }

                        else
                        {
                            break;
                        }
                    }

                    Logic.moneyCount -= Logic.userBet;
                    Logic.losesRound = true;

                    Console.Clear();
                    Logic.slotMachine = new int[Constants.ROW_SIZE, Constants.COLUMN_SIZE];

                    for (int verticalNumber = 0; verticalNumber < Constants.ROW_SIZE; verticalNumber++)
                    {
                        Console.Write("\n\t");
                        for (int horizontalNumber = 0; horizontalNumber < Constants.COLUMN_SIZE; horizontalNumber++)
                        {
                            Logic.slotMachine[verticalNumber, horizontalNumber] = rng.Next(0, Constants.RANDOM_MAX);
                            Console.Write(Logic.slotMachine[verticalNumber, horizontalNumber]);
                        }
                    }

                    //this section checks for a matching row
                    bool winningRow = true;
                    for (int rowNumber = 0; rowNumber < Constants.ROW_SIZE; rowNumber++)
                    {
                        winningRow = true;
                        for (int columnNumber = 1; columnNumber < Constants.COLUMN_SIZE; columnNumber++)
                        {
                            if (Logic.slotMachine[rowNumber, 0] != Logic.slotMachine[rowNumber, columnNumber])
                            {
                                winningRow = false;
                                break;
                            }
                        }

                        if (winningRow == true)
                        {
                            UserInterface.WinningRowMessage();
                            Logic.moneyCount += (Logic.userBet * Constants.ROW_WINNING_MULTIPLIER);
                            Logic.losesRound = false;
                        }
                    }

                    //this section checks for a matching column
                    if (Logic.userBet > Constants.COLUMN_BET)
                    {
                        bool winningColumn = true;
                        for (int columnNumber = 0; columnNumber < Constants.COLUMN_SIZE; columnNumber++)
                        {
                            winningColumn = true;
                            for (int rowNumber = 1; rowNumber < Constants.ROW_SIZE; rowNumber++)
                            {
                                if (Logic.slotMachine[0, columnNumber] != Logic.slotMachine[rowNumber, columnNumber])
                                {
                                    winningColumn = false;
                                    break;
                                }
                            }

                            if (winningColumn == true)
                            {
                                UserInterface.WinningColumnMessage();
                                Logic.moneyCount += (Logic.userBet * Constants.COLUMN_WINNING_MULTIPLIER);
                                Logic.losesRound = false;
                            }
                        }
                    }

                    //this section checks for the first way to match a diagonal (upper left to lower right)
                    if (Logic.userBet >= Constants.FIRST_DIAGONAL_BET)
                    {
                        bool winningFirstDiagonal = true;
                        for (int diagonalNumber = 1; diagonalNumber < Constants.DIAGONAL_SIZE; diagonalNumber++)
                        {

                            if (Logic.slotMachine[0, 0] != Logic.slotMachine[diagonalNumber, diagonalNumber])
                            {
                                winningFirstDiagonal = false;
                                break;
                            }
                        }

                        if (winningFirstDiagonal == true)
                        {
                           UserInterface.WinningDiagonalMessage();
                            Logic.moneyCount += (Logic.userBet * Constants.DIAGONAL_WINNING_MULTIPIER);
                            Logic.losesRound = false;
                        }
                    }

                    //this section checks for the second way to match a diagonal (upper right to lower left)
                    if (Logic.userBet >= Constants.SECOND_DIAGONAL_BET)
                    {
                        bool winningSecondDiagonal = true;
                        for (int diagonalNumber = 1; diagonalNumber < Constants.ROW_SIZE; diagonalNumber++)
                        {
                            if (Logic.slotMachine[0, (Constants.ROW_SIZE - 1)] != Logic.slotMachine[diagonalNumber, Constants.ROW_SIZE - 1 - diagonalNumber])
                            {
                                winningSecondDiagonal = false;
                                break;
                            }
                        }

                        if (winningSecondDiagonal == true)
                        {
                            UserInterface.WinningDiagonalMessage();
                            Logic.moneyCount += (Logic.userBet * Constants.DIAGONAL_WINNING_MULTIPIER);
                            Logic.losesRound = false;
                        }
                    }

                    if (Logic.losesRound == true)
                    {
                        UserInterface.LosingSpinMessage();
                    }
                }

                UserInterface.UserOutOfMoney();

                Console.WriteLine("\n");
                Console.WriteLine($"Would you like to play again?({Constants.USER_YES_CHOICE} or press any other key to exit the program)\n");
                Logic.playAgain = Char.ToUpper(Console.ReadKey(true).KeyChar);
            } while (Logic.playAgain == Constants.USER_YES_CHOICE);
        }
    }
}