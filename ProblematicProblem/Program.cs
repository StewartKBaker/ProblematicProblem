using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rng = new Random();
            bool cont;
            List<string> activities = new List<string>()
            {
                "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting"
            };
            
            Console.Write(
                "Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var generateProgram = Console.ReadLine().ToLower();
            while (generateProgram != "yes" && generateProgram != "no")
            {
                Console.WriteLine("Invalid response, please type yes/no");
                generateProgram = Console.ReadLine().ToLower();
            }
            cont = (generateProgram == "yes");
            if (!cont)
            {
                Console.WriteLine("Goodbye!");
                return;
            }
            Console.WriteLine();
            
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            
            Console.Write("What is your age? ");
            int.TryParse(Console.ReadLine(), out int userAge);
            Console.WriteLine();
            
            Console.Write("Would you like to see the current list of activities? yes/no: ");
            var seeList = Console.ReadLine().ToLower();
            while (seeList != "yes" && seeList != "no")
            {
                Console.WriteLine("Invalid response, please type yes/no");
                seeList = Console.ReadLine().ToLower();
            }
            
            if (seeList == "yes")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity}, ");
                    Thread.Sleep(250);
                }
                
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                var addToList = Console.ReadLine().ToLower();
                while (addToList != "yes" && addToList != "no")
                {
                    Console.WriteLine("Invalid response, please type yes/no");
                    addToList = Console.ReadLine().ToLower();
                }
                Console.WriteLine();
                
                while (addToList == "yes")
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity}, ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    var addMore = Console.ReadLine().ToLower();
                    while (addMore != "yes" && addMore != "no")
                    {
                        Console.WriteLine("Invalid response, please type yes/no");
                        addMore = Console.ReadLine().ToLower();
                    }
                    addToList = addMore;
                }
            }
            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                int randomNumber = rng.Next(0, activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(0, activities.Count);
                    randomActivity = activities[randomNumber];
                }
                
                Console.Write(
                    $"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                var keepOrNot = Console.ReadLine().ToLower();
                while (keepOrNot != "keep" && keepOrNot != "redo")
                {
                    Console.WriteLine("Invalid response, please type keep/redo");
                    keepOrNot = Console.ReadLine().ToLower();
                }
                cont = (keepOrNot != "keep");
            }
        }
    }
}
