using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveRatingApp
{
    public class TeamMember
    {
        //This is an auto-implemented property for the DriveRating Enum
            public DriveRating DriveRating { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CommonID { get; set; }
        
        public TeamMember(string firstName, string lastName, string commonID, DriveRating rating)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CommonID = commonID;
            this.DriveRating = rating;
        }

        public virtual double GetTmBonus()
        {

            switch (DriveRating)
            {
                case DriveRating.NeedsImprovement:
                    return 0;
                case DriveRating.AchievingExpectations:
                    return 1000;
                case DriveRating.ExceedExpectations:
                    return 5000;
                case DriveRating.RockStar:
                    return 10000;
                default:
                    return 0;

            }
        }


        //VIRTUAL METHODS YO
        public virtual void PrintBonuses(List<TeamMember> teamMembers)
        {
        }
        public virtual void GetDirectorBonus1(List<TeamMember> teamMembers)
        {
        }
        public virtual void MenuFlow(List<TeamMember> teamMembers)
        {
        }

        public void GetDriveRating()
        {
            Console.WriteLine("Enter a rating: \n1)Needs Improvement\n(2)Achieving Expectation\n(3)Exceeds Expectations\n(4)RockStar");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    DriveRating = DriveRating.NeedsImprovement;
                    break;
                case "2":
                    DriveRating = DriveRating.AchievingExpectations;
                    break;
                case "3":
                    DriveRating = DriveRating.ExceedExpectations;
                    break;
                case "4":
                    DriveRating = DriveRating.RockStar;
                    break;
                default:
                    Console.WriteLine("Try again.");
                    break;
            }
        }

        public override string ToString()
        {
            return $"\n\tName: {LastName}, {FirstName}.\n\tBonus: {GetTmBonus()}";
        }

    }
    

    public enum DriveRating
    {
        NeedsImprovement,
        AchievingExpectations,
        ExceedExpectations,
        RockStar
    }
}