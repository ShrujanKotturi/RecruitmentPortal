using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using RPDataAccessLayer;

namespace RPBusinessLogicLayer
{
    public class JobPostsBLL
    {

        JobPostsDAL jobPostDALObject = new JobPostsDAL();


        public int InsertJobPostDetails(JobPostsBO jobPostBOObject)
        {
            return jobPostDALObject.InsertJobPostDetails(jobPostBOObject);
        }

        public int GetPostId()
        {
            return (jobPostDALObject.GetPostId() + 1);
        }

        public string GetPostingStatus(int postId)
        {
            return jobPostDALObject.GetPostingStatus(postId);
        }

        public string GetCompanyName(string uniqueCode)
        {
            return jobPostDALObject.GetCompanyName(uniqueCode);
        }

        public string GetUniqueCode(long loginId)
        {
            return jobPostDALObject.GetUniqueCode(loginId);
        }

        public string GetCompanyNameBasedOnPostId(int postId)
        {
            return jobPostDALObject.GetCompanyNameBasedOnPostId(postId);
        }

        public string GetUniqueCodeBasedOnPostId(int postId)
        {
            return jobPostDALObject.GetUniqueCodeBasedOnPostId(postId);
        }

        public int UpdateJobPostDetails(JobPostsBO jobPostBOObject)
        {
            return jobPostDALObject.UpdateJobPostDetails(jobPostBOObject);
        }
    }
}
