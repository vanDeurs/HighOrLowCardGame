﻿using System;
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
            IList<Card> randomCards = Generera13RandomKort(deckOfCards);

            while (true)
            {
                try
                {
                   // Generera 13 random kort från kortleke 
                   StartGameLoop(randomCards);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    Console.WriteLine("Vill du köra igen eller avsluta?");
                    Console.WriteLine("1. Kör igen");
                    Console.WriteLine("2. Avsluta");

                    ConsoleKeyInfo svar = Console.ReadKey(true);
                    string svarString = svar.KeyChar.ToString();
                    int svarInt = int.Parse(svarString);


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
                        Console.Write(" [" + randomCards[i].Färg + " " + randomCards[i].Värde + "] ");
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
                        if (randomCards[j].Värde == 1 || randomCards[j + 1].Värde > randomCards[j].Värde)
                        {
                            Console.WriteLine("Rätt!");
                            break;
                        }
                        Console.WriteLine("Fel! Kortet som vänds är {0}", randomCards[j + 1].Färg + " " + randomCards[j + 1].Värde);
                        throw new Exception("");
                    // Om nästa kort i listen är av ett mindre värde än det nuvarande
                    case 2:
                        if (randomCards[j + 1].Värde < randomCards[j].Värde)
                        {
                            Console.WriteLine("Yes, du har rätt!");
                            break;
                        }
                        Console.WriteLine("Fel! Kortet som vänds är {0}", randomCards[j + 1].Färg + " " + randomCards[j + 1].Värde);
                        throw new Exception("");
                    default:
                        Console.WriteLine("Fel! Kortet som vänds är {0}", randomCards[j + 1].Färg + " " + randomCards[j + 1].Värde);
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
                    Console.WriteLine("Kortet som vänds är {0}", kort.Färg + " " + kort.Värde);
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
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    switch (i)
                    {
                        case 0:
                            deckOfCards.Add(new Card() { Färg = "hjärter", Värde = (j + 1) });
                            break;
                        case 1:
                            deckOfCards.Add(new Card() { Färg = "ruter", Värde = (j + 1) });
                            break;
                        case 2:
                            deckOfCards.Add(new Card() { Färg = "spader", Värde = (j + 1) });
                            break;
                        case 3:
                            deckOfCards.Add(new Card() { Färg = "klöver", Värde = (j + 1) });
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
   
