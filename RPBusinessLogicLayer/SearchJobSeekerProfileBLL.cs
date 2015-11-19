using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RPBusinessObject;
using RPDataAccessLayer;

namespace RPBusinessLogicLayer
{
    public class SearchJobSeekerProfileBLL
    {
        SearchJobSeekerProfileDAL searchJobSeekerObject = new SearchJobSeekerProfileDAL();

        public DataTable SearchJobSeekerProfileUsingPostDetails(int postId)
        {
            return searchJobSeekerObject.SearchJobSeekerProfileUsingPostDetails(postId);
        }

        public DataTable BindPostDetails(int loginId)
        {
            return searchJobSeekerObject.BindPostDetails(loginId);
        }

        public DataTable GetRecruiterUserName(int loginId)
        {
            return searchJobSeekerObject.GetRecruiterUserName(loginId);
        }
    }
}
