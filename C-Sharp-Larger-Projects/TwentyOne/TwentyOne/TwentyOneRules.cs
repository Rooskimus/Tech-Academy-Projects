using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class TwentyOneRules
    {
        //Thse are not needed when using my alternatives.
        //private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()
        //{
        //    [Face.Two] = 2,
        //    [Face.Three] = 3,
        //    [Face.Four] = 4,
        //    [Face.Five] = 5,
        //    [Face.Six] = 6,
        //    [Face.Seven] = 7,
        //    [Face.Eight] = 8,
        //    [Face.Nine] = 9,
        //    [Face.Ten] = 10,
        //    [Face.Jack] = 10,
        //    [Face.Queen] = 10,
        //    [Face.King] = 10,
        //    [Face.Ace] = 1
        //};

        //private static int[] GetAllPossibleHandValues(List<Card> Hand)
        //{
        //    int aceCount = Hand.Count(x => x.Face == Face.Ace);
        //    int[] result = new int[aceCount + 1];
        //    int value = Hand.Sum(x => _cardValues[x.Face]);
        //    result[0] = value;
        //    if (result.Length == 1) return result;
        //    for (int i = 1; i < result.Length; i++)
        //    {
        //        value += (i * 10);
        //        result[i] = value;
        //    }
        //    return result;
        //}

        public static bool CheckForBlackJack(List<Card> Hand)
        {
            //int[] possibleValues = GetAllPossibleHandValues(Hand);
            List<int> possibleValues = MyGetAllPossibleHandValues(Hand);
            int value = possibleValues.Max();
            if (value == 21) return true;
            else return false;
        }

        public static bool IsBusted(List<Card> Hand)
        {
            //int value = GetAllPossibleHandValues(Hand).Min();
            int value = MyGetAllPossibleHandValues(Hand).Min(); //using my version
            if (value > 21) return true;
            else return false;
        }

        public static bool ShouldDealerStay(List<Card> Hand)
        {
            //int[] possibleHandValues = GetAllPossibleHandValues(Hand);
            List<int> possibleHandValues = MyGetAllPossibleHandValues(Hand);  //my alternative way
            foreach (int value in possibleHandValues)
            {
                if (value > 16 && value < 22)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool? CompareHands(List<Card> PlayerHand, List<Card> DealerHand)
        {
            //int[] playerResults = GetAllPossibleHandValues(PlayerHand);
            //int[] dealerResults = GetAllPossibleHandValues(DealerHand);

            // Or my way:
            List<int> playerResults = MyGetAllPossibleHandValues(PlayerHand);
            List<int> dealerResults = MyGetAllPossibleHandValues(DealerHand);

            int playerScore = playerResults.Where(x => x < 22).Max();
            int dealerScore = dealerResults.Where(x => x < 22).Max();

            if (playerScore > dealerScore) return true;
            else if (playerScore < dealerScore) return false;
            else return null;
        }

        public static int FinalScore(List<Card> Hand) // I created this because occasionally I found myself wanting to be able to call just the best score for any player at any given point.
        {
            List<int> possibleScores = new List<int>();
            int returnValue = 0;
            possibleScores = MyGetAllPossibleHandValues(Hand);
            if (possibleScores.Min() > 21)  // if all possibilites are over 21, show smallest.
            {
                returnValue = possibleScores.Min();
            }
            else if (possibleScores.Min() < 22 && possibleScores.Max() > 21) // if min is 21 or less, and max is a bust, show min.
            {
                returnValue = possibleScores.Min();
            }
            else  // Otherwise, show max.
            {
                returnValue = possibleScores.Max();
            }
            return returnValue;

        }

        public static void ShowHandTotal(List<Card> Hand) //I added this to be able to easily display the value of a hand.
        {
            List<int> possibleValues = MyGetAllPossibleHandValues(Hand);
            if (possibleValues.Count() == 2 && possibleValues.Max() < 22)
            {
                Console.WriteLine("{0} or {1}", possibleValues[0], possibleValues[1]);
            }
            else
            {
                Console.WriteLine("{0}", possibleValues[0]);
            }
        }

        //My alternative code for getting hand values below:

        private static List<int> MyGetCardValuesFromEnum(List<Card> Hand) // This gets around having multiple enums be assigned a value of 10, and adjusts our ace from a 14 to a 1 value.
        {
            List<int> cardValues = new List<int>();
            foreach (Card card in Hand)
            {
                int cardValue = (int)card.Face;
                if (cardValue == 14) cardValue = 1;
                if (cardValue > 10) cardValue = 10;
                cardValues.Add(cardValue);
            }
            return cardValues;
        }

        private static List<int> MyGetAllPossibleHandValues(List<Card> Hand) // This provides possible hand values based on variable-value Aces
        {
            List<int> cardValues = MyGetCardValuesFromEnum(Hand);
            List<int> handValues = new List<int>();
            int totalValue = cardValues.Sum();
            handValues.Add(totalValue); // Add initial card value to list
            List<int> handAces = cardValues.Where<int>(x => x == 1).ToList<int>(); // Create a list for any aces.
            if (handAces.Count() != 0)  // We only ever need to add 10 to a value once; two aces is never 22 in BlackJack.
            {
                handValues.Add(totalValue + 10); // Add ten (Ace already represents a 1 in the hand value, needs +10 to become 11) and add possible value to list
            }
            return handValues; // Should only ever return a list of length 1 or 2.
        }

        //public static bool MyCheckForBlackJack(List<Card> Hand)  //I created this before he wrote his in the video; I like his better.
        //{
        //    List<int> cardValues = MyGetCardValuesFromEnum(Hand);
        //    List<int> handValues = MyGetAllPossibleHandValues(cardValues);
        //    List<int> checkValues = handValues.Where<int>(x => x == 21).ToList<int>();
        //    bool check = false;
        //    if (checkValues.Count() > 0) check = true;
        //    return check;
        //}

        public static bool MyIsBusted(List<Card> Hand)
        {

            int value = MyGetAllPossibleHandValues(Hand).Min();
            if (value > 21) return true;
            else return false;
        }
    }
}
