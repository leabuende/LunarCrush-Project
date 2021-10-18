using System;
using Evolution;
using Compare;

namespace LunarCrush_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Make a choice:" + Environment.NewLine +
                "1: Get a crypto's evolution within the last week or day" + Environment.NewLine +
                "2: " + Environment.NewLine +
                "3: " + Environment.NewLine +
                "4: " + Environment.NewLine +
                "5: "
                );
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter d for day and h for hour:");
                    string periodChoice = Console.ReadLine();
                    CryptoEvolution.CryptoTrend(periodChoice);
                    return;
                case 2:
                    CompareCoins.CompareCrypto();
                    return;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
    }
}
