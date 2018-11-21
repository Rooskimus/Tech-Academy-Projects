using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    public class Dealer
    {


        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First());
            string card = string.Format(Deck.Cards.First().ToString() + "\n");
            Console.WriteLine(card);
            using (StreamWriter file = new StreamWriter(@"C:\Users\Roo\Desktop\Logs\log.txt", true))
            {
               file.Write(card + " Time Stamp: " + DateTime.Now);
            } //creating a using statment ensures our memory is cleaned up after the operation; this happens when a end curly brace is hit.
            Deck.Cards.RemoveAt(0);
        }
    }
}
