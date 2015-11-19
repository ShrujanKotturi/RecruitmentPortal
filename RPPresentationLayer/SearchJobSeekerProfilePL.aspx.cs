using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using RPBusinessObject;
using RPBusinessLogicLayer;


namespace RPPresentationLayer
{
    public partial class SearchJobSeekerProfilePL : System.Web.UI.Page
    {
        SearchJobSeekerProfileBLL searchJobSeekerObject = new SearchJobSeekerProfileBLL();
        DataTable table;
        JobPostsBO jobpostbo = new JobPostsBO();
        DatabaseObject databaseObject = new DatabaseObject();

        public int PagingIndexFlag = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout";

            int loginId = Convert.ToInt32(Session["LoginId"]);

            //loginId = 2;

            DataTable tableForRecruiterName = new DataTable();
            tableForRecruiterName = searchJobSeekerObject.GetRecruiterUserName(loginId);

           // userNameLabel.Text = tableForRecruiterName.Rows[0]["RecruiterName"].ToString();
            if (!IsPostBack)
            {
               // loginId = 2;
                
                table = new DataTable();

                table=searchJobSeekerObject.BindPostDetails(loginId);
                if (table.Rows.Count > 0)
                {
                    postDetailsDropDownList.Items.Add("----Select----");
                    foreach (DataRow row in table.Rows)
                    {
                        postDetailsDropDownList.Items.Add(row[2].ToString());
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No data Found')", true);
                }
            }
        }

        protected void postDetailsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (postDetailsDropDownList.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Select some value')", true);
            }
            else
            {
                table = new DataTable();
                string postDetails = postDetailsDropDownList.SelectedItem.Value;
                //int postId = Convert.ToInt32(postDetailsDropDownList.SelectedItem.Value);
                string[] postDetailsArray = postDetails.Split('-');

                int postId = int.Parse(postDetailsArray[0].ToString());
                //jobpostbo.PositionName = postDetailsArray[1].Trim().ToString();

                table = searchJobSeekerObject.SearchJobSeekerProfileUsingPostDetails(postId);
                databaseObject.DBDataTable = table;
                jobSeekerProfileInfoGridView.DataSource = table;
                jobSeekerProfileInfoGridView.DataBind();

                PagingIndexFlag = 1;
            }
        }

        public void BindGridData()
        {
            table = new DataTable();
            string postDetails = postDetailsDropDownList.SelectedItem.Value;
            //int postId = Convert.ToInt32(postDetailsDropDownList.SelectedItem.Value);
            string[] postDetailsArray = postDetails.Split('-');

            int postId = int.Parse(postDetailsArray[0].ToString());
            //jobpostbo.PositionName = postDetailsArray[1].Trim().ToString();

            table = searchJobSeekerObject.SearchJobSeekerProfileUsingPostDetails(postId);
            databaseObject.DBDataTable = table;
            jobSeekerProfileInfoGridView.DataSource = table;
            jobSeekerProfileInfoGridView.DataBind();
        }
        protected void jobSeekerProfileInfoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGridData();
            if (PagingIndexFlag == 1)
            {
                jobSeekerProfileInfoGridView.PageIndex = 0;
            }
            else
            {
                jobSeekerProfileInfoGridView.PageIndex = e.NewPageIndex;
                PagingIndexFlag = 0;
            }
                //jobSeekerProfileInfoGridView.DataSource = databaseObject.DBDataTable;
            jobSeekerProfileInfoGridView.DataBind();
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Server.Transfer("Login.aspx");
        }

        protected void logoutLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Server.Transfer("Login.aspx");
        }
    }
}