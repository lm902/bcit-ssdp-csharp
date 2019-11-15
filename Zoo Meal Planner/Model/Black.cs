using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Meal_Planner.Model
{
    class Black : Bear
    {
        public override decimal ServingWeightRatio => 0.014M;
        public override string[] FoodPreference => new string[] { "berries", "green vegetation", "flowers", "fruits", "fish" };
    }
}
