namespace ConsoleAppCasinoRoyale
{
    /// <summary>
    /// Сообщения и ввод данных
    /// </summary>
    internal class MemberNotifications
    {
        /// <summary>
        /// Обычное текстовое сообщение string
        /// </summary>
        /// <param name="wl"></param>
        public void Wl(string wl)
        {
            Console.WriteLine(wl);
        }

        /// <summary>
        /// Обычное текстовое сообщение int
        /// </summary>
        /// <param name="wl"></param>
        public void Wl(int wl)
        {
            Console.WriteLine(wl);
        }

        /// <summary>
        /// Оставить сообщение string
        /// </summary>
        /// <returns></returns>
        public string Rl()
        {
            return Console.ReadLine();
        }
    }
}
