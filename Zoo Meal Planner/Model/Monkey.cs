using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Meal_Planner.Model
{
    abstract class Monkey : Mammal
    {
        public override string FeedTime => "9AM, 12PM and 5PM";
        public override string[] FoodPreference => new string[] { "fresh fruit", "vegetables", "nuts", "insects", "berries" };
    }
}
