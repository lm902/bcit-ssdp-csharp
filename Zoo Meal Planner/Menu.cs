using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo_Meal_Planner.Model;

namespace Zoo_Meal_Planner
{
    class Menu
    {
        private MenuPage currentPage;

        public Menu()
        {
            var monkeySelections = new Dictionary<string, object>();
            monkeySelections.Add("Squirrel", new Squirrel());
            monkeySelections.Add("Howler", new Howler());
            monkeySelections.Add("Colobus", new Colobus());
            var monkeyMenu = new MenuPage
            {
                title = "Species",
                selections = monkeySelections
            };

            var bearSelections = new Dictionary<string, object>();
            bearSelections.Add("Black", new Black());
            bearSelections.Add("Black", new Polar());
            var bearMenu = new MenuPage
            {
                title = "Species",
                selections = bearSelections
            };

            var quitAction = new Action(() => Environment.Exit(0));

            var mainPageSelections = new Dictionary<string, object>();
            mainPageSelections.Add("Monkey", monkeyMenu);
            mainPageSelections.Add("Bear", bearMenu);
            mainPageSelections.Add("Quit", quitAction);
            currentPage = new MenuPage
            {
                title = "Zoo Menu Planner",
                selections = mainPageSelections
            };
        }

        public object RequestUserSelection()
        {
            var keys = currentPage.selections.Keys.ToList();

            Console.WriteLine(currentPage.title);
            Console.WriteLine("————————————————————");
            for (var i = 0; i < keys.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {keys[i]}");
            }
            while (true)
            {
                Console.Write("Selection: ");
                var selection = Console.ReadLine();
                if (int.TryParse(selection, out int input))
                {
                    if (input > 0 && input <= keys.Count)
                    {
                        var selectedObject = currentPage.selections[keys[input - 1]];
                        if (selectedObject is MenuPage)
                        {
                            currentPage = (MenuPage)selectedObject;
                            return RequestUserSelection();
                        }
                        if (selectedObject is Action)
                        {
                            ((Action)selectedObject).Invoke();
                        }
                        return selectedObject;
                    }
                }
                Console.WriteLine("Invalid selection, please try again.");
            }
        }

        struct MenuPage
        {
            public string title;
            public IDictionary<string, object> selections;
        }
    }
}
