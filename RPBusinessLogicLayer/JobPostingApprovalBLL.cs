using System.Data;
using RPBusinessObject;
using RPDataAccessLayer;

namespace RPBusinessLogicLayer
{
  public class JobPostingApprovalBLL
    {
        JobPostingApprovalDAL ObjJobPostingApprovalDAL=new JobPostingApprovalDAL();

        public DataTable LoadPendingPosts()
        {
            return ObjJobPostingApprovalDAL.LoadPendingPosts();
        }
        
        public DataTable ViewAllPosts()
            {
                return ObjJobPostingApprovalDAL.ViewAllPosts();
            }

        public DataTable ViewPostsByCompanyName(RecruiterProfileBO ObjRecruiterProfileBO1)
                {
                    return ObjJobPostingApprovalDAL.ViewPostsByCompanyName(ObjRecruiterProfileBO1);
                }

        public DataTable ViewPostsByStatus(JobPostsBO ObjJobPostsBO1)
                    {
                        return ObjJobPostingApprovalDAL.ViewPostsByStatus(ObjJobPostsBO1);
                    }
        
        public int UpdatePostStatus(JobPostsBO ObjJobPostsBO1)
                    {
                        return ObjJobPostingApprovalDAL.UpdatePostStatus(ObjJobPostsBO1);
                    }
    }
}
