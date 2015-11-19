using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RPBusinessLogicLayer;

namespace RPPresentationLayer
{
    public partial class ShowPostings : System.Web.UI.Page
    {
        ShowPostingsBLL showPostingsPLObject = new ShowPostingsBLL();
        string uniqueCodePass = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout";

            bool showPostingsFlagFromRecruiter = false;
            showPostingsFlagFromRecruiter = Convert.ToBoolean(Session["ToShowPostingsPageFlagFromRecruiterProfile"]);

            bool showPostingsFlagFromJobPost = false;
            showPostingsFlagFromJobPost = Convert.ToBoolean(Session["ToShowPostingsPageFlagFromJobPost"]);

            if (!IsPostBack && showPostingsFlagFromRecruiter == true)
            {
                DataTable resultantDataTable = new DataTable();
                string uniqueCode = Session["UniqueCodeFromRecruiterProfile"].ToString();
                resultantDataTable = showPostingsPLObject.GetJobPostingDetails(uniqueCode);

                showPostingsGridView.DataSource = resultantDataTable;
                showPostingsGridView.DataBind();
            }
            else if (!IsPostBack && showPostingsFlagFromJobPost == true)
            {
                DataTable resultantDataTable = new DataTable();
                string uniqueCode = Session["UniqueCodeFromJobPost"].ToString();
                resultantDataTable = showPostingsPLObject.GetJobPostingDetails(uniqueCode);

                showPostingsGridView.DataSource = resultantDataTable;
                showPostingsGridView.DataBind();
            }
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            string postId = string.Empty;
            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            postId = showPostingsGridView.Rows[rowIndex].Cells[1].Text;

            Session["PostingId"] = postId;
            Session["ToJobPostPageFromShowPostings"] = true;
            Server.Transfer("~/JobPostPage.aspx");
        }

        protected void showApplicantsDetailsButton_Click(object sender, EventArgs e)
        {
            long loginId = long.Parse((Session["LoginId"]).ToString());
        
            Session["LoginId"] = loginId;
            Server.Transfer("~/ShowApplicantsDetailsPL.aspx");
        }

        protected void logoutLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Server.Transfer("Login.aspx");
        }
    }
}