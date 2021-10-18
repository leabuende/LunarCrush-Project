using System;
using Evolution;
using Frequency;
using Api;

namespace LunarCrush_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Make a choice:" +
                "1: " +
                "2: " +
                "3: " +
                "4: " +
                "5: "
            );
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter d for day and h for hour:");
                    string periodChoice = Console.ReadLine();
                    CryptoEvolution.CryptoEvolutionHour(periodChoice);
                    return;
                case 2:
                    Console.WriteLine("Get the monthly frequency of new maxima for a particular currency. Enter the symbol (For example : BTC) :");
                    CryptoFrequency.CryptoFrequencyMonth(Console.ReadLine());
                    return;
                case 3:
                    Console.WriteLine("Get the monthly frequency of new maxima for 10 random cryptocurrencies :");
                    CryptoFrequency.CryptoFrequencyTop();
                    return;
                
                default:
                    Console.WriteLine("Wrong input");
                    break;
                
            }
            }
    }
}