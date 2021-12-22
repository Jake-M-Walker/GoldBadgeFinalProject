using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoldBadge_Badge_POCO;
using GoldBadge_Badge_Repository;
using System.Collections.Generic;

namespace GoldBadge_Badge_UnitTest
{
    [TestClass]
    public class BadgeUnitTest
    {
        
        [TestMethod]
        public void CreateBadge()
        {
            Badge_Repo _badgeRepo = new Badge_Repo();
            Badge testBadge = new Badge(1234567,"Jack",new List<string> { "A1", "A2", "A3" });

            bool created = _badgeRepo.CreateBadge(testBadge);

            Assert.IsTrue(created);
            Assert.IsTrue(_badgeRepo.GetAllBadges().ContainsKey(1234567));
        }

        [TestMethod]
        public void DontCreateExistingBadge()
        {
            Badge_Repo _badgeRepo = new Badge_Repo();
            Badge testBadge = new Badge(1234567, "Jack", new List<string> { "A1", "A2", "A3" });

            _badgeRepo.CreateBadge(testBadge);
            bool created = _badgeRepo.CreateBadge(testBadge);

            Assert.IsFalse(created);
        }

        [TestMethod]
        public void GetBadgeByID()
        {
            Badge_Repo _badgeRepo = new Badge_Repo();
            Badge testBadge = new Badge(1234567, "Jack", new List<string> { "A1", "A2", "A3" });

            _badgeRepo.CreateBadge(testBadge);

            Assert.AreEqual(_badgeRepo.GetBadgeByID(1234567), testBadge);
        }

        [TestMethod]
        public void UpdateeExistingBadge()
        {
            Badge_Repo _badgeRepo = new Badge_Repo();
            Badge testBadge = new Badge(1234567, "Jack", new List<string> { "A1", "A2", "A3" });

            _badgeRepo.CreateBadge(testBadge);

            Badge updatedBadge = new Badge(1234567, "John", new List<string> { "A1", "A2" });

            bool updated = _badgeRepo.UpdateBadge(updatedBadge);
            Badge foundBadge = _badgeRepo.GetBadgeByID(1234567);

            Assert.IsTrue(updated);
            Assert.AreEqual(foundBadge.Name, updatedBadge.Name);
            Assert.AreEqual(foundBadge.Doors, updatedBadge.Doors);
        }

        [TestMethod]
        public void DontUpdateBadge()
        {
            Badge_Repo _badgeRepo = new Badge_Repo();
            Badge testBadge = new Badge(1234567, "Jack", new List<string> { "A1", "A2", "A3" });

            _badgeRepo.CreateBadge(testBadge);

            Badge updatedBadge = new Badge(123467, "John", new List<string> { "A1", "A2" });

            bool updated = _badgeRepo.UpdateBadge(updatedBadge);
            Badge foundBadge = _badgeRepo.GetBadgeByID(1234567);

            Assert.IsFalse(updated);
            Assert.AreEqual(_badgeRepo.GetBadgeByID(1234567), testBadge);
            Assert.IsNull(_badgeRepo.GetBadgeByID(123467));

        }


        [TestMethod]
        public void DeleteBadge()
        {
            Badge_Repo _badgeRepo = new Badge_Repo();
            Badge testBadge = new Badge(1234567, "Jack", new List<string> { "A1", "A2", "A3" });

            _badgeRepo.CreateBadge(testBadge);


            bool deleted = _badgeRepo.DeleteBadge(1234567);

            Assert.IsTrue(deleted);
            Assert.IsNull(_badgeRepo.GetBadgeByID(1234567));

        }

        [TestMethod]
        public void DontDeleteBadge()
        {
            Badge_Repo _badgeRepo = new Badge_Repo();
            Badge testBadge = new Badge(1234567, "Jack", new List<string> { "A1", "A2", "A3" });

            _badgeRepo.CreateBadge(testBadge);


            bool deleted = _badgeRepo.DeleteBadge(124567);

            Assert.IsFalse(deleted);
            Assert.IsNotNull(_badgeRepo.GetBadgeByID(1234567));

        }

    }
}
