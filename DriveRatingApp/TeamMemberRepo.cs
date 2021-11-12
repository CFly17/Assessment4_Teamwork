using System.Collections.Generic;

namespace DriveRatingApp
{
    public class TeamMemberRepo
    {
        public static List<TeamMember> GetTeamMembers()
        {
            List<TeamMember> teamMembers = new List<TeamMember>
            {
                new TeamMember("Joe", "Spacito", "t1234", DriveRating.AchievingExpectations),
                new TeamMember("Jane", "Carrie", "t1235", DriveRating.AchievingExpectations),
                new TeamMember("Praj", "Nahim", "t1236", DriveRating.AchievingExpectations),
                new Leader("Fitz", "Caldwell", "l2239", DriveRating.AchievingExpectations),
                new Leader("Leslie", "Wrightfield", "l3239", DriveRating.AchievingExpectations),
                new Director("Charlie", "Georgina", "d5538", DriveRating.AchievingExpectations),
            };

            return teamMembers;
        }
    }
}