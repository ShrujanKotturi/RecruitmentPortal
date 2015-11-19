using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPBusinessObject;
using RPBusinessLogicLayer;
using System.Data;

namespace RPPresentationLayer
{
    public partial class ApplicantDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable ObjDataTable = new DataTable();

            JobSeekerProfileBO ObjJobSeekerProfile = new JobSeekerProfileBO();

            InterviewApprovalBLL ObjInterviewApprovalBLL = new InterviewApprovalBLL();


            string str = Request.QueryString[0];

            ObjJobSeekerProfile.LoginId = int.Parse(Request.QueryString[0].ToString());

            ObjDataTable.Clear();

            ObjDataTable = ObjInterviewApprovalBLL.LoadApplicantDetails(ObjJobSeekerProfile);


            NewMethod(ObjDataTable);

        }
        private void NewMethod(DataTable ObjDataTable)
        {
            if (ObjDataTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No Details Found!')", true);

                candidateNameTextBox.Text = "";
                yearsOfExperienceTextBox.Text = "";
                skillSetTextBox.Text = "";
                addressTextBox4.Text = "";
                emailIdTextBox.Text = "";
                phoneNumberTextBox.Text = "";
                industryTextBox.Text = "";
                currentPositionTextBox.Text = "";
                currentSalaryTextBox.Text = "";
                expectedPositionTextBox.Text = "";
                expectedJobLocationTextBox.Text = "";



            }
            else
            {
                DataRow row = ObjDataTable.Rows[0];

                candidateNameTextBox.Text = row[1].ToString();
                yearsOfExperienceTextBox.Text = row[2].ToString();
                skillSetTextBox.Text = row[3].ToString();
                addressTextBox4.Text = row[4].ToString();
                emailIdTextBox.Text = row[5].ToString();
                phoneNumberTextBox.Text = row[6].ToString();
                industryTextBox.Text = row[7].ToString();
                currentPositionTextBox.Text = row[8].ToString();
                currentSalaryTextBox.Text = row[9].ToString();
                expectedPositionTextBox.Text = row[10].ToString();
                expectedJobLocationTextBox.Text = row[11].ToString();


            }
        }

    }
}