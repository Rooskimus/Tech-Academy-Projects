using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino.TwentyOne
{
    public class TwentyOneGame : Game, IWalkAway
    {
        public TwentyOneDealer Dealer { get; set; }
        public override void Play() // override is how you implement an inherited abstract method.
        {
            Dealer = new TwentyOneDealer();
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>();
                player.Stay = false;
                Console.WriteLine("{0}, your balance is: ${1}", player.Name, player.Balance);
            }
            Dealer.Hand = new List<Card>();
            Dealer.Deck = new Deck();
            Dealer.Deck.Shuffle(5);
            using (StreamWriter file = new StreamWriter(@"C:\Users\Roo\Desktop\Logs\log.txt", true))
            {
                file.WriteLine("-- New Hand --");
            }
            Console.WriteLine("Place your bet: ");
            foreach (Player player in Players)
            {
                int bet = AnswerChecker.IsInt(Console.ReadLine());
                if (bet < 0) throw new FraudException("Negative bet attempted");
                bool successfullyBet = player.Bet(bet);
                if (!successfullyBet)
                {
                    return; // This will kick the program out of this loop.  It will go back out to the while loop in main() and see activelyplay is yes and balance is above zero then kick the player back into the play method where they will see "place your bet"
                }
                Bets[player] = bet;
            }
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing...");
                foreach (Player player in Players)
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(player.Hand); // passing dealer's hand into the deal function
                    using (StreamWriter file = new StreamWriter(@"C:\Users\Roo\Desktop\Logs\log.txt", true))
                    {
                        file.WriteLine(" was dealt to User {0} GUID {1}", player.Name, player.Id);
                    }
                    if (i == 1)
                    {
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand);
                        if (blackJack)
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, (2 * Bets[player]));
                            player.Balance += Convert.ToInt32((2 * Bets[player]));                            
                            return;
                        }
                    }
                }
                Console.Write("Dealer: ");
                Dealer.Deal(Dealer.Hand);
                using (StreamWriter file = new StreamWriter(@"C:\Users\Roo\Desktop\Logs\log.txt", true))
                {
                    file.WriteLine(" was dealt to the Dealer.");
                }
                if (i == 1)
                {
                    bool blackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand);
                    if (blackJack)
                    {
                        Console.WriteLine("Dealer has BlackJack!  Everyone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)
                        {
                            Dealer.Balance += entry.Value;
                        }
                        return;
                    }
                }
            }
            foreach (Player player in Players)
            {
                while (!player.Stay)
                {
                    Console.Write("Your cards are: \n");
                    foreach (Card card in player.Hand)
                        {
                            Console.Write("{0} \n", card.ToString());
                        }
                    Console.Write("Your hand total is: ");
                    TwentyOneRules.ShowHandTotal(player.Hand);
                    Console.Write("The Dealer's hand total is: ");
                    TwentyOneRules.ShowHandTotal(Dealer.Hand);

                    Console.WriteLine("\n\nHit or stay?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;
                    }
                    else if (answer == "hit")
                    {
                        Dealer.Deal(player.Hand);
                        using (StreamWriter file = new StreamWriter(@"C:\Users\Roo\Desktop\Logs\log.txt", true))
                        {
                            file.WriteLine(" was dealt to User {0} GUID {1}", player.Name, player.Id);
                        }

                    }
                    bool busted = TwentyOneRules.IsBusted(player.Hand);
                    if (busted)
                    {
                        Dealer.Balance += Bets[player];                            
                        Console.WriteLine("{0} busted!  You lose your bet of ${1}.  Your balance is now ${2}.", player.Name, Bets[player], player.Balance);
                        Bets[player] = 0; // I added this to ensure no bets are payed out to players who busted if the dealer busts. IF there were multiple players.
                        Console.WriteLine("Would you like to play again? ");
                        answer = Console.ReadLine();
                        if (AnswerChecker.IsYes(answer)) // I added another class to ensure user input to y/n questions won't cause errors.
                        {
                            player.IsActivelyPlaying = true;
                            return;
                        }
                        else
                        {
                            player.IsActivelyPlaying = false;
                            return;
                        }
                    }
                }   
            }
            Dealer.IsBusted = TwentyOneRules.IsBusted(Dealer.Hand);
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            while (!Dealer.Stay && !Dealer.IsBusted)
            {
                Console.WriteLine("\nThe Dealer is hitting...");
                Dealer.Deal(Dealer.Hand);
                using (StreamWriter file = new StreamWriter(@"C:\Users\Roo\Desktop\Logs\log.txt", true))
                {
                    file.WriteLine(" was dealt to the Dealer.");
                }
                Dealer.IsBusted = TwentyOneRules.IsBusted(Dealer.Hand);
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
                Console.WriteLine("The dealers hand is: ");
                foreach (Card card in Dealer.Hand)
                {
                    Console.Write("{0} \n", card.ToString());
                }
                Console.Write("The Dealer's hand total is: ");
                TwentyOneRules.ShowHandTotal(Dealer.Hand);
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("\nThe Dealer is staying at {0}.", TwentyOneRules.FinalScore(Dealer.Hand));
            }
            if (Dealer.IsBusted)
            {
                Console.WriteLine("\nThe Dealer busts with a hand total of {0}!", TwentyOneRules.FinalScore(Dealer.Hand));
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} won ${1}", entry.Key.Name, entry.Value); // See line 90.
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);
                    Dealer.Balance -= entry.Value;
                }
                foreach (Player player in Players)
                {
                    Console.WriteLine("\nYour balance is ${0}", player.Balance);
                    Console.WriteLine("\nWould you like to play again?");
                    string answer = Console.ReadLine();
                    if (AnswerChecker.IsYes(answer)) player.IsActivelyPlaying = true;
                    else player.IsActivelyPlaying = false;                    
                }
                return;
            }
            foreach (Player player in Players)
            {
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);
                if (playerWon == null)
                {
                    Console.WriteLine("It's a push for {0}!", player.Name);
                    player.Balance += Bets[player];
                }       
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} wins ${1}!", player.Name, Bets[player]);
                    player.Balance += (Bets[player] * 2);
                    Dealer.Balance -= Bets[player];
                }
                else
                {
                    Console.WriteLine("Dealer wins ${0}!", Bets[player]);
                    Dealer.Balance += Bets[player];
                }
                Console.WriteLine("\nYour balance is now: ${0}", player.Balance);
                Console.WriteLine("\nWould you like to play again?");
                string answer = Console.ReadLine();
                bool isYes = AnswerChecker.IsYes(answer);
                if (isYes)
                {
                    player.IsActivelyPlaying = true;
                    return;
                }
                else
                {
                    player.IsActivelyPlaying = false;
                    return;
                }
            }
                
           

        }

        public override void ListPlayers()
        {
            Console.WriteLine("21 Players: ");
            base.ListPlayers();
        }

        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
