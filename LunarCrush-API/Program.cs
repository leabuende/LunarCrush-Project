using System;
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

            Console.WriteLine(choice);

            switch (choice)
            {
                case 1:
                    var data = ApiConnection.ApiFetch();
                    Console.Write(data);
                    return;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
    }
}
