using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPBusinessObject
{
    public class JobPostsBO
    {
        public string UniqueCode { get; set; }
        public int PostId { get; set; }
        public string PositionName { get; set; }
        public string NumberOfOpenings { get; set; }
        public string LocationOfTheOpenings { get; set; }
        public int ExperienceRequired { get; set; }
        public string SkillSet { get; set; }
        public double TentativeSalary { get; set; }
        public DateTime CloseDate { get; set; }
        public DateTime JoiningDate { get; set; }
        public string PostingStatus { get; set; }
        public string Comments { get; set; }

    }
}
