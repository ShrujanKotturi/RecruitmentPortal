using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPBusinessLogicLayer;
using System.Data;
using System.Data.SqlClient;


namespace RPPresentationLayer
{
    public partial class ViewRecruiterProfile : System.Web.UI.Page
    {
        JobSearchAndApplyBLL jsab = new JobSearchAndApplyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable Result = new DataTable();
            Result = jsab.GetRecruiterProfileHavingMathchingJobPost(3);
            ViewRecruiterProfileGridView.DataSource = Result;
            ViewRecruiterProfileGridView.DataBind();
        }

        protected void ViewRecruiterProfileGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}