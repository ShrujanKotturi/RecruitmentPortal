using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RPPresentationLayer
{
    public partial class JobSeekerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // this.Master.userId = Session["userId"].ToString();
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout";          
        }

     
        
        protected void editJobseekerProfileAnchor(object sender, EventArgs e)
        {
            Server.Transfer("JobSeekerProfileCreationPLL.aspx");
        }
        protected void jobSearchAndApplyAnchor(object sender, EventArgs e)
        {
            Server.Transfer("~/JobSearchAndApplyPL.aspx");
        }

        protected void logoutLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Server.Transfer("Login.aspx");
        }
        protected void interviewScheduleAnchor(object sender, EventArgs e)
        {
            Server.Transfer("~/GetInterviewSchedulePL.aspx");
        }
        protected void viewMatchingJobAnchor(object sender, EventArgs e)
        {
            Server.Transfer("ViewRecruiterProfile.aspx");
        }
    }
}