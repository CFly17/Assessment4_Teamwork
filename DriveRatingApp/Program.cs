using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveRatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TeamMember> list = TeamMemberRepo.GetTeamMembers();
            bool goOn = true;
            while (goOn == true)
            {
                Console.WriteLine("Welcome. Please enter your Common ID: ");
                string userCommonID = Console.ReadLine();
                switch (userCommonID[0])
                {
                    case 'd':
                        TeamMember director = ConfirmID(userCommonID, list);
                        Console.WriteLine($"Adeiu, {director.FirstName}. A glass of wine?");
                        director.MenuFlow(list);
                        director.GetDirectorBonus1(list);
                        break;

                    case 'l':
                        TeamMember leader = ConfirmID(userCommonID, list);
                        Console.WriteLine($"Whatup {leader}!");
                        leader.MenuFlow(list);
                        break;

                    case 't':
                        TeamMember teamMember = ConfirmID(userCommonID, list);
                        Console.WriteLine($"Whatup {teamMember.FirstName}!");
                        Console.WriteLine(teamMember);
                        break;

                    default:
                        Console.WriteLine("You must not work here.");
                        break;
                }
                goOn = Continue();
            }
        }

        public static TeamMember ConfirmID(string commonIDEntered, List<TeamMember> list)
        {
            foreach (TeamMember member in list)
            {
                if (commonIDEntered == member.CommonID)
                {
                    return member;
                }
            }
            return null;
        }

        public static bool Continue()
        {
            Console.WriteLine("Would you like to return to Main menu? [y]es/[n]o");
            string response = Console.ReadLine();
            if (response == "y" || response == "yes")
            {
                return true;
            }
            else if (response == "n" || response == "no")
            {
                Console.WriteLine("See ya!");
                return false;
            }
            else 
            {
                Console.WriteLine("Try again.");
                return Continue();
            }
        }

    }
}