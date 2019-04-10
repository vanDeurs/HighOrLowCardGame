using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighOrLow
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Card> DeckOfCards = InitieraKortlek();
            foreach (var card in DeckOfCards)
            {
                Console.WriteLine(card.färg + " " + card.värde);
            }
            Console.ReadKey();
        }
        static IList<Card> InitieraKortlek ()
        {
            IList<Card> DeckOfCards = new List<Card>() { };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    switch (i)
                    {
                        case 0:
                            DeckOfCards.Add(new Card() { färg = "hjärter", värde = (j + 1) });
                            break;
                    }
                    switch (i)
                    {
                        case 1:
                            DeckOfCards.Add(new Card() { färg = "ruter", värde = (j + 1) });
                            break;
                    }
                    switch (i)
                    {
                        case 2:
                            DeckOfCards.Add(new Card() { färg = "spader", värde = (j + 1) });
                            break;
                    }
                    switch (i)
                    {
                        case 3:
                            DeckOfCards.Add(new Card() { färg = "klöver", värde = (j + 1) });
                            break;
                    }
                }
            }
            return DeckOfCards;
        }
    }
}
