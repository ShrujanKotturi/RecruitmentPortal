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
    public partial class GetInterviewSchedulePL : System.Web.UI.Page
    {
        JobSearchAndApplyBLL jsab = new JobSearchAndApplyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout";

            DataTable result = new DataTable();

            result = jsab.GetInterviewScheduleMethod();
            InterviewScheduleGridView.DataSource = result;
            InterviewScheduleGridView.DataBind();
            if (result.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('you have not been selected for any interview')", true);
            }
            else
            {
                YouHaveBeenSelectedLabel.Visible = true;
            }
        }

        protected void logoutLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Server.Transfer("Login.aspx");
        }
    }
}