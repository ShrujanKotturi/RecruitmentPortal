using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using RPDataAccessLayer;

namespace RPBusinessLogicLayer
{
  public  class JobSeekerProfileBLL
    {
      JobSeekerProfileDAL jobSeekerProfile = new JobSeekerProfileDAL();

      public int InsertJobSeekerProfile(JobSeekerProfileBO jobSeeker)
      {
          return jobSeekerProfile.InsertJobSeekerProfile(jobSeeker);
      }
    }
}
