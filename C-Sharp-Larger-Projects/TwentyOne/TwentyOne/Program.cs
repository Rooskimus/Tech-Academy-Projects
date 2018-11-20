using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Casino;
using Casino.TwentyOne;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Hotel Casino.  Let's start by telling me your name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine("Hello, {0}.  How much money will you gamble with today?: ", playerName);
            string answer = Console.ReadLine();
            int bank = AnswerChecker.IsInt(answer);
            Console.WriteLine("Excellent.  Would you like to join a game of 21 now?");
            answer = Console.ReadLine();
            if (AnswerChecker.IsYes(answer))  // Utilizing my error-proofer for checking input.
            {
                Player player = new Player(playerName, bank);
                Game game = new TwentyOneGame();
                game += player;
                player.IsActivelyPlaying = true;
                while(player.IsActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                if (player.Balance == 0)
                {
                    Console.WriteLine("\nIt looks like your balance has run out!  Come try your luck again soon.");
                }
                game -= player;
                Console.WriteLine("\nThank you for playing!");
            }
            Console.WriteLine("\nFeel free to look around the casino.  Goodbye for now.");
            Console.Read();

        }
    }
}
