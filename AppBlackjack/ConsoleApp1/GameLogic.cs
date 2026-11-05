using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp1
{
    internal class GameLogic
    {
        public int CurrentBet { get; set; }

        public bool Close { get; set; } = false;

        public GameLogic(int currentBet)
        {
            CurrentBet = currentBet;
        }
        public void StartGame()
        {
            Deck deck = new Deck();

            Cards cards = new Cards();

            while (true)
            {
                Console.WriteLine("vad är ditt namn?");
                string playerName = Console.ReadLine();
                if (!string.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine($"Hej {playerName}! Välkommen till Blackjack.");
                    User player = new User(playerName);
                    break;
                }
                else
                {
                    Console.WriteLine("Vänligen ange ett giltigt namn.");
                    break;
                }
            }
        }
        public void StartRound()
        {

            while (true)
            {
               var Balance = player.Balance;
                Console.WriteLine($"Ditt nuvarande saldo är: {player.Balance}");
            }
        }
    }
}
