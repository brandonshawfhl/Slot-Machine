namespace Slot_Machine
{
    internal class Logic
    {
        public static int SubtractBet(int moneyCount, int userBet)
        {
            moneyCount -= userBet;
            return moneyCount;
        }
    }
}
