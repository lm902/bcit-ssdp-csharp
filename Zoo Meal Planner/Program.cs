﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo_Meal_Planner.Model;

namespace Zoo_Meal_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            var mammal = (Mammal)new Menu().RequestUserSelection();
            decimal weight;
            while (true)
            {
                Console.Write("Weight in KG: ");
                var input = Console.ReadLine();
                if(decimal.TryParse(input, out weight))
                {
                    break;
                }
            }
            Console.WriteLine("Meal Recommendation");
            Console.WriteLine("————————————————————");
            Console.WriteLine("Mammal Type: %s", mammal.GetType().BaseType.Name);
            Console.WriteLine("Species: %s", mammal.GetType().Name);
            Console.WriteLine("Weight: %s", weight + " KG");
            Console.WriteLine("Serving: %s", mammal.ServingWeightRatio * weight + " KG " + string.Join(", ", mammal.FoodPreference));
            Console.WriteLine("Instructions:\r\n\tKeep area secure at all times.\r\n\tFeed at %s.", mammal.FeedTime);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
