using System;
using System.Collections.Generic;


namespace DriveRatingApp
{
    class Leader : TeamMember
    {
        public Leader(string firstName, string lastName, string commonID, DriveRating rating) : base(firstName, lastName, commonID, rating)
        {
        }

        public override double GetTmBonus()
        {
            return base.GetTmBonus() * 2;
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
                    if (tm != null && tm.CommonID[0] == 't')
                    {
                        Console.WriteLine($"What DRIVE rating would you like to assign to {tm.FirstName}?");
                        tm.GetDriveRating();
                    }
                    else if (tm != null)
                        Console.WriteLine("You don't have access to this person's DRIVE rating.");
                    else
                        Console.WriteLine($"No person with Common ID \"{commonID}\" exists in our database.");
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
            Console.WriteLine("Here are the TM bonuses:");
            foreach (TeamMember tm in teamMembers)
            {

                if (tm.CommonID[0] == 't')
                {
                    Console.WriteLine(tm);
                }
            }
        }
    }
}
