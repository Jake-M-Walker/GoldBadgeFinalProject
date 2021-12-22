using GoldBadge_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldBadge_Cafe;
using GoldBadge_Cafe_POCO;

namespace GoldBadge_Cafe
{
    class CafeProgram_UI
    {
        private readonly CafeMenu_Repo _menuRepo = new CafeMenu_Repo();

        public void Run()
        {

            RunApplication();
        }


        public void Menu()
        {
            Console.WriteLine("Welcome to the Komodo Cafe!\n\n" +
                "What would you like to do\n\n\n\n" +
                "1. View all Meals available\n" +
                "2. Add a Meal\n" +
                "3. Delete a Meal\n" +
                "4. Exit") ;
        }

        private void RunApplication()
        {
            Seed();
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Menu();
                string userMenuSelection = Console.ReadLine();
                switch (userMenuSelection)
                {
                    case "1":
                        ViewAllMenuItems();
                        break;
                    case "2":
                        AddMeal();
                        break;
                    case "3":
                        DeleteMeal();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<CafeMenu> ListOfAllMeals = _menuRepo.GetMenu();
            foreach(CafeMenu cafeMenu in ListOfAllMeals)
            {
                DisplayMenu(cafeMenu);
            }
            Console.WriteLine("");
            Console.WriteLine("Please hit any key to continue");
            Console.ReadLine();


        }

        private void DisplayMenu(CafeMenu cafeMenu)
        {
            Console.WriteLine("");
            Console.WriteLine($"Meal Number: {cafeMenu.MealNumber}\n" +
                    $"Meal Name: {cafeMenu.MealName}\n" +
                    $"Meal Description: {cafeMenu.MealDescription}\n" +
                    $"Ingrediants: {cafeMenu.MealIngrediants}\n" +
                    $"Price: {cafeMenu.Price}");
            Console.WriteLine("***************************************");
            Console.WriteLine("");
        }


        private void AddMeal()
        {
            Console.Clear();
            CafeMenu cafeMenuItem = new CafeMenu();

            //Meal Number
            Console.WriteLine("Please enter the new Meal's Number");
            cafeMenuItem.MealNumber = int.Parse(Console.ReadLine());

            //Meal Name
            Console.WriteLine("Please enter the new Meal's Name");
            cafeMenuItem.MealName = Console.ReadLine();

            //Meal Description
            Console.WriteLine("Please enter the new Meal's Description");
            cafeMenuItem.MealDescription = Console.ReadLine();

            //Meal Ingrediants
            Console.WriteLine("Please enter the Ingrediants of the new Meal");
            cafeMenuItem.MealIngrediants = Console.ReadLine();

            //Meal Price
            Console.WriteLine("Please enter the Price of the new Meal");
            cafeMenuItem.Price = decimal.Parse(Console.ReadLine());

            bool isSuccessful = _menuRepo.CreateMeal(cafeMenuItem);
            if (isSuccessful)
            {
                Console.WriteLine($"{cafeMenuItem.MealName} has been added to the database");
            }
            else
            {
                Console.WriteLine($"{cafeMenuItem.MealName} could not be added to the database");
            }

        }

        private void DeleteMeal()
        {
            Console.Clear();
            ViewAllMenuItems();

            Console.WriteLine("Please enter the meal number that needs to be deleted");

            //Get Meal Number
            int userInput = int.Parse(Console.ReadLine());
            CafeMenu cafeMenu = _menuRepo.GetCafeMenuByID(userInput);
            DisplayMenu(cafeMenu);

            //Verify correct meal number
            Console.WriteLine("Is this the correct meal? (y/n)");
            string userConfirm = Console.ReadLine().ToLower();
            if(userConfirm == "y")
            {
                bool wasDeleted = _menuRepo.DeleteMeal(userInput);
                if (wasDeleted)
                {
                    Console.WriteLine($"{userInput} was successfully deleted");
                }
                else
                {
                    Console.WriteLine($"{userInput} was not deleted");
                }
            }
            else
            {
                Console.WriteLine("Please enter the meal number that needs to be deleted");
                userInput = int.Parse(Console.ReadLine());
            }
        }


        private void Seed()
        {
            CafeMenu meal1 = new CafeMenu()
            {
                MealNumber = 1,
                MealName = "Burger",
                MealDescription = "Hamburger with a Lettuce, Tomato, Onion, Ketchup, and Mustad comes with a side of fries",
                MealIngrediants = "Beef Patty, Lettuce, Tomato, Onion, Ketchup, Mustard, French Fries",
                Price = 9.99m
            };

            CafeMenu meal2 = new CafeMenu()
            {
                MealNumber = 2,
                MealName = "Chicken Sandwich",
                MealDescription = "Chicken Sandwich with Pickles comes with a side of fries",
                MealIngrediants = "Fried Chicken Breast, Pickles, French Fries",
                Price = 8.99m
            };

            _menuRepo.CreateMeal(meal1);
            _menuRepo.CreateMeal(meal2);


}
    }
}
