using System;
using System.Collections.Generic;

namespace DriveRatingApp
{
    class Director : TeamMember
    {
        public Director(string firstName, string lastName, string commonID, DriveRating rating) : base(firstName, lastName, commonID, rating)
        {

        }

        public override double GetTmBonus()
        {
            return base.GetTmBonus() * 3;
        }

        public override void GetDirectorBonus1(List<TeamMember> teamMembers)
        {
            int exceedsCount = 0;
            int needsCount = 0;
            int nonDirectorCount = 0;
            foreach (var tm in teamMembers)
            {
                if (tm.CommonID[0] != 'd')
                {
                    if (((int)tm.DriveRating) >= 2) //checks if tms rating is exceeds or rockstar
                    {
                        exceedsCount++;
                    }
                    else if (tm.DriveRating == DriveRating.NeedsImprovement)
                    {
                        needsCount++;
                    }
                    nonDirectorCount++;
                }
            }
            if (exceedsCount == nonDirectorCount)
            {
                DriveRating = DriveRating.RockStar;
            }
            else if (exceedsCount >= 3 && needsCount < 1)
            {
                DriveRating = DriveRating.ExceedExpectations;
            }
            else if (needsCount <= 1)
            {
                DriveRating = DriveRating.AchievingExpectations;
            }
            else
            {
                DriveRating = DriveRating.NeedsImprovement;
            }
        }

        public override void MenuFlow(List<TeamMember> teamMembers)
        {
            Console.WriteLine("What would you like to do?\n[1]Update TM DRIVE rating\n[2]View bonus report");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    Console.WriteLine("Enter the common ID of the TM whose DRIVE you would like to update: ");
                    string commonID = Console.ReadLine();
                    TeamMember tm = Program.ConfirmID(commonID, teamMembers);
                    if (tm != null)
                    {
                        Console.WriteLine($"What DRIVE rating would you like to assign to {tm.FirstName}?");
                        tm.GetDriveRating();
                    }
                    else
                        Console.WriteLine("That person doesn't exist.");
                    break;
                case "2":
                    PrintBonuses(teamMembers);
                    break;
                default:
                    Console.WriteLine("nah");
                    break;
            }

        }

        public override void PrintBonuses(List<TeamMember> teamMembers)
        {
            foreach (TeamMember tm in teamMembers)
            {
                Console.WriteLine("Here are the TM bonuses:");
                Console.WriteLine(tm);
            }
        }

    }
}
