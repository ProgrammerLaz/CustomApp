using System;
using System.Runtime.CompilerServices;

namespace CustomApp
{
    class Program
    {
        //Database Location
        public static string cs = @"server= 127.0.0.1;userid=root;password=root;database=notefinity;port=3306";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Notefinity, what would you like to do today?");
            Console.WriteLine("1. New Note");
            Console.WriteLine("2. Read Note");
            Console.WriteLine("3. Exit");
            string option = Console.ReadLine();
            //Loop the many options in the given list for the user
            switch (option)
            {
                case "1":
                    Menu.NewNote();
                    break;
                case "2":
                    Menu.ReadNote();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option, try again.");
                    Main(null);
                    break;
            }
            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
            Main(null);
        }
    }
}
