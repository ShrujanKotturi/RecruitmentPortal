using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPDataAccessLayer;
using RPBusinessObject;
using System.Data;

namespace RPBusinessLogicLayer
{
    public class RecruiterProfileBLL
    {
        RecruiterProfileDAL recruiterProfileBLLObject = new RecruiterProfileDAL();

        public string GetUniqueCodeIfExists(RecruiterProfileBO recruiterProfileBOObject)
        {
            return recruiterProfileBLLObject.GetUniqueCodeIfExists(recruiterProfileBOObject);
        }

        public string GenerateUniqueCode(string companyName)
        {
            return recruiterProfileBLLObject.GenerateUniqueCode(companyName);
        }

        public int InsertRecruitmentProfileDetails(RecruiterProfileBO recruiterProfile)
        {
           return recruiterProfileBLLObject.InsertRecruitmentProfileDetails(recruiterProfile);
        }

        public int UpdatePhoneNumber(RecruiterProfileBO recruiterProfileBOObject)
        {
            return recruiterProfileBLLObject.UpdatePhoneNumber(recruiterProfileBOObject);
        }

        public int UpdateEmailId(RecruiterProfileBO recruiterProfileBOObject)
        {
            return recruiterProfileBLLObject.UpdateEmailId(recruiterProfileBOObject);
        }

        public int UpdateRecruiterAddress(RecruiterProfileBO recruiterProfileBOObject)
        {
            return recruiterProfileBLLObject.UpdateRecruiterAddress(recruiterProfileBOObject);
        }
       
    }
}
