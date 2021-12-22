using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldBadge_Claim_POCO;
using GoldBadge_Claim_Repository;

namespace GoldBadge_Claim
{
    class ClaimProgram_UI
    {
        private readonly Claim_Repo _claim_Repo = new Claim_Repo();

        public void Run()
        {

            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to the Komodo Cafe!\n\n" +
                              "What would you like to do\n\n\n\n" +
                              "1. Create a Claim\n" +
                              "2. See All Claims\n" +
                              "3. Take Care of the Next Claim\n" +
                              "4. Exit");
        }

        public void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Seed();
                Menu();
                string userMenuInput = Console.ReadLine();
                switch (userMenuInput)
                {
                    case "1":
                        CreateClaim();
                        break;
                    case "2":
                        ViewAll();
                        break;
                    case "3":
                        NextClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void CreateClaim()
        {
            Console.Clear();

            Claim newClaim = new Claim();

            //Get Claim Type
            Console.WriteLine("Please enter the claim Type:\n\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int userInputClaimType = int.Parse(Console.ReadLine());
            newClaim.Type = (ClaimType)userInputClaimType;

            //Get Claim Description
            Console.WriteLine("Please enter a description of the claim");
            newClaim.Description = Console.ReadLine();

            //Get the Amount of Claim
            Console.WriteLine("Please enter the amount of the claim");
            newClaim.Amount = decimal.Parse(Console.ReadLine());

            //Get the Date of the Incident
            Console.WriteLine("Please enter the date of the Incident");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            //Get the Date of the Claim
            Console.WriteLine("Please enter the date of the Claim");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            //Validity
            if(newClaim.DateOfClaim.CompareTo(newClaim.DateOfIncident) >= 0 && newClaim.DateOfClaim.Subtract(newClaim.DateOfIncident) < new TimeSpan(30,0,0,0)) // we need to change this
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            bool isSuccessful = _claim_Repo.CreateClaim(newClaim);
            if(isSuccessful)
            {
                Console.WriteLine("");
                Console.WriteLine($"{newClaim.ID} has been successfully added to the queue");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine($"{newClaim.ID} has not been added to the queue");
            }


        }

        public void ViewAll()
        {
            int tableWidth = Console.WindowWidth;
            Queue<Claim > claims = _claim_Repo.GetAllClaims();
            Console.Clear();
            Console.WriteLine(String.Format("|{0, -35}|{1, -35}|{2, -35}|{3, -35}|{4, -35}|{5, -35}|{6, -35}|", "Claim ID", "Claim Type", "Description", "Amount", "Date of Incident", "Date of Claim", "Valid"));
            PrintLine(tableWidth);
            foreach(var claim in claims)
            {
                Console.WriteLine(String.Format("|{0, -35}|{1, -35}|{2, -35}|{3, -35}|{4, -35}|{5, -35}|{6, -35}|", claim.ID, claim.Type, claim.Description, claim.Amount, claim.DateOfIncident, claim.DateOfClaim, claim.IsValid));
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadKey();

            Console.Clear();
        }


        public bool NextClaim()
        {

            Console.Clear();
            Queue<Claim> claims = _claim_Repo.GetAllClaims();
            int tableWidth = Console.WindowWidth;
            Claim claim = claims.Peek();
            Console.WriteLine(String.Format("|{0, -35}|{1, -35}|{2, -35}|{3, -35}|{4, -35}|{5, -35}|{6, -35}|", "Claim ID", "Claim Type", "Description", "Amount", "Date of Incident", "Date of Claim", "Valid"));
            PrintLine(tableWidth);
            Console.WriteLine(String.Format("|{0, -35}|{1, -35}|{2, -35}|{3, -35}|{4, -35}|{5, -35}|{6, -35}|", claim.ID, claim.Type, claim.Description, claim.Amount,claim.DateOfIncident, claim.DateOfClaim, claim.IsValid));


            Console.WriteLine("Would you like to take care of this claim? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            if(userInput == "y")
            {
                claims.Dequeue();
                Console.Clear();
                return true;
            }
            else
            {
                Console.Clear();
                return false;
            }

        }


       private void Seed()
        {
            Queue<Claim> claimList = new Queue<Claim>();
            Claim claim1 = new Claim(ClaimType.Car, "Car accident on 465", 400.00m,new DateTime(2018, 04, 15),new DateTime(2018, 04, 27) , true);
            Claim claim2 = new Claim(ClaimType.Home, "House Fire in Kitchen", 40000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 13), true);
            Claim claim3 = new Claim(ClaimType.Theft, "Stolen Pancakes", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            claimList.Enqueue(claim1);
            claimList.Enqueue(claim2);
            claimList.Enqueue(claim3);

            _claim_Repo.AddMultipleClaims(claimList);

        }


        private static void PrintLine(int tableWidth)
        {
            Console.WriteLine(new string('_', Console.WindowWidth));
        }


    }
}
