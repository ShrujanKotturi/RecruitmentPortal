using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using RPBusinessLogicLayer;
using System.Data;
using RPBusinessObject;

namespace RPPresentationLayer
{

    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            long loginId = 0;
            UserRegistrationBLL userValidate = new UserRegistrationBLL();
            UserDetailsBO user = new UserDetailsBO();
            user.UserID = userNameTextBox.Text;
            user.Password = passwordTextBox.Text;

            Session["userId"] = user.UserID;
         //   this.Master.userId = Session["userId"].ToString();
            DataTable resultTable = userValidate.ValidateUserCredintials(user);
            Object rowValue = resultTable.Rows[0]["result"];
            string validationResult = rowValue.ToString();

            if (validationResult.Equals("true"))
            {
                Object rowValue2 = resultTable.Rows[0]["role"];
                string role = rowValue2.ToString();

                Object loginInfo = resultTable.Rows[0]["Loginid"];
                loginId = Convert.ToInt64(loginInfo);

                //Session["LoginId"] = loginId;
                if (role.Equals("Admin"))
                {
                    loginId = Convert.ToInt64(loginInfo);
                    Session["LoginId"] = loginId;
                    Response.Redirect("~/JobPostingApprovalByAdmin.aspx");
                }

                #region //resultTable = userValidate.ValidateUserCredintials(user);
                //rowValue = resultTable.Rows[0]["result"];
                //validationResult = rowValue.ToString();
                //if (validationResult.Equals("true"))
                //{
                //    Object rowValue2 = resultTable.Rows[0]["role"];
                //    string role = rowValue2.ToString();

                //    Object loginInfo = resultTable.Rows[0]["Loginid"];
                //    loginId = Convert.ToInt64(loginInfo);

                //    Session["LoginId"] = loginId;
                #endregion


                else if (role.Equals("Recruiter"))
                {
                    loginId = Convert.ToInt64(loginInfo);
                    Session["LoginId"] = loginId;
                    Server.Transfer("RecruiterProfile.aspx");
                }
                else if (role.Equals("JobSeeker"))
                {
                    loginId = Convert.ToInt64(loginInfo);
                    Session["LoginId"] = loginId;
                    Server.Transfer("JobSeekerHomePage.aspx");
                }


            }
            else if (validationResult.Equals("false"))
            {
                Server.Transfer("ErrorPage.aspx");
            }

        }
    }
}