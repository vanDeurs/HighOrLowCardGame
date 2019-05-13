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
            // Skriv ut reglerna första gången använder startar spelet
            Console.WriteLine("**********************************************************************************************");
            Console.WriteLine("Välkommen till spelet High or Low!");
            Console.WriteLine("Regler: 13 kort av 52 läggs med baksidan upp. Sedan vänds det första kortet.");
            Console.WriteLine("Ditt jobb är att avgöra om nästa kort är högre eller " +
            "lägre tills alla 13 kort är passerade.\nKlarar du alla gissningar vinner du. Gissar du fel förlorar du.\nEss " +
            "fungerar som trumf, d.v.s att det är både högst och lägst. Du förlorar dock om det blir par.\nLycka till!");
            Console.WriteLine("**********************************************************************************************");

            // Starta spel-loopen
            MainLoop();
        }

        static void MainLoop ()
        {
            // Skapa kortlek
            IList<Card> deckOfCards = InitieraKortlek();

            // Generera 13 random kort från kortleken
            IList<Card> randomCards = Generera13RandomKort(deckOfCards);

            // Loopen som håller spelet i liv
            while (true)
            {
                try
                {
                    StartGame(randomCards);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    Console.WriteLine("Om du vill köra igen klicka 1: ");
                    Console.WriteLine("1. Kör igen");
                    Console.WriteLine("Annan. Avsluta");

                    // Hanterar vad användaren vill göra vid slut
                    EndGameHandler();
                }
            }
        }

        // Hanterar slutet på spelet
        static void EndGameHandler ()
        {
            ConsoleKeyInfo svar = Console.ReadKey(true);
            string svarString = svar.KeyChar.ToString();
            int svarInt = int.Parse(svarString);

            if (svarInt == 1)
            {
                // Startar om spelet
                MainLoop();
            } else
            {
                // Eller stänger av det
                Environment.Exit(0);
            }
        }

        static void StartGame(IList<Card> randomCards) {
            Console.WriteLine("");

            // Skriver ut de kort som hitills har vänt på
            for (int j = 0; j < 13; j++)
            {
                for (int i = 0; i < 13; i++)
                {
                    if (i == j || i < j)
                    {
                        Console.Write(" [" + (Färger)randomCards[i].färg + " " + (Värden)randomCards[i].värde + "] ");
                    }
                    else
                    {
                        Console.Write(" [X] ");
                    }
                }
                Console.WriteLine("");

                // Här får spelaren välja högre eller lägre
                int spelarensVal = PlayTurn(randomCards[j]);

                // Här ser vi om spelaren valde rätt eller fel
                switch (spelarensVal)
                {
                    case 1:
                        // Om nästa kort i listen är av ett högre värde än det nuvarande
                        if (randomCards[j].värde == 1 || randomCards[j + 1].värde == 1 || randomCards[j + 1].värde > randomCards[j].värde)
                        {
                            break;
                        }
                        Console.WriteLine("Fel! Kortet som vänds är {0}", (Färger)randomCards[j+1].färg + " " + (Värden)randomCards[j+1].värde);
                        throw new Exception("");
                    // Om nästa kort i listen är av ett mindre värde än det nuvarande
                    case 2:
                        if (randomCards[j].värde == 1 || randomCards[j + 1].värde == 1 || randomCards[j + 1].värde < randomCards[j].värde)
                        {
                            break;
                        }
                        Console.WriteLine("Fel! Kortet som vänds är {0}", (Färger)randomCards[j + 1].färg + " " + (Värden)randomCards[j + 1].värde);
                        throw new Exception("");
                }
                // Om spelaren har rätt kommer switchen breaka och komma hit
                // Annars kommer den hamna i en Exception
                Console.WriteLine("");
                Console.WriteLine(" Rätt!");
                Console.WriteLine("");
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
                    Console.WriteLine(" Är nästa kort högre eller lägre än {0}?", (Färger)kort.färg + " " + (Värden)kort.värde);
                    Console.WriteLine("");
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

        // Genererar en full kortlek
        static IList<Card> InitieraKortlek()
        {
            IList<Card> deckOfCards = new List<Card>() { };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deckOfCards.Add(new Card() { färg = i, värde = (j + 1) });
                }
            }
            return deckOfCards;
        }
        // Generera 13 random kort utifrån kortleken, spara dem i en lista
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
   
