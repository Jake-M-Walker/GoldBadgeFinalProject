using GoldBadge_Cafe_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoldBadge_Cafe_Repository
{
    public class CafeMenu_Repo
    {
        private readonly List<CafeMenu> _menu = new List<CafeMenu>();

        //Create
        public bool CreateMeal(CafeMenu cafeMenu)
        {
            if(cafeMenu == null)
            {
                return false;
            }
            _menu.Add(cafeMenu);
            return true;
        }

        //Read
        public List<CafeMenu> GetMenu()
        {
            return _menu;
        }

        public CafeMenu GetCafeMenuByID(int id)
        {
            foreach(var cafeMenu in _menu)
            {
                if(id == cafeMenu.MealNumber)
                {
                    return cafeMenu;
                }
            }
            return null;
        }

        //Delete
        public bool DeleteMeal(int id)
        {
            CafeMenu cafeMenuToBeDeleted = GetCafeMenuByID(id);
            if(cafeMenuToBeDeleted == null)
            {
                return false;
            }
            else
            {
                _menu.Remove(cafeMenuToBeDeleted);
                return true;
            }
        }
    }
}
