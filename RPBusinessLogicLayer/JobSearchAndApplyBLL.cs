using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPDataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace RPBusinessLogicLayer
{
    public class JobSearchAndApplyBLL
    {
        JobSearchAndApplyDAL jsad = new JobSearchAndApplyDAL();
        DataTable dataset = new DataTable();

        public DataTable NotAppliedJobSearchMethod(string CompanyName, string PositionName, string ExperienceRequired, string SkillSet, string LocationOfTheOpenings,long loginId)
        {
            return jsad.NotAppliedJobSearchMethod(CompanyName, PositionName, ExperienceRequired, SkillSet, LocationOfTheOpenings, loginId);
        }

        public DataTable AppliedJobSearchMethod(string CompanyName, string PositionName, string ExperienceRequired, string SkillSet, string LocationOfTheOpenings, long loginId)
        {
            return jsad.AppliedJobSearchMethod(CompanyName, PositionName, ExperienceRequired, SkillSet, LocationOfTheOpenings, loginId);
        }


        public int GetPostIdMethod(string UniqueCode, string LocationOfOpening, string Skillset, double TentativeSalary, int ExperienceRequired, string PositionName, string NumberOfOpening, DateTime CloseDate)
        {
            return jsad.GetPostIdMethod(UniqueCode, LocationOfOpening, Skillset, TentativeSalary, ExperienceRequired, PositionName, NumberOfOpening, CloseDate);
        }

        public int InsertIntoTblApplicationMethod(int PostId, string UniqueCode, long LoginId)
        {
            return jsad.InsertIntoTblApplicationMethod(PostId, UniqueCode, LoginId);
        }

        public DataTable GetInterviewScheduleMethod()
        {
            return jsad.GetInterviewScheduleMethod();
        }

        public DataTable GetPostDetailMethod(int PostId)
        {
            return jsad.GetPostDetailMethod(PostId);
        }

        public DataTable GetRecruiterProfileHavingMathchingJobPost(long LoginId)
        {
            return jsad.GetRecruiterProfileHavingMathchingJobPost(LoginId);
        }

    }
}
