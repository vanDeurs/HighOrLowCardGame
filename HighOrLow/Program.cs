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
            IList<Card> deckOfCards = InitieraKortlek();

            while (true)
            {
                try
                {
                   // Generera 13 random kort från kortleke 
                   IList<Card> randomCards = Generera13RandomKort(deckOfCards);
                   StartGameLoop(randomCards);
               
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    Console.WriteLine("Vill du köra igen eller avsluta?");
                    Console.WriteLine("1. Kör igen");
                    Console.WriteLine("2. Avsluta");

                }
            }
        }

        static void StartGameLoop(IList<Card> randomCards) {
            Console.WriteLine("Välkommen till High or Low. Spelet fungerar så att 13 kort, av 52, " +
                "läggs ut med baksidan upp, sen vänds det första kortet. Ditt jobb är att avgöra om nästa kort är högre eller " +
                "lägre tills alla 13 kort är passerade. Klarar du alla gissningar vinner du. Gissar du fel förlorar du. Ess " +
                "fungerar som trumf d v s det är både högst och lägst. Du förlorar dock om det blir par. Lycka till!");
            for (int j = 0; j < 13; j++)
            {
                for (int i = 0; i < 13; i++)
                {
                    if (i == j || i < j)
                    {
                        // TODO: Avgör om kort är en färg
                        Console.Write(" [" + randomCards[i].värde + "] ");
                    }
                    else
                    {
                        Console.Write(" [X] ");
                    }

                }
                int spelarensVal = PlayTurn(randomCards[j]);
                switch (spelarensVal)
                {
                    case 1:
                        // Om nästa kort i listen är av ett högre värde än det nuvarande
                        if (randomCards[j + 1].värde > randomCards[j].värde)
                        {
                            Console.WriteLine("Rätt!");
                            break;
                        }
                        Console.WriteLine("Fel! Kortet som vänds är {0}", randomCards[j + 1].färg + " " + randomCards[j + 1].värde);
                        throw new Exception("");
                    // Om nästa kort i listen är av ett mindre värde än det nuvarande
                    case 2:
                        if (randomCards[j + 1].värde < randomCards[j].värde)
                        {
                            Console.WriteLine("Yes, du har rätt!");
                            break;
                        }
                        Console.WriteLine("Fel! Kortet som vänds är {0}", randomCards[j + 1].färg + " " + randomCards[j + 1].värde);
                        throw new Exception("");
                    default:
                        Console.WriteLine("Fel! Kortet som vänds är {0}", randomCards[j + 1].färg + " " + randomCards[j + 1].värde);
                        throw new Exception("");
                }

            }
        }

        // Låt spelaren välja mellan High or Low
        static int PlayTurn(Card kort)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("Kortet som vänds är {0}", kort.färg + " " + kort.värde);
                    Console.WriteLine("1. Högre");
                    Console.WriteLine("2. Lägre");

                    ConsoleKeyInfo svar = Console.ReadKey(true);
                    string svarString = svar.KeyChar.ToString();
                    int svarInt = int.Parse(svarString);

                    if (svarInt != 1 && svarInt != 2)
                    {
                        throw new Exception("Du valde ett felaktigt alternativ.");
                    }
                    return svarInt;

                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }


        }

        // Initiera kortleken, dvs generera 13 kort av varje färg och spara dem i en list
        // som returnas
        static IList<Card> InitieraKortlek()
        {
            IList<Card> deckOfCards = new List<Card>() { };
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    switch (i)
                    {
                        case 0:
                            deckOfCards.Add(new Card() { färg = "hjärter", värde = (j + 1) });
                            break;
                        case 1:
                            deckOfCards.Add(new Card() { färg = "ruter", värde = (j + 1) });
                            break;
                        case 2:
                            deckOfCards.Add(new Card() { färg = "spader", värde = (j + 1) });
                            break;
                        case 3:
                            deckOfCards.Add(new Card() { färg = "klöver", värde = (j + 1) });
                            break;
                    }
               
                }
            }
            return deckOfCards;
        }
        // Generera 13 random kort utifrån kortleken, spara dem i en list
        // och return dem
        static IList<Card> Generera13RandomKort(IList<Card> kortlek)
        {
            IList<Card> randomCards = new List<Card>() { };
            Random random = new Random();

            for (int i = 0; i < 13; i++)
            {
                int index = random.Next(kortlek.Count);
                randomCards.Add(kortlek[index]);
                kortlek.RemoveAt(index);
            }
            return randomCards;
        }
    }
}
   
