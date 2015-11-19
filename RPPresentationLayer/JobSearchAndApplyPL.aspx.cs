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
    public partial class JobSearchAndApplyPL : System.Web.UI.Page
    {
        JobSearchAndApplyBLL jsab = new JobSearchAndApplyBLL();
        long loginId;

        protected void Page_Load(object sender, EventArgs e)
        {
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout";        
            loginId = long.Parse(Session["LoginId"].ToString());
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            loginId = long.Parse(Session["LoginId"].ToString());
            string companyName = null;
            string positionName = null;
            string experienceRequired = null;
            string skillset = null;
            string location = null;
            if (CompanyNameTextBox.Text != string.Empty)
            {
                companyName = CompanyNameTextBox.Text;
            }
            if (PositionNameTextBox.Text != string.Empty)
            {
                positionName = PositionNameTextBox.Text;
            }
            if (ExperianceRequiredTextBox.Text != string.Empty)
            {
                experienceRequired = ExperianceRequiredTextBox.Text;
            }
            if (SkillSetTextBox.Text != string.Empty)
            {
                skillset = SkillSetTextBox.Text;
            }
            if (LocationOfOpeningTextBox.Text != string.Empty)
            {
                location = LocationOfOpeningTextBox.Text;
            }

            DataTable result1 = new DataTable();

            result1 = jsab.NotAppliedJobSearchMethod(companyName, positionName, experienceRequired, skillset, location,loginId);
            SearchResultGridView.DataSource = result1;
            SearchResultGridView.DataBind();

            DataTable result2 = new DataTable();

            result2 = jsab.AppliedJobSearchMethod(companyName, positionName, experienceRequired, skillset, location, loginId);
            AppliedJobSearchGridView.DataSource = result2;
            AppliedJobSearchGridView.DataBind();
            YouHaveAlreadyApplyedLabel.Visible = true;
            if (result2.Rows.Count == 0)
            {
                //NotAppliedLabel.Visible = true;
                YouHaveAlreadyApplyedLabel.Visible = false;
            }

        }

        protected void SearchResultGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int postid = 0;
            //postid = jsab.GetPostIdMethod(SearchResultGridView.Columns);
            loginId = long.Parse(Session["LoginId"].ToString());
            string UniqueCode = null;
            string LocationOfOpening = null;
            string Skillset = null;
            double TentativeSalary = 0;
            int ExperienceRequired = 0;
            string PositionName = null;
            string NumberOfOpening = null;
            DateTime CloseDate = new DateTime();

            //if (e.CommandName == "Select")
            //{

            int index = Convert.ToInt32(e.CommandArgument);


            GridViewRow selectedRow = SearchResultGridView.Rows[index];

            UniqueCode = selectedRow.Cells[2].Text;
            LocationOfOpening = selectedRow.Cells[3].Text;
            Skillset = selectedRow.Cells[4].Text;
            TentativeSalary = double.Parse(selectedRow.Cells[5].Text.ToString());
            ExperienceRequired = int.Parse(selectedRow.Cells[6].Text);
            PositionName = selectedRow.Cells[7].Text;
            NumberOfOpening = selectedRow.Cells[8].Text;
            CloseDate = DateTime.Parse(selectedRow.Cells[9].Text);

            //}
            postid = jsab.GetPostIdMethod(UniqueCode, LocationOfOpening, Skillset, TentativeSalary, ExperienceRequired, PositionName, NumberOfOpening, CloseDate);


            int RowCount = jsab.InsertIntoTblApplicationMethod(postid, UniqueCode, loginId);
            if (RowCount > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Applied successfully')", true);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Unsuccessful')", true);

        }

        protected void SearchResultGridView_DataBound(object sender, EventArgs e)
        {

        }

        protected void SearchResultGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void logoutLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Server.Transfer("Login.aspx");
        }
    }
}