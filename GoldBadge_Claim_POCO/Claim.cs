using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Claim_POCO
{

    public enum ClaimType {Car = 1, Home, Theft }
    public class Claim
    {
        public int ID { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim (ClaimType type, string description, decimal amount, DateTime dateOfIncident, DateTime dateofClaim, bool isValid)
        {
            Type = type;
            Description = description;
            Amount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateofClaim;
            IsValid = isValid;

        }
        public Claim(int id, ClaimType type, string description, decimal amount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ID = id;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
