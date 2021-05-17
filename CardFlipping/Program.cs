using System;
using System.Collections.Generic;

namespace CardFlipping
{
    class Program
    {
        enum CardState
        {
            Concave,
            Convex,
            ArrowLeft,
            ArrowRight,
            Removed
        }

        static void Main(string[] args)
        {
            SolveGame("1100100001100");

            SolveGame("0100110");
            SolveGame("01001100111");
            SolveGame("100001100101000");
            SolveGame("010111111111100100101000100110111000101111001001011011000011000");
        }

        static void SolveGame(string cardSet)
        {
            if (EvenNumberOfFaceUpCards(cardSet))
            {
                Console.WriteLine("No Solution");
                Console.ReadLine();
                return;
            }

            List<CardState> cardStates = SetCardStates(cardSet);
            var solution = new int[cardSet.Length];
            int nextStep = 0;

            int currentIndex = 0;
            while(CardsNotYetRemoved(cardStates))
            {
                if (cardStates.Contains(CardState.Concave))
                {
                    currentIndex = cardStates.FindIndex(x => x == CardState.Concave);
                }

                cardStates[currentIndex] = CardState.Removed;
                solution[currentIndex] = nextStep;
                nextStep++;
                
                if (currentIndex != 0)
                {
                    cardStates[currentIndex - 1] = ChangeAdjacentCard(cardStates, currentIndex, -1);
                }    
                if (currentIndex != cardStates.Count - 1)
                {
                    cardStates[currentIndex + 1] = ChangeAdjacentCard(cardStates, currentIndex, +1);
                }                
            }

            PrintSolution(solution);
        }

        static bool EvenNumberOfFaceUpCards(string cardSet)
        {
            int count = 0;
            foreach(char card in cardSet)
            {
                if (card == '1')
                {
                    count++;
                }
            }

            return count % 2 == 0;
        }

        static bool CardsNotYetRemoved(List<CardState> cardStates)
        {
            return cardStates.Contains(CardState.Concave) ||
                   cardStates.Contains(CardState.Convex) ||
                   cardStates.Contains(CardState.ArrowLeft) ||
                   cardStates.Contains(CardState.ArrowRight);
        }

        static CardState ChangeAdjacentCard(
                List<CardState> cardStates, 
                int currentIndex,
                int parity)
        {
            int adjacentIndex = currentIndex + parity;
           
            if (cardStates[adjacentIndex] == CardState.ArrowRight)
            {
                return CardState.Concave;
            }
            else if (cardStates[adjacentIndex] == CardState.Convex)
            {
                return CardState.ArrowLeft;
            }
            else if (cardStates[adjacentIndex] == CardState.ArrowLeft)
            {
                return CardState.Concave;
            }
            else if (cardStates[adjacentIndex] == CardState.Convex)
            {
                return CardState.ArrowRight;
            }
            else
            {
                return CardState.Removed;
            }
        }

        static void PrintSolution(int[] solution)
        {
            foreach (int step in solution)
            {
                Console.WriteLine(step);
            }

            Console.ReadLine();
        }

        static List<CardState> SetCardStates(string cardSet)
        {
            var cardSetStates = new List<CardState>();
            cardSetStates.Add(SetBoundaryCardState(end: false, cardSet[0]));

            for(int i = 1; i < cardSet.Length - 1; i++)
            {
                if (IsFaceUp(cardSet[i]) && TesselatesWithConcave(cardSetStates[i - 1]))
                {
                    cardSetStates.Add(CardState.Concave);
                }
                else if (!IsFaceUp(cardSet[i]) && TesselatesWithConcave(cardSetStates[i - 1]))
                {
                    cardSetStates.Add(CardState.ArrowRight);
                }
                else if (IsFaceUp(cardSet[i]) && TesselatesWithConvex(cardSetStates[i - 1]))
                {
                    cardSetStates.Add(CardState.Convex);
                }
                else if (!IsFaceUp(cardSet[i]) && TesselatesWithConvex(cardSetStates[i - 1]))
                {
                    cardSetStates.Add(CardState.ArrowLeft);
                }
            }

            cardSetStates.Add(SetBoundaryCardState(end: true, cardSet[cardSet.Length - 1]));

            return cardSetStates;
        }

        static CardState SetBoundaryCardState(bool end, char card)
        {
            if (card == '1' && end)
            {
                return CardState.Convex;
            }
            else if (card == '1' && !end)
            {
                return CardState.Concave;
            }
            else if (card == '0' && end)
            {
                return CardState.ArrowLeft;
            }
            else if (card == '0' && !end)
            {
                return CardState.ArrowRight;
            }
            else
            {
                throw new ArgumentException("card must be 0 or 1");
            }
        }

        static bool IsFaceUp(char card)
        {
            return card == '1';
        }

        static bool TesselatesWithConvex(CardState cardState)
        {
            return cardState == CardState.Concave || cardState == CardState.ArrowLeft;
        }

        static bool TesselatesWithConcave(CardState cardState)
        {
            return cardState == CardState.Convex || cardState == CardState.ArrowRight;
        }
    }
}
