using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPDataAccessLayer;
using System.Data;

namespace RPBusinessLogicLayer
{
    public class ShowPostingsBLL
    {
        ShowPostingsDAL showPostingBLLObject = new ShowPostingsDAL();

        public DataTable GetJobPostingDetails(string uniqueCode)
        {
            return showPostingBLLObject.GetJobPostingDetails(uniqueCode);
        }
        public DataSet GetJobPostingDetails1(string uniqueCode)
        {
            return showPostingBLLObject.GetJobPostingDetails1(uniqueCode);
        }
    }
}
