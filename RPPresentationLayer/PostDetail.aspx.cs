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
    public partial class PostDetail : System.Web.UI.Page
    {
        JobSearchAndApplyBLL jsab = new JobSearchAndApplyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable Result = new DataTable();
            int PostId =Convert.ToInt32(Request.QueryString[0]);

            Result = jsab.GetPostDetailMethod(PostId);
            PostDetailGridView.DataSource = Result;
            PostDetailGridView.DataBind();
        }

        protected void PostDetailGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}