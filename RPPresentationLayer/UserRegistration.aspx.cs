using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPBusinessObject;
using RPBusinessLogicLayer;
using System.Windows.Forms;

namespace RPPresentationLayer
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            UserDetailsBO userDetailsBOObj = new UserDetailsBO();
            userDetailsBOObj.UserID = userIdTextBox.Text;
            userDetailsBOObj.UserName = userNameTextBox.Text;
            userDetailsBOObj.Password = passwordTextBox.Text;
            userDetailsBOObj.Role = roleDropDownLis.SelectedItem.Value;

            Session["userName"] = userDetailsBOObj.UserName;

            UserRegistrationBLL accountCreate = new UserRegistrationBLL();
            int queryStatus = accountCreate.InsertUserDetails(userDetailsBOObj);
            if (queryStatus < 0)
            {
                //esponse.Write("<script>alert('Your account has been created successfully!.');</script>");
                DialogResult result1 = MessageBox.Show("Created Successfully", "Important Info", MessageBoxButtons.OK);


                // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Created Successfully');", true);
                if (result1 == DialogResult.OK)
                {

                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' account not created ')", true);
            }
        }
    }
}