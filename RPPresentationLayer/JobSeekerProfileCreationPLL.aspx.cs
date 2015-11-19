using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using RPBusinessLogicLayer;
using RPBusinessObject;

namespace RPPresentationLayer
{
    public partial class JobSeekerProfileCreationPLL : System.Web.UI.Page
    {
        long LoginId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout";
            userNameLabel.Text = "Welcome " + Session["userName"] + "";
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                JobSeekerProfileBO jobSeeker = new JobSeekerProfileBO();
                jobSeeker.LoginId = (long)(Session["loginId"]);
                jobSeeker.CandidateName = candidateNameTextBox.Text;
                jobSeeker.YearsOfExperience = Convert.ToInt32(yearsOfExperienceTextBox.Text);
                jobSeeker.SkillSet = skillSetTextBox.Text;
                jobSeeker.Address = addressTextBox4.Text;
                jobSeeker.EmailId = emailIdTextBox.Text;
                jobSeeker.Phone = phoneNumberTextBox.Text;
                jobSeeker.Industry = industryTextBox.Text;
                jobSeeker.CurrentPosition = currentPositionTextBox.Text;
                jobSeeker.CurrentSalary = Math.Round(Convert.ToDouble(currentSalaryTextBox.Text));
                jobSeeker.ExpectedPosition = expectedPositionTextBox.Text;
                jobSeeker.ExpectedJobLocation = expectedJobLocationTextBox.Text;
                var allowedExtensions = new string[] { "doc", "docx", "pdf" };
                var extension = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower().Replace(".", "");
                if (allowedExtensions.Contains(extension))
                {
                    jobSeeker.ResumeFileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    const string path = @"D:\406440\MFRP Change Request\RecruitmentSolutionChangeRequest\uploads\";
                    FileUpload1.SaveAs(path + jobSeeker.ResumeFileName);
                    jobSeeker.ResumeFilePath = path + jobSeeker.ResumeFilePath;



                    JobSeekerProfileBLL jobSeekerProfile = new JobSeekerProfileBLL();

                    int queryStatus = jobSeekerProfile.InsertJobSeekerProfile(jobSeeker);


                    if (queryStatus < 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' details uploaded succesfully ')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' details not uploaded ')", true);
                        //messageLabel.Text = "failure";
                        //messageLabel.Visible = false;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' upload only DOC or Docx file')", true);
                }
            }
            catch (SqlException)
            {
            }


        }

        protected void LoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {

        }

        protected void jobSearchAndApply(object sender, EventArgs e)
        {
            LoginId = (long)(Session["LoginId"]);
            Session["LoginId"] = LoginId;
            Server.Transfer("~/JobSearchAndApplyPL.aspx");
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            candidateNameTextBox.Text = string.Empty;
            yearsOfExperienceTextBox.Text = string.Empty;
            skillSetTextBox.Text = string.Empty;
            addressTextBox4.Text = string.Empty;
            emailIdTextBox.Text = string.Empty;
            phoneNumberTextBox.Text = string.Empty;
            industryTextBox.Text = string.Empty;
            currentPositionTextBox.Text = string.Empty;
            currentSalaryTextBox.Text = string.Empty;
            expectedJobLocationTextBox.Text = string.Empty;
        }

        protected void logoutLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Server.Transfer("Login.aspx");
        }
    }
}