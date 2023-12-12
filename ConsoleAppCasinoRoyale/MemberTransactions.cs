namespace ConsoleAppCasinoRoyale
{
    /// <summary>
    /// Транзакции
    /// </summary>
    internal class MemberTransactions
    {
        DataEntryValidation validation = new DataEntryValidation();
        MemberNotifications notification = new MemberNotifications();

        /// <summary>
        /// Резерв денежных средств игрока
        /// </summary>
        /// <param name="desiredBet">Ставка игрока</param>
        /// <param name="argCasinoMembers">Денежные средства игрока</param>
        /// <returns></returns>
        public int PlayerBetReserve(int desiredBet, CasinoMembers argCasinoMembers)
        {
            while (true)
            {
                desiredBet = validation.FlagCheckIsANumber();

                if (desiredBet > argCasinoMembers.playerCash)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    notification.Wl("Your bet exceeds your funds"); // Ваша ставка превышает ваши средства
                    Console.ResetColor();
                }
                else if (desiredBet <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    notification.Wl("You can't bet zero or minus bet"); // Вы не можете поставить ноль или минус
                    Console.ResetColor();
                }
                else if (desiredBet <= argCasinoMembers.playerCash)
                {
                    argCasinoMembers.playerCash = argCasinoMembers.playerCash - desiredBet;
                    return desiredBet;
                }
            }
        }
    }
}
