using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Meal_Planner.Model
{
    abstract class Bear : Mammal
    {
        public override string FeedTime => "9AM and 3PM";
    }
}
