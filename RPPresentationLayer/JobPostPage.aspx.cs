namespace RPPresentationLayer
{
    using System;
    using System.Globalization;
    using System.Web.UI.WebControls;
    using RPBusinessLogicLayer;
    using RPBusinessObject;

    public partial class JobPostPage : System.Web.UI.Page
    {
        JobPostsBLL jobPostBLLObject = new JobPostsBLL();
        JobPostsBO jobPostBOObject = new JobPostsBO();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout";        

            bool jobPostFlagFromRecruiterProfile = false;
            jobPostFlagFromRecruiterProfile = Convert.ToBoolean(Session["ToJobPostPageFlagFromRecruiterProfile"]);

            bool jobPostFlagFromShowPostings = false;
            jobPostFlagFromShowPostings = Convert.ToBoolean(Session["ToJobPostPageFromShowPostings"]);

            NewMethod(jobPostFlagFromRecruiterProfile, jobPostFlagFromShowPostings);

        }

        private void NewMethod(bool jobPostFlagFromRecruiterProfile, bool jobPostFlagFromShowPostings)
        {
            if (!IsPostBack && jobPostFlagFromRecruiterProfile == true)
            {
                int postId = 0;
                string uniqueCode = string.Empty;
                uniqueCode = Session["UniqueCodeFromRecruiterProfile"].ToString();

                companyNameTextBox.Text = jobPostBLLObject.GetCompanyName(uniqueCode);
                uniqueCodeTextBox.Text = uniqueCode;


                postId = jobPostBLLObject.GetPostId();
                postingIdTextBox.Text = postId.ToString();
                Session["ToJobPostPageFlagFromRecruiterProfile"] = false;
            }
            else if (!IsPostBack && jobPostFlagFromShowPostings == true)
            {
                int postId = 0;
                postId = int.Parse(Session["PostingId"].ToString());
                companyNameTextBox.Text = jobPostBLLObject.GetCompanyNameBasedOnPostId(postId);
                uniqueCodeTextBox.Text = jobPostBLLObject.GetUniqueCodeBasedOnPostId(postId);

                string uniqueCode = Session["UniqueCodeFromRecruiterProfile"].ToString();
                postingIdTextBox.Text = postId.ToString();

                jobPostButton.Enabled = false;
                jobPostButton.Visible = false;

                updateButton.Enabled = true;
                updateButton.Visible = true;
            }
        }

        protected void jobPostButton_Click(object sender, EventArgs e)
        {
            int queryStatus = 0;
            bool offerCloseDateFlag = false, expectedDateOfJoiningFlag = false;
            string postingStatus = string.Empty;


            DateTime postingDate = DateTime.Now;

            DateTime offerCloseDate, expectedJoiningDate;

            if (DateTime.TryParseExact(offerCloseDateTextBox.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out offerCloseDate))
            {
                if (offerCloseDate.Subtract(postingDate).TotalDays > 0)
                {
                    jobPostBOObject.CloseDate = offerCloseDate;
                }
                else
                {
                    offerCloseDateFlag = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Offer already Closed')", true);
                }
            }
            if (DateTime.TryParseExact(expectedJoiningDateTextBox.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out expectedJoiningDate))
            {
                if (offerCloseDateFlag == false)
                {
                    if ((expectedJoiningDate.Subtract(postingDate).TotalDays > 0) && (expectedJoiningDate.Subtract(postingDate).TotalDays > 0))
                    {
                        jobPostBOObject.JoiningDate = expectedJoiningDate;
                    }
                    else
                    {
                        expectedDateOfJoiningFlag = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Enter a valid Joining Date')", true);
                    }
                }
            }
            if (offerCloseDateFlag == false && expectedDateOfJoiningFlag == false)
            {
                jobPostBOObject.UniqueCode = uniqueCodeTextBox.Text;
                jobPostBOObject.PostId = int.Parse(postingIdTextBox.Text);
                jobPostBOObject.PositionName = positionNameTextBox.Text;
                jobPostBOObject.NumberOfOpenings = numberOfOpeningsTextBox.Text;
                jobPostBOObject.LocationOfTheOpenings = locationOfOpeningsTextBox.Text;
                jobPostBOObject.ExperienceRequired = int.Parse(experienceRequiredTextBox.Text);
                jobPostBOObject.SkillSet = skillSetTextBox.Text;
                jobPostBOObject.TentativeSalary = double.Parse(tentativeSalaryTextBox.Text);

                postingStatus = jobPostBLLObject.GetPostingStatus(int.Parse(postingIdTextBox.Text));

                if (postingStatus.Equals("Reject"))
                {
                    jobPostBOObject.PostingStatus = "Renew";
                }
                else if (postingStatus.Equals("New"))
                {
                    jobPostBOObject.PostingStatus = "New";
                }
                else if (postingStatus.Equals("Approved"))
                {
                    jobPostBOObject.PostingStatus = "Renew";
                }
                else
                {
                    jobPostBOObject.PostingStatus = "New";
                }

                queryStatus = jobPostBLLObject.InsertJobPostDetails(jobPostBOObject);

                if (queryStatus > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Job Posted Successfully')", true);

                    showPostingsButton.Enabled = true;
                    showPostingsButton.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Contact Administrator for further assistance')", true);
                }
            }

        }

        protected void showPostingsButton_Click(object sender, EventArgs e)
        {
           
            Session["UniqueCodeFromJobPost"] = uniqueCodeTextBox.Text;
            Session["ToShowPostingsPageFlagFromJobPost"] = true;
            Response.Redirect("~/ShowPostings.aspx");
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            int queryStatus = 0;
            bool offerCloseDateFlag = false, expectedDateOfJoiningFlag = false;
            string postingStatus = string.Empty;


            DateTime postingDate = DateTime.Now;

            DateTime offerCloseDate, expectedJoiningDate;

            if (DateTime.TryParseExact(offerCloseDateTextBox.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out offerCloseDate))
            {
                if (offerCloseDate.Subtract(postingDate).TotalDays > 0)
                {
                    jobPostBOObject.CloseDate = offerCloseDate;
                }
                else
                {
                    offerCloseDateFlag = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Offer already Closed')", true);
                }
            }
            if (DateTime.TryParseExact(expectedJoiningDateTextBox.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out expectedJoiningDate))
            {
                if (offerCloseDateFlag == false)
                {
                    if ((expectedJoiningDate.Subtract(postingDate).TotalDays > 0) && (expectedJoiningDate.Subtract(postingDate).TotalDays > 0))
                    {
                        jobPostBOObject.JoiningDate = expectedJoiningDate;
                    }
                    else
                    {
                        expectedDateOfJoiningFlag = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Enter a valid Joining Date')", true);
                    }
                }
            }
            if (offerCloseDateFlag == false && expectedDateOfJoiningFlag == false)
            {
                jobPostBOObject.UniqueCode = uniqueCodeTextBox.Text;
                jobPostBOObject.PostId = int.Parse(postingIdTextBox.Text);
                jobPostBOObject.PositionName = positionNameTextBox.Text;
                jobPostBOObject.NumberOfOpenings = numberOfOpeningsTextBox.Text;
                jobPostBOObject.LocationOfTheOpenings = locationOfOpeningsTextBox.Text;
                jobPostBOObject.ExperienceRequired = int.Parse(experienceRequiredTextBox.Text);
                jobPostBOObject.SkillSet = skillSetTextBox.Text;
                jobPostBOObject.TentativeSalary = double.Parse(tentativeSalaryTextBox.Text);

                postingStatus = jobPostBLLObject.GetPostingStatus(int.Parse(postingIdTextBox.Text));

                if (postingStatus.Equals("Reject"))
                {
                    jobPostBOObject.PostingStatus = "Renew";
                }
                else if (postingStatus.Equals("New"))
                {
                    jobPostBOObject.PostingStatus = "New";
                }
                else if (postingStatus.Equals("Approved"))
                {
                    jobPostBOObject.PostingStatus = "Renew";
                }
                else
                {
                    jobPostBOObject.PostingStatus = "New";
                }

                queryStatus = jobPostBLLObject.UpdateJobPostDetails(jobPostBOObject);

                if (queryStatus > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Job Posted Successfully')", true);

                    showApplicantsDetailsButton.Enabled = true;
                    showApplicantsDetailsButton.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ALERT", "alert('Contact Administrator for further assistance')", true);
                }


                showPostingsButton.Enabled = false;
                showPostingsButton.Visible = false;


            }
        }

        protected void showApplicantsDetailsButton_Click(object sender, EventArgs e)
        {
            long loginId = long.Parse((Session["LoginId"]).ToString());
            
            Session["LoginId"] = loginId;
            Session["ToShowPostingsPageFlagFromRecruiterProfile"] = true;
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