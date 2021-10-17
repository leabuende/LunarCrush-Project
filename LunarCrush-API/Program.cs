using System;
using Evolution;
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
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
    }
}
