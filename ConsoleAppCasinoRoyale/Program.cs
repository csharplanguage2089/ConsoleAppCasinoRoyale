using ConsoleAppCasinoRoyale;

internal class Program
{
    private static void Main(string[] args)
    {
        CasinoMembers casinoMember = new CasinoMembers();
        DataEntryValidation validation = new DataEntryValidation();
        MemberNotifications notification = new MemberNotifications();
        MemberTransactions transaction = new MemberTransactions();
        Random random = new Random();

        notification.Wl("Welcome to Casino Royale! Please, play and win and don't leave with anything!");
        notification.Wl("Let's rock!");
        notification.Wl("What is your name?");

        casinoMember.croupierName = "Barry";

        casinoMember.playerCash = 100;
        casinoMember.croupierCash = 10000;

        string nPlayer = notification.Rl();
        string nCroupier = casinoMember.croupierName;

        int bet = 0;
        int round = 0;

        notification.Wl("Your name: " + nPlayer + ". Your balance: " + casinoMember.playerCash + "$");
        notification.Wl("Your croupier: " + nCroupier + ". It's balance: " + casinoMember.croupierCash + "$");

        while (true)
        {
            notification.Wl("Make a bet? y/n");
            string messageInput = validation.FlagCheckYesOrNot();

            if (messageInput == "y")
            {
                while (true)
                {
                    notification.Wl("Make a partial bet or go all-in? part/all-in");
                    messageInput = validation.FlagCheckPartOrAll();

                    if (messageInput == "part")
                    {
                        while (true)
                        {
                            notification.Wl("How much do you want to bet, " + nPlayer + "?");

                            bet = transaction.PlayerBetReserve(bet, casinoMember);

                            notification.Wl("Player's bet: " + bet + "$");
                            notification.Wl("Your balance: " + casinoMember.playerCash + "$");
                            notification.Wl("Do you choose black, red, green or gold? black/red/green/gold/out");

                            messageInput = validation.FlagCheckBlackRedGreenGold();

                            if (messageInput == "out")
                            {
                                casinoMember.playerCash = casinoMember.playerCash + bet;
                                notification.Wl("out: Refund rate: " + bet + "$");
                                notification.Wl("out: Your balance: " + casinoMember.playerCash + "$");
                                break;
                            }

                            // Chance 1 to 5, minValue 1, but not including maxValue 6
                            int blackRedGreenGold = random.Next(1, 6);
                            string blackRedGreenGoldS;

                            if (blackRedGreenGold == 1) { blackRedGreenGoldS = "black"; }
                            else if (blackRedGreenGold == 2) { blackRedGreenGoldS = "red"; }
                            else if (blackRedGreenGold == 3) { blackRedGreenGoldS = "green"; }
                            else if (blackRedGreenGold == 4) { blackRedGreenGoldS = "gold"; }
                            else { blackRedGreenGoldS = "nothing"; }

                            // Game
                            if (messageInput == blackRedGreenGoldS)
                            {
                                // Result win
                                casinoMember.playerCash = casinoMember.playerCash + (bet * 2);
                                casinoMember.croupierCash = casinoMember.croupierCash - bet;

                                Console.ForegroundColor = ConsoleColor.Green;
                                notification.Wl("YOU WIN! Your winnings amounted to: " + (bet * 2) + "$");
                                Console.ResetColor();
                            }
                            else
                            {
                                // Result lose
                                casinoMember.croupierCash = casinoMember.croupierCash + bet;

                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                notification.Wl("YOU LOSE! Your loss made up your bet: " + bet + "$");
                                Console.ResetColor();
                            }
                            // Summarizing
                            notification.Wl("Your balance: " + casinoMember.playerCash + "$");
                            notification.Wl(nCroupier + "'s balance: " + casinoMember.croupierCash + "$");

                            round++;
                            notification.Wl("Rounds played: " + round);

                            if (bet > casinoMember.playerCash && casinoMember.playerCash != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                notification.Wl("You don't have enough funds to play! Your balance: " + casinoMember.playerCash + "$");
                                Console.ResetColor();
                                break;
                            }
                            // Ending the game in case of bankruptcy
                            if (casinoMember.playerCash == 0) { notification.Wl("You lost all your money..."); return; }
                        }
                    }
                    else if (messageInput == "all-in")
                    {
                        notification.Wl("In all or nothing mode, you bet all your money. Chance of winning is 1 in 9. Winnings are multiplied by 10");
                        notification.Wl("Continue? y/n");

                        messageInput = validation.FlagCheckYesOrNot();

                        if (messageInput == "y")
                        {
                            bet = casinoMember.playerCash;

                            // Chance 1 to 9, minValue 1, but not including maxValue 4
                            int allInLeft = random.Next(1, 4);
                            int allInRight = random.Next(1, 4);

                            if (allInLeft == 1) { allInLeft = 1; }
                            else if (allInLeft == 2) { allInLeft = 2; }
                            else { allInLeft = 3; }

                            if (allInRight == 1) { allInRight = 1; }
                            else if (allInRight == 2) { allInRight = 2; }
                            else { allInRight = 3; }

                            // Game
                            if (allInLeft == allInRight)
                            {
                                // Result win
                                Console.ForegroundColor = ConsoleColor.Green;
                                notification.Wl("YOU WIN! Your winnings amounted to: " + (bet * 10) + "$");
                                Console.ResetColor();

                                // Summarizing
                                casinoMember.playerCash = bet * 10;
                            }
                            else
                            {
                                // Result lose
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                notification.Wl("YOU LOSE! Your loss made up your bet: " + bet + "$");
                                Console.ResetColor();

                                // Summarizing
                                casinoMember.playerCash = 0;
                            }
                        }
                        else if (messageInput == "n")
                        {
                            notification.Wl("Be braver next time!");
                            break;
                        }
                    }
                    // Ending the game in case of bankruptcy
                    if (casinoMember.playerCash == 0) { notification.Wl("You lost all your money..."); return; }
                }
            }
            else if (messageInput == "n")
            {
                notification.Wl("See you, we are waiting for you again!");
                break;
            }
        }
    }
}
