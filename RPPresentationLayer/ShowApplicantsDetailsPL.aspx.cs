using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using RPBusinessObject;
using RPBusinessLogicLayer;
using System.Globalization;

namespace RPPresentationLayer
{
    public partial class ShowApplicantsDetailsPL : System.Web.UI.Page
    {
        RecruiterProfileBO recruiterObject = new RecruiterProfileBO();
        InterviewSchedulingBLL interviewSchedulingObject = new InterviewSchedulingBLL();
        DatabaseObject databaseObject = new DatabaseObject();
        ApplicationBO application = new ApplicationBO();
        JobSeekerProfileBO jobSeeker = new JobSeekerProfileBO();


       public DataTable table;
        int dateFlag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout";
            int loginId = Convert.ToInt32(Session["LoginId"]);

            //loginId = 2;

            table = new DataTable();
            table = interviewSchedulingObject.GetRecruiterUserName(loginId);

            //userNameLabel.Text = table.Rows[0]["RecruiterName"].ToString();

            if(applicantsDetailsGridView.Rows.Count==0)
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No Data Found')", true);

            //foreach (DataRow row in table.Rows)
            //{
            //    userNameLabel.Text = table.Rows[0].ToString();
            //}


            //if (!IsPostBack)
            //{
            //    recruiterObject.LoginId = 2;
            //    table = new DataTable();

            //    table = interviewSchedulingObject.ShowApplicantsDetails(recruiterObject.LoginId);
            //    databaseObject.DBDataTable = table;
            //    applicantsDetailsGridView.DataSource = table;
            //    applicantsDetailsGridView.DataBind();
            //}
            //InterviewStatusCheckBox_CheckedChanged(new Object(), new EventArgs());

        }

        /// <summary>
        /// 
        /// </summary>
        public void functionName()
        {
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
        }


        protected void updateButton_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (dateFlag == 0)
            {
                for (int i = 0; i < applicantsDetailsGridView.Rows.Count; i++)
                {

                    CheckBox chbx = applicantsDetailsGridView.Rows[i].Cells[4].FindControl("interviewStatusCheckBox") as CheckBox;
                    TextBox textBox = applicantsDetailsGridView.Rows[i].Cells[5].FindControl("interviewDatetimeTextBox") as TextBox;

                    if (textBox.Text != string.Empty)
                    {
                        jobSeeker.CandidateName = (applicantsDetailsGridView.Rows[i].Cells[0].FindControl("CandidateNameHyperLink") as HyperLink).Text;
                        application.PostId = int.Parse(applicantsDetailsGridView.Rows[i].Cells[3].Text);
                        application.InterviewStatus = 'S';

                        DateTime dateTime1;
                        if (DateTime.TryParseExact(textBox.Text, "dd MMM yyyy HH:mm:ss", CultureInfo.InstalledUICulture, DateTimeStyles.None, out dateTime1))
                        {
                            if (!(dateTime1 > DateTime.Now))
                            {
                                dateFlag=1;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Entered future date and time')", true);
                                break;
                            }
                            application.InterviewDatetime = dateTime1;
                        }

                        int result = interviewSchedulingObject.UpdateApplication(jobSeeker.CandidateName, application.PostId, application.InterviewStatus, application.InterviewDatetime);
                        if (result == 1)
                        {
                            continue;
                        }
                        else if (result == 2)
                        {
                            flag = 1;
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Contact Administrator for further assistance’')", true);
                            break;
                        }
                        else
                        {
                            flag = 1;
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Contact Administrator for further assistance’')", true);
                            break;
                        }
                    }
                    else
                    {
                        jobSeeker.CandidateName = (applicantsDetailsGridView.Rows[i].Cells[0].FindControl("CandidateNameHyperLink") as HyperLink).Text;
                        application.PostId = int.Parse(applicantsDetailsGridView.Rows[i].Cells[3].Text);
                        application.InterviewStatus = 'N';

                        int result = interviewSchedulingObject.UpdateUnscheduledApplication(jobSeeker.CandidateName, application.PostId, application.InterviewStatus);
                        if (result == 1)
                        {
                            continue;
                        }
                        else if (result == 2)
                        {
                            flag = 1;
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Contact Administrator for further assistance’')", true);
                            break;
                        }
                        else
                        {
                            flag = 1;
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Contact Administrator for further assistance’')", true);
                            break;
                        }
                    }
                }

                if (flag == 0 && dateFlag==0)
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Successful')", true);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Entered Date is Less than the today's date')", true);
        }

        protected void HyperLink1_Click(object sender, EventArgs e)
        {

        }

        public DataTable JobSeekerDetails(string candidateName)
        {
            return interviewSchedulingObject.JobSeekerDetails(candidateName);
            //candidateDetailsGridView.DataBind();
        }

        protected void applicantsDetailsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

   

        protected void InterviewStatusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < applicantsDetailsGridView.Rows.Count; i++)
            {
                //Response.Write("In method");
                CheckBox chbx = applicantsDetailsGridView.Rows[i].Cells[4].FindControl("InterviewStatusCheckBox") as CheckBox;
                TextBox textBox = applicantsDetailsGridView.Rows[i].Cells[5].FindControl("interviewDatetimeTextBox") as TextBox;

                if (chbx != null && chbx.Checked)
                {
                    textBox.ReadOnly = false;
                }
                else
                    textBox.ReadOnly = true;
            }
        }

        protected void applicantsDetailsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void applicantsDetailsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void applicantsDetailsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void JobSeekerDetails_Clicked(object sender, EventArgs e)
        {
            Response.Write("In method");
        }

        protected void interviewDatetimeTextBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < applicantsDetailsGridView.Rows.Count; i++)
            {
                TextBox textBox = applicantsDetailsGridView.Rows[i].Cells[5].FindControl("interviewDatetimeTextBox") as TextBox;
                DateTime dateTime1;
                if (DateTime.TryParseExact(textBox.Text, "dd MMM yyyy HH:mm:ss", CultureInfo.InstalledUICulture, DateTimeStyles.None, out dateTime1))
                {
                    if (!(dateTime1 > DateTime.Now))
                    {
                        dateFlag = 1;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Proper Date')", true);
                        break;
                    }
                    //else
                    //    dateFlag = 0;
                }
            }
        }

        protected void findMoreProfileButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("SearchJobSeekerProfilePL.aspx");
        }

        protected void applicantsDetailsGridView_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void applicantsDetailsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            applicantsDetailsGridView.PageIndex = e.NewPageIndex;
            applicantsDetailsGridView.DataBind();
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

        protected void Button_click_event(object sender, EventArgs e)
        {
            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string candidateName = (applicantsDetailsGridView.Rows[rowIndex].Cells[0].FindControl("CandidateNameHyperLink") as HyperLink).Text;

            table = new DataTable();

            table = interviewSchedulingObject.GetResumePathOfCandidate(candidateName);

            //string resumeFileName = table.Rows[0];
            string resumeFileName = string.Empty;
            string resumeFilePath = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                resumeFileName = row[0].ToString();
                resumeFilePath = row[1].ToString();
                if (resumeFilePath.Contains('\\'))
                    resumeFilePath.Replace('\\', '/');
            }

            if (resumeFileName != string.Empty && resumeFilePath != string.Empty)
            {
                string filePath = resumeFilePath + "/" + resumeFileName;

                Response.Redirect("ResumePopup.aspx?resumeFilePath=" + filePath);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Resume Not found')", true);
            }
        }
    }
}