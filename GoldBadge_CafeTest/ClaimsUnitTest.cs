using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using GoldBadge_Claim_POCO;
using GoldBadge_Claim_Repository;



namespace GoldBadge_CafeTest
{
    [TestClass]
    public class ClaimsUnitTest
    {

        [TestMethod]
        public void CreateClaimTest()
        {
            //Arrange
            Claim_Repo claim_Repo = new Claim_Repo();
            Claim testClaim = new Claim(1, ClaimType.Car, "Test Claim", 45, new DateTime(2018, 09, 14), new DateTime(2018, 09, 22), true);
            //Act
            bool created = claim_Repo.CreateClaim(testClaim);
            //Assert
            Assert.IsTrue(created);
            Assert.IsTrue(claim_Repo.GetAllClaims().Contains(testClaim));
        }

        [TestMethod]
        public void GetDeleteClaim()
        {
            Claim_Repo claim_Repo = new Claim_Repo();
            Claim testClaim = new Claim(1, ClaimType.Car, "Test Claim", 45, new DateTime(2018, 09, 14), new DateTime(2018, 09, 22), true);

            claim_Repo.CreateClaim(testClaim);


            bool deleted = claim_Repo.DeleteClaim();

            Assert.IsTrue(deleted);

        }

        [TestMethod]
        public void AddMultipleClaim()
        {
            Queue<Claim> claimList = new Queue<Claim>();
            Claim_Repo claim_Repo = new Claim_Repo();
            Claim testClaim1 = new Claim(1, ClaimType.Car, "Test Claim", 45, new DateTime(2018, 09, 14), new DateTime(2018, 09, 22), true);
            Claim testClaim2 = new Claim(2, ClaimType.Home, "Test Claim", 45, new DateTime(2018, 09, 14), new DateTime(2018, 09, 22), true);
            claim_Repo.CreateClaim(testClaim1);
            claim_Repo.CreateClaim(testClaim2);

            claimList.Enqueue(testClaim2);
            claimList.Enqueue(testClaim1);

            bool created = claim_Repo.AddMultipleClaims(claimList);

            Assert.IsTrue(created);
        }
    }
}
