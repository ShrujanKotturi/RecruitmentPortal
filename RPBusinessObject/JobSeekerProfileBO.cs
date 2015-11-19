using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPBusinessObject
{
    public class JobSeekerProfileBO
    {
        public long LoginId { set; get; }
        public string CandidateName { set; get; }
        public int YearsOfExperience { set; get; }
        public string SkillSet { set; get; }
        public string Address { set; get; }
        public string EmailId { set; get; }
        public string Phone { set; get; }
        public string Industry { set; get; }
        public string CurrentPosition { set; get; }
        public double CurrentSalary { set; get; }
        public string ExpectedPosition { set; get; }
        public string ExpectedJobLocation { set; get; }
        public string ResumeFileName { set; get; }
        public string ResumeFilePath { set; get; }
    }
}
