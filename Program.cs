using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeams
{

    // Team Information

    #region Teams Information

    public struct Team
    {
        public String TeamName;
        public int NumberOfWins;
        public int NumberOfDraws;
        public int NumberOfLoses;
        public int Points;
    }
    #endregion

    class Program
    {

        #region Methods

        static void PrintMessage(String Message)
        {
            Console.WriteLine(Message);
        }

        static bool CheckNumber(String data, out int num)
        {
            bool IsNumValid = int.TryParse(data, out num);

            if (!IsNumValid)
            {
                PrintMessage("Please, Enter a Valid Number");
                num = 0;
                return false;
            }
            return true;
        }
        #endregion


        static void Main(string[] args)
        {
            
            PrintMessage("Welcome To FootBall App");



            // Store Team Data In List
            List<Team> ListTeams = new List<Team> ();



            // Loop Over Number Of Teams
            char loopIndex = 'a';

            while (loopIndex != 'e')
            {
                Team Myteam;

                // initialize values
                Myteam.NumberOfWins = 0;
                Myteam.NumberOfLoses = 0;
                Myteam.NumberOfDraws = 0;

                // Read Team Data
                PrintMessage("Please, Enter Team Name: ");
                Myteam.TeamName = Console.ReadLine();

                PrintMessage("Please, Enter Number Of Wins: ");
                if (!CheckNumber(Console.ReadLine(), out Myteam.NumberOfWins))
                    continue;

                PrintMessage("Please, Enter Number Of Draws: ");
                if (!CheckNumber(Console.ReadLine(), out Myteam.NumberOfDraws))
                    continue;

                PrintMessage("Please, Enter Number Of Loses: ");
                if (!CheckNumber(Console.ReadLine(), out Myteam.NumberOfLoses))
                    continue;


                // Calc. Teams Points
                Myteam.Points = (Myteam.NumberOfWins * 3) + (Myteam.NumberOfDraws * 1);


                // Add Iteams To List
                ListTeams.Add(Myteam);


                PrintMessage("For Exit Press 'e' , Else Press Any Key .");
                loopIndex = Convert.ToChar(Console.ReadLine());
            }



            // Sort Of Team
            int WinnerTeam = ListTeams.Max(x=>x.Points);

            Team Winner = ListTeams.Where(a => a.Points == WinnerTeam).FirstOrDefault();

            
            // Teams That Have More Than 20 Points
            List<Team> ListTeamFilter = ListTeams.Where(a=> a.Points > 20 ).ToList();

            Team Loses = ListTeams.LastOrDefault();

            // Print Team By Winner
            Console.WriteLine("The Winner Is : " + Winner.TeamName);

            
            // Console.WriteLine("The Lastes Team Is : " + Loses.TeamName + "With " + Loses.Points + "Points.");

        }
    }
}
