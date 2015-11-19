using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPBusinessObject;
using RPBusinessLogicLayer;
using System.Data;
using System.Windows.Forms;


namespace RPPresentationLayer
{
    public partial class RecruiterProfile : System.Web.UI.Page
    {
        RecruiterProfileBLL recruiterProfilePLObject = new RecruiterProfileBLL();
        RecruiterProfileBO recruiterProfileBOObject = new RecruiterProfileBO();
        string uniqueCodeExists;
        long LoginIdPass = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout"; 

            LoginIdPass = long.Parse(Session["LoginId"].ToString());
            loginIdTextBox.Text = LoginIdPass.ToString();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            string uniqueCode;
            int queryStatus = 0;


            recruiterProfileBOObject.CompanyName = companyNameTextBox.Text;
            recruiterProfileBOObject.RecruiterName = recruiterNameTextBox.Text;


            uniqueCodeExists = recruiterProfilePLObject.GetUniqueCodeIfExists(recruiterProfileBOObject);

            if (uniqueCodeExists.Equals(string.Empty))
            {
                uniqueCode = recruiterProfilePLObject.GenerateUniqueCode(companyNameTextBox.Text);
                uniqueCodeTextBox.Text = uniqueCode;

                codeLabel.Text = uniqueCode;

                recruiterProfileBOObject.LoginId = long.Parse(loginIdTextBox.Text);

                recruiterProfileBOObject.Address = addressTextBox.Text;
                recruiterProfileBOObject.EmailId = mailIdTextBox.Text;
                recruiterProfileBOObject.Phone = phoneTextBox.Text;
                recruiterProfileBOObject.UniqueCode = uniqueCodeTextBox.Text;

                queryStatus = recruiterProfilePLObject.InsertRecruitmentProfileDetails(recruiterProfileBOObject);

                if (queryStatus > 0)
                {
                    uniqueCodeLabel.Visible = true;
                    uniqueCodeTextBox.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Profile Details Inserted Successfully')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Contact Administrator for further assistance')", true);
                }

            }
            else
            {
                uniqueCodeLabel.Visible = true;
                uniqueCodeTextBox.Visible = true;

                uniqueCodeTextBox.Text = uniqueCodeExists;

                codeLabel.Text = uniqueCodeExists;

                addressEditButton.Enabled = true;
                addressEditButton.Visible = true;

                mailIdEditButton.Visible = true;
                mailIdEditButton.Enabled = true;

                phoneEditButton.Enabled = true;
                phoneEditButton.Visible = true;

            }

            showJobPostAnchorId.Visible = true;
            showPostingsAnchorId.Visible = true;
            GotoWebsiteAnchor.Visible = true;
        }

        protected void addressEditButton_Click(object sender, EventArgs e)
        {
            int queryStatus = 0;

            uniqueCodeTextBox.Visible = true;

            uniqueCodeTextBox.Text = codeLabel.Text;


            recruiterProfileBOObject.Address = addressTextBox.Text;
            recruiterProfileBOObject.UniqueCode = codeLabel.Text;


            queryStatus = recruiterProfilePLObject.UpdateRecruiterAddress(recruiterProfileBOObject);

            if (queryStatus > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Address Updated Successfully')", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Updated wasn't possible')", true);
            }
        }

        protected void mailIdEditButton_Click(object sender, EventArgs e)
        {
            int queryStatus = 0;

            uniqueCodeTextBox.Visible = true;

            uniqueCodeTextBox.Text = codeLabel.Text;

            recruiterProfileBOObject.EmailId = mailIdTextBox.Text;
            recruiterProfileBOObject.UniqueCode = codeLabel.Text;


            queryStatus = recruiterProfilePLObject.UpdateEmailId(recruiterProfileBOObject);

            if (queryStatus > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Mail Id Updated Successfully')", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Updated wasn't possible')", true);
            }
        }

        protected void phoneEditButton_Click(object sender, EventArgs e)
        {
            int queryStatus = 0;

            uniqueCodeTextBox.Visible = true;

            uniqueCodeTextBox.Text = codeLabel.Text;

            recruiterProfileBOObject.Phone = phoneTextBox.Text;
            recruiterProfileBOObject.UniqueCode = codeLabel.Text;

            queryStatus = recruiterProfilePLObject.UpdatePhoneNumber(recruiterProfileBOObject);

            if (queryStatus > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Phone Number Updated Successfully')", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Updated wasn't possible')", true);
            }


        }
        protected void showJobPostAnchor(object sender, EventArgs e)
        {
            uniqueCodeTextBox.Visible = true;
            uniqueCodeTextBox.Text = codeLabel.Text;

            Session["LoginId"] = LoginIdPass;
            Session["ToJobPostPageFlagFromRecruiterProfile"] = true;
            Session["UniqueCodeFromRecruiterProfile"] = codeLabel.Text;

            Server.Transfer("~/JobPostPage.aspx");
        }

        protected void showPostingsAnchor(object sender, EventArgs e)
        {
            uniqueCodeTextBox.Visible = true;
            uniqueCodeTextBox.Text = codeLabel.Text;

            Session["ToShowPostingsPageFlagFromRecruiterProfile"] = true;
            Session["LoginId"] = LoginIdPass;
            Session["UniqueCodeFromRecruiterProfile"] = codeLabel.Text;

            Server.Transfer("~/ShowPostings.aspx");
        }

        protected void logoutLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Server.Transfer("Login.aspx");
        }

    }
}