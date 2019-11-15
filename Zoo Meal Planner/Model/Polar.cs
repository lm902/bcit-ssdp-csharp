using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Meal_Planner.Model
{
    class Polar : Bear
    {
        public override decimal ServingWeightRatio => 0.016M;
        public override string[] FoodPreference => new string[] { "berries", "fish" };
    }
}
