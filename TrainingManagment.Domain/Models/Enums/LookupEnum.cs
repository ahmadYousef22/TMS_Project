using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TrainingManagment.Domain.Models.Enums
{
    public static class LookupEnum
    {
        public enum CategoryCode
        {
            Type = 100,
            Topics = 200,
            Status = 300,
            Results = 400,
            TrainerName = 500,
            Year = 600
        }
        public enum enTrainingType
        {
            Work = 1,
            University= 2,
        }

        public enum TrainingTopics
        {
            DotNet = 3,
            Business_Analyst = 4,
            Quality_Control = 5,
            Infrastructure = 6,
            UI_UX = 7,
            Human_Resources=8,
            Finance=9,
            AI=10
        }

        public enum Status
        {
            Active = 11,
            Pending = 12,
            Finished=13
        }
        public enum Result
        {
            Joining_TPS_Team = 14,
            On_Hold = 15,
            Rejected=16,
            Quit=17,
         }

        public enum Trainer
        {
            Khalid_Salameh=1,
            Lamees_Hourani=2,
            Mariam_AlSadawi=3,
            Mohammad_Hamad=4,
            Mohammad_Ibdah=5,
            Safaa=6,
            Zakaria_Lafi=7,
            Ahmed_Sweilem = 8
        }

        public enum Year
        {
            
            Year2023= 2023,
            Year2024= 2024,
            Year2025= 2025,
            Year2026= 2026,
            Year2027= 2027,
            Year2028= 2028,
            Year2029= 2029,
            Year2030= 2030,
            Year2031=2031,
        }
    }
}
