using GoldBadge_Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldBadge_Badge_POCO;

namespace GoldBadge_Badge_UI
{
    class BadgeProgram_UI
    {
        private readonly Badge_Repo _badgeRepo = new Badge_Repo();
        public void Run()
        {
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to Komodo Insurance Badge Application\n\n\n" + "What would you like to do?\n\n");
            Console.WriteLine("1. Create a Badge\n" +
                "2. Update a Badge's Doors\n" +
                "3. View All Badges\n" +
                "4. Exit");
        }

        public void RunApplication()
        {
            Seed();
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Menu();
                string userMenuInput = Console.ReadLine();
                switch (userMenuInput)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ViewAll();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }

            }
        }

        private void CreateBadge()
        {
            Badge newbadge = new Badge();
            List<string> doors = new List<string>();
            Console.WriteLine("Please enter the badge number");
            newbadge.ID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the badge name");
            newbadge.Name = Console.ReadLine();

            string moorDoors = "y";

            do
            {
                Console.WriteLine("Please enter the Door this badge has access to");
                doors.Add(Console.ReadLine());
                Console.WriteLine("Would you like to add another door? (y/n)");
                moorDoors = Console.ReadLine().ToLower();
            } while (moorDoors == "y");

            newbadge.Doors = doors;

            _badgeRepo.CreateBadge(newbadge);
        }

        private void UpdateBadge()
        {
            Console.WriteLine("Please enter the badge number you would like to update");
            int oldbadge = int.Parse(Console.ReadLine());

            Badge badgeToBeUpdated = _badgeRepo.GetBadgeByID(oldbadge);

            Console.WriteLine("Please enter the new name for the badge");
            badgeToBeUpdated.Name = Console.ReadLine();
            bool finished = false;
            do
            {
                DoorMenu();
                string doorMenuInput = Console.ReadLine();
                switch (doorMenuInput)
                {
                    case "1":
                        Console.WriteLine("Please enter the doors for the new badge");
                        badgeToBeUpdated.Doors.Add(Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("Please enter the door that needs to be removed");
                        badgeToBeUpdated.Doors.Remove(Console.ReadLine());
                        break;
                    case "3":
                        finished = true;
                        break;
                    default:
                        break;
                }
            } while (!finished);


        }

        private void ViewAll()
        {
            Dictionary<int, Badge> badges = _badgeRepo.GetAllBadges();
            Console.Clear();
            Console.WriteLine("{0,-35}{1,-35}{2,-35}", "Badge #", "Name", "Doors");
            foreach (var badge in badges.Values)
            {
                Console.WriteLine("{0,-35}{1,-35}{2,-35}", badge.ID, badge.Name, string.Join(",", badge.Doors));
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadKey();

        }


        private void Seed()
        {
            Badge badge1 = new Badge(12345, "Joe", new List<string> { "A5", "A7" });
            _badgeRepo.CreateBadge(badge1);
        }

        private void DoorMenu()
        {
            Console.WriteLine("1. Add a Door\n" +
                "2. Delete a Door\n" +
                "3. Finished Updating");
        }
    }
}
