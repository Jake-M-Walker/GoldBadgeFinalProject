using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Cafe_POCO
{
    public class CafeMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngrediants { get; set; }
        public decimal Price { get; set; }

        public CafeMenu() { }

        public CafeMenu(int mealNumber, string mealName, string mealDescription, string mealIngrediants, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngrediants = mealIngrediants;
            Price = price;
        }
    }
}
