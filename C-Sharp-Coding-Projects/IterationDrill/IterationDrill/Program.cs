using System;
using System.Collections.Generic;

namespace IterationDrill
{
    class Program
    {
        static void Main(string[] args)
        {
            // My string array that has user input added to each item: 
            string[] adjectives = { "Fine", "Diminutive", "Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan", "Colossal" };
            Console.Write("Enter the name of a monster: ");
            string monster = Console.ReadLine();
            Console.WriteLine("\nThe possible sizes of your monster are: \n");
            for (int i = 0; i < adjectives.Length; i++)
                {
                adjectives[i] = (adjectives[i] + " " + monster);
                Console.WriteLine(adjectives[i]);
                }
            Console.ReadLine();

            // My infinite loop:
            //for (int i = 0; i >= 0; i++)
            //{
            //    Console.WriteLine("This will go on forever.  Why would you do this?!");
            //    Console.ReadLine();
            //}

            // My fixed infinite loop:
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("This will only happen three times.  This is fine.");
                Console.ReadLine();
            }

            // My loop using < (another one, I guess!)
            for (int i = 0; i < adjectives.Length; i++)
            {
                Console.WriteLine("A " + adjectives[i] + " has appeared!");
            }
            Console.WriteLine("");

            // My loop using <=
            for (int i = 0; i <= adjectives.Length - 1; i++)
            {
                Console.WriteLine("You used your Master Ball to capture a " + adjectives[i] + "!");
            }

            Console.ReadLine();

            // My Loop for steps 6 - 8
            List<string> pokemons = new List<string>() { "Bulbasaur", "Pikachu", "Magikarp", "MewTwo", "Scyther", "Donald Trump" };
            Console.WriteLine("My Pokemons!  Let me show them to you.  Which one would you like to see?");
            string ichooseyou = Console.ReadLine();
            bool havePokemon = pokemons.Exists(x => x == ichooseyou);
            while (!havePokemon)
            {
                Console.WriteLine("Mmmmnnn.  I dont have a " + ichooseyou + ".  It's too weak and the design isn't great.");
                Console.Write("The STRONG ones...er, I mean....The ones I have are: ");
                foreach (string pokemon in pokemons)
                {
                    Console.Write(" "+ pokemon + ",");
                }
                Console.WriteLine(" which pokemans would you like to see?: ");
                ichooseyou = Console.ReadLine();
                havePokemon = pokemons.Exists(x => x == ichooseyou);
            }
            foreach (string pokemon in pokemons)
            {
                if (ichooseyou == pokemon)
                {
                    Console.WriteLine("Yes!  Let me show you my lvl 99 " + pokemon + "!");
                    break;
                }
            }

            Console.ReadLine();

            // My Loop for steps 9 - 10; Making it so the index found wasn't just the first index repeated was tricky!
            Console.WriteLine("A wild Donald Trump appears.\nNeckbeard uses a Super Ball to capture Donald Trump.");
            Console.ReadLine();
            pokemons.Add("Donald Trump");
            Console.WriteLine("Ok, now give me a pokemans name and I'll tell you which slot I'm carrying them in!: ");
            ichooseyou = Console.ReadLine();
            havePokemon = pokemons.Exists(x => x == ichooseyou);
            while (!havePokemon)
            {
                Console.Write("Mmmnn.  I thought I told you which ones I have already.  I have: ");
                foreach (string pokemon in pokemons)
                {
                    Console.Write(" " + pokemon + ",");
                }
                Console.WriteLine(" so enter a pokemans and I'll tell you which slot I'm carrying them in: ");
                ichooseyou = Console.ReadLine();
                havePokemon = pokemons.Exists(x => x == ichooseyou);
            }
            int indexSlider = 0;  // IndexOf only finds the FIRST result in a list.  To use this, I created a variable to control where the search begins.
            foreach (string pokemon in pokemons)
            {
                int pokemonIndex = pokemons.IndexOf(pokemon, indexSlider); // For the first search, we start at index zero as above.  Subsequently, we start after the index we previously found per below.
                if (pokemon == ichooseyou)
                {
                    Console.WriteLine("I'm carrying a " + ichooseyou + " in slot " + pokemonIndex);
                    indexSlider = pokemonIndex + 1; // Here we slide the index PAST the most recently found index for that item.
                }
            }
            Console.ReadLine();

            // Loop for part 11
            Console.WriteLine("And now I will reveal to you which pokemans I have duplicates of.");
            // To make this more interesting, let's make everything have a duplicate!
            pokemons.AddRange(pokemons); //recursive list ERMAGERD!
            List<string> distinctPokemons = new List<string>(); // Creating a new list to hold the names of pokemon that have appeared once already.
            foreach (string pokemon in pokemons)
            {
               if (!distinctPokemons.Exists(x => x == pokemon)) // Check if the pokemon is on our new list.  If not...
                {
                    distinctPokemons.Add(pokemon); // Add it and...
                    // Console.WriteLine(pokemon + " - This is the first one of these."); // It turns out the requirement was only for duplicates to be printed, so let's drop this!
                }
                else
                {
                    Console.WriteLine(pokemon + " - This is a duplicate of a previous pokemon."); // Otherwise, let the console know it's a duplicate.
                }
            }
            Console.ReadLine();
        }
    }
}
