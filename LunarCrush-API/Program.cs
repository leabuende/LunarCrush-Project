using System;
using Evolution;
using Frequency;
using Api;

namespace LunarCrush_API
{
    class Program
    {
        public static int Menu()
        {
            int choice;
            Console.WriteLine(
                "Make a choice:" + Environment.NewLine +
                "1: Get a crypto's evolution within the last week or day" + Environment.NewLine +
                "2: Get top 3 coins of the day" + Environment.NewLine +
                "3: Get the monthly frequency of new maxima for a particular currency." + Environment.NewLine +
                "4: Get the monthly frequency of new maxima for 10 random cryptocurrencies" + Environment.NewLine +
                "5: Quit"
                );
            do
            {
                Console.WriteLine("Please choose a valid option :");
                int.TryParse(Console.ReadLine(), out var result);
                choice = result;
            } while (choice < 1 ^ choice > 5);
            return choice;
        }

        static void Main(string[] args)
        {
            int choice = 0;

            while (choice != 5)
            {
                choice = Menu();

                if (choice == 1)
                {
                    Console.WriteLine("Enter d for day and h for hour:");
                    string periodChoice = Console.ReadLine();
                    CryptoEvolution.CryptoEvolutionHour(periodChoice);
                }
                else if (choice == 2)
                {
                    CoinOfTheDay.getFullInfo();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the symbol (For example : BTC) :");
                    CryptoFrequency.CryptoFrequencyMonth(Console.ReadLine());
                }
                else if (choice == 4)
                {
                    CryptoFrequency.CryptoFrequencyTop();
                }
            }
            Console.WriteLine("Thanks !");
        }
    }
}
