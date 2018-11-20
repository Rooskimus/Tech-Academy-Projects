using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();

            for (int i = 0; i < 4; i++)
            {
                for(int j = 2; j < 15; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)j;  // casting integer to Face enum
                    card.Suit = (Suit)i;
                    Cards.Add(card);
                }
            }
        }
        

       
        public List<Card> Cards { get; set; }

        public void Shuffle(int times = 1) // giving int times a default value of 1 makes it an optional parameter.
        {          
            for (int i = 0; i < times; i++)
            {
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count);
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);
                }
                Cards = TempList;
            }
        }

    }
}
