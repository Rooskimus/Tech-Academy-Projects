using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck deck = new Deck();
            int timesShuffled = 0;
            Shuffle(deck, out timesShuffled, 5); // the deck: and times: are named parameters just to make the code easier to read.
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }          
            Console.WriteLine(deck.Cards.Count);
            Console.WriteLine("Times shuffled: {0}", timesShuffled);  // using a bracket with a number {0} {1} {2}, variable0, variable1, variable2 allows you to easily assign variables in a string.
            Console.Read();
        }

        public static Deck Shuffle(Deck deck, out int timesShuffled, int times = 1) // giving int times a default value of 1 makes it an optional parameter.
        {
            timesShuffled = 0;
            for (int i = 0; i < times; i++)
            {
                timesShuffled++;
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (deck.Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, deck.Cards.Count);
                    TempList.Add(deck.Cards[randomIndex]);
                    deck.Cards.RemoveAt(randomIndex);
                }
                deck.Cards = TempList;
            }
            return deck;
        }

        //public static Deck Shuffle(Deck deck, int times)
        //{
        //    for (int i = 0; i < times; i++)
        //    {
        //        deck = Shuffle(deck);
        //    }
        //    return deck;
        //}
    }
}
