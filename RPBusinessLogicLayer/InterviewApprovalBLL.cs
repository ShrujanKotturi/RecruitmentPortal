using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RPBusinessObject;
using RPDataAccessLayer;

namespace RPBusinessLogicLayer
{
  public class InterviewApprovalBLL
    {
      InterviewApprovalDAL ObjInterviewApprovalDAL = new InterviewApprovalDAL();

      public DataTable LoadIVDetails()
      {
          return ObjInterviewApprovalDAL.LoadIVDetails();
      }

      public DataTable SortDetailsByUniqueCode()
      {
          return ObjInterviewApprovalDAL.SortDetailsByUniqueCode();
      }

      public DataTable SortDetailsByCompanyName()
      {
          return ObjInterviewApprovalDAL.SortDetailsByCompanyName();
      }

      public DataTable SortDetailsByInterviewDate()
      {
          return ObjInterviewApprovalDAL.SortDetailsByInterviewDate();
      }

      public DataTable LoadIVDetailsByCompanyName(RecruiterProfileBO ObjRecruiterProfileBO1)
      {
          return ObjInterviewApprovalDAL.LoadIVDetailsByCompanyName(ObjRecruiterProfileBO1);
      }

      public DataTable LoadIVDetailsByInterViewDate(ApplicationBO ObjApplicationBO1)
      {
          return ObjInterviewApprovalDAL.LoadIVDetailsByInterViewDate(ObjApplicationBO1);
      }

      public int UpdateIVDetails(ApplicationBO ObjApplicationBO1)
      {
          return ObjInterviewApprovalDAL.UpdateIVDetails(ObjApplicationBO1);
      }

      public DataTable LoadApplicantDetails(JobSeekerProfileBO ObjJobSeekerProfile)
      {
          return ObjInterviewApprovalDAL.LoadApplicantDetails(ObjJobSeekerProfile);
      }

    }
}
