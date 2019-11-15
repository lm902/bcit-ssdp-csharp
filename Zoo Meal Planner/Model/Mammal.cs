using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Meal_Planner.Model
{
    abstract class Mammal
    {
        public abstract decimal ServingWeightRatio { get; }
        public abstract string[] FoodPreference { get; }
        public abstract string FeedTime { get; }
    }
}
