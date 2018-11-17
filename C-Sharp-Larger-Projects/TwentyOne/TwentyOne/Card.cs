using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public struct Card  // made a struct because we don't want our cards to change once a deck is made.
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }

        public override string ToString()
        {
            return string.Format("{0} of {1}", Face, Suit);
        }
    }

    public enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    public enum Face
    {
        Two=2, Three=3, Four=4, Five=5, Six=6, Seven=7, Eight=8,
        Nine=9, Ten=10, Jack=11, Queen=12, King=13, Ace=14
    }
}
