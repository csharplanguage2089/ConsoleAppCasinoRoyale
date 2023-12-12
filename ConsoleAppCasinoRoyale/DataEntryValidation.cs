namespace ConsoleAppCasinoRoyale
{
    /// <summary>
    /// Проверка на ввод данных
    /// </summary>
    internal class DataEntryValidation
    {
        MemberNotifications notification = new MemberNotifications();

        /// <summary>
        /// Проверка на ввод данных ДА или НЕТ
        /// </summary>
        /// <returns></returns>
        public string FlagCheckYesOrNot()
        {
            while (true)
            {
                string a = notification.Rl();

                if (a == "y" || a == "n")
                {
                    return a;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    notification.Wl("Please, enter y or n");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Проверка на ввод данных ЧАСТИЧНАЯ СТАВКА или ВА-БАНК
        /// </summary>
        /// <returns></returns>
        public string FlagCheckPartOrAll()
        {
            while (true)
            {
                string a = notification.Rl();

                if (a == "part" || a == "all-in")
                {
                    return a;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    notification.Wl("Please, enter part or all-in");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Проверка на ввод числа
        /// </summary>
        /// <returns></returns>
        public int FlagCheckIsANumber()
        {
            while (true)
            {
                string a = notification.Rl();

                if (int.TryParse(a, out int b))
                {
                    return b;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    notification.Wl("Please, enter a number!");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Проверка на ввод данных ЧЕРНЫЙ, КРАСНЫЙ, ЗЕЛЕНЫЙ, ЗОЛОТОЙ или ВЫХОД
        /// </summary>
        /// <returns></returns>
        public string FlagCheckBlackRedGreenGold()
        {
            while (true)
            {
                string a = notification.Rl();

                if (a == "black" || a == "red" || a == "green" || a == "gold" || a == "out")
                {
                    return a;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    notification.Wl("Please, enter black, red, green, gold or out!");
                    Console.ResetColor();
                }
            }
        }
    }
}
