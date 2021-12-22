using GoldBadge_Cafe_POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using GoldBadge_Cafe_Repository;

namespace GoldBadge_Cafe_UnitTest
{
    [TestClass]
    public class CafeUnitTest
    {
        private readonly List<CafeMenu> _menu = new List<CafeMenu>();
        [TestMethod]
        public void CreatMeal()
        {
            CafeMenu testMeal = new CafeMenu(1, "Test Meal", "Test Description", "Test Ingrediants", 7.88m);
            CafeMenu_Repo menu = new CafeMenu_Repo();
            bool created = menu.CreateMeal(testMeal);

            Assert.IsTrue(created);
            Assert.IsTrue(menu.GetMenu().Contains(testMeal));
        }

        [TestMethod]
        public void GetCafeMenulByID()
        {
            CafeMenu_Repo menu = new CafeMenu_Repo();
            CafeMenu testMeal = new CafeMenu(1, "Test Meal", "Test Description", "Test Ingrediants", 7.88m);

            menu.CreateMeal(testMeal);

            Assert.AreEqual(menu.GetCafeMenuByID(1), testMeal);
        }


        [TestMethod]
        public void DeleteMeal()
        {
            CafeMenu_Repo menu = new CafeMenu_Repo();
            CafeMenu testMeal = new CafeMenu(1, "Test Meal", "Test Description", "Test Ingrediants", 7.88m);

            menu.CreateMeal(testMeal);


            bool deleted = menu.DeleteMeal(1);

            Assert.IsTrue(deleted);
            Assert.IsNull(menu.GetCafeMenuByID(1));
        }
    }
}
