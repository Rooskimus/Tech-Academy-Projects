using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Card // "public" makes the class accessible to other parts of the program.
    {
        public Card() // this is a constructor
        {
            Suit = "Spades";
            Face = "Two";
        }
        public string Suit { get; set; }  // Declares that the Card class has a property named Suit. You can do two things with the Suite, get or set.
        public string Face { get; set; }
        // classes are just a design for an object, we don't actually set the Face or the Suit here!
    }
}
