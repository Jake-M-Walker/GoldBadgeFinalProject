using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldBadge_Claim_POCO;

namespace GoldBadge_Claim_Repository
{
    public class Claim_Repo
    {

        //private readonly List<Claim> _claims = new List<Claim>();
        private Dictionary<int, Claim> _claims = new Dictionary<int, Claim>();
        private Queue<Claim> claimsQue = new Queue<Claim>();

        private int nextId = 1;

        //Create
        public bool CreateClaim(Claim claim)
        {
            int id = GenerateID();

            claim.ID = id;

            claimsQue.Enqueue(claim);
            return true;

        }


        //Read
        public Queue<Claim> GetAllClaims()
        {
            return claimsQue;
        }

        /*public Claim GetClaimByID()
        {
            return claimsQue.Dequeue();
            foreach(Claim element in claimsQue)
            {
                Console.WriteLine(element);
            }
        }
        */

        /* Not Needed
        //Update
        public bool UpdateClaim(Claim newClaim)
        {
            Claim oldClaim = _claims[newClaim.ID];
            oldClaim.Type = newClaim.Type;
            oldClaim.Description = newClaim.Description;
            oldClaim.Amount = newClaim.Amount;
            oldClaim.DateOfIncident = newClaim.DateOfIncident;
            oldClaim.DateOfClaim = newClaim.DateOfClaim;
            oldClaim.IsValid = newClaim.IsValid;

            if(_claims[oldClaim.ID] == newClaim)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        */

        public bool DeleteClaim()
        {
            claimsQue.Dequeue();
            return true;
        }

        private int GenerateID()
        {
            int newId = nextId;
            nextId++;
            return newId;
        }


        public bool AddMultipleClaims(Queue<Claim> claims)
        {
            foreach (var claim in claims)
            {
                int id = GenerateID();

                claim.ID = id;
                claimsQue.Enqueue(claim);
                return true;
            }
            return false;
        }
    }
}
