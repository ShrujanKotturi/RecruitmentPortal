using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

using System.Data;
using System.Data.SqlClient;

using RPBusinessObject;
using RPBusinessLogicLayer;


namespace RPPresentationLayer
{
    public partial class JobPostingApprovalByAdmin : System.Web.UI.Page
    {

        RecruiterProfileBO ObjRecruiterProfileBO = new RecruiterProfileBO();

        JobPostsBO ObjJobPostsBO = new JobPostsBO();

        ApplicationBO ObjApplicationBO = new ApplicationBO();

        JobPostingApprovalBLL ObjJobPostingApprovalBLL = new JobPostingApprovalBLL();

        InterviewApprovalBLL ObjInterviewApprovalBLL = new InterviewApprovalBLL();

        DataTable ObjDataTable = new DataTable();



        protected void Page_Load(object sender, EventArgs e)
        {
            logoutLoginStatus.LogoutText = "Logout";
            logoutLoginStatus.LoginText = "Logout";

            #region "Post Approval"
            if (!IsPostBack)
            {
                ObjDataTable.Clear();

                ObjDataTable = ObjJobPostingApprovalBLL.LoadPendingPosts();

                if (ObjDataTable.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No records found!')", true);
                    DetailsGridView.Visible = false;
                    SaveButton.Visible = false;
                }
                else
                {
                    DetailsGridView.Visible = true;
                    SaveButton.Visible = true;
                    DetailsGridView.DataSource = ObjDataTable;
                    DetailsGridView.DataBind();
                }
            }
            else
                ObjDataTable.Clear();
            #endregion

            #region "Interview Details"
            if (!IsPostBack)
            {
                ObjDataTable.Clear();

                ObjDataTable = ObjInterviewApprovalBLL.LoadIVDetails();

                //DetailsGridView.Visible = true;

                if (ObjDataTable.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No records found!')", true);
                    DetailsGridView2.Visible = false;
                    SaveIVDetailsButton.Visible = false;
                }
                else
                {
                    DetailsGridView2.Visible = true;
                    SaveIVDetailsButton.Visible = true;
                    DetailsGridView2.DataSource = ObjDataTable;
                    DetailsGridView2.DataBind();
                }
            }
            #endregion
        }

        protected void AllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AllRadioButton.Checked == true)
            {
                Panel2.Visible = false;

                ObjDataTable.Clear();

                ObjDataTable = ObjJobPostingApprovalBLL.ViewAllPosts();

                if (ObjDataTable.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No records found!')", true);
                    DetailsGridView.Visible = false;
                    SaveButton.Visible = false;
                }
                else
                {
                    DetailsGridView.Visible = true;
                    SaveButton.Visible = true;
                    DetailsGridView.DataSource = ObjDataTable;
                    DetailsGridView.DataBind();
                }

            }
        }

        protected void RecruiterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecruiterRadioButton.Checked == true)
            {
                Panel2.Visible = true;
                SelectStatusLabel.Visible = false;
                ViewByStatusDropDownList.Visible = false;

                EnterCompanyNameLabel.Visible = true;
                ViewByCompanyNameTextBox.Visible = true;
                ViewByCompanyNameButton.Visible = true;

            } 
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (StatusRadioButton.Checked == true)
            {

                Panel2.Visible = true;
                SelectStatusLabel.Visible = true;
                ViewByStatusDropDownList.Visible = true;

                EnterCompanyNameLabel.Visible = false;
                ViewByCompanyNameTextBox.Visible = false;
                ViewByCompanyNameButton.Visible = false;

            }
        }

        protected void ViewByCompanyNameButton_Click1(object sender, EventArgs e)
        {
            if (ViewByCompanyNameTextBox.Text.Trim() != String.Empty)
            {
                ObjRecruiterProfileBO.CompanyName = ViewByCompanyNameTextBox.Text;


                ObjDataTable.Clear();

                ObjDataTable = ObjJobPostingApprovalBLL.ViewPostsByCompanyName(ObjRecruiterProfileBO);


                if (ObjDataTable.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No records found!')", true);
                    DetailsGridView.Visible = false;
                    SaveButton.Visible = false;
                }
                else
                {
                    DetailsGridView.Visible = true;
                    SaveButton.Visible = true;
                    DetailsGridView.DataSource = ObjDataTable;
                    DetailsGridView.DataBind();
                }
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Enter Company Name!')", true);
        }

        protected void ViewByStatusDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewByStatusDropDownList.SelectedItem.Text.Equals("Approved"))
            {
                ObjJobPostsBO.PostingStatus = "Approved";
            }
            else if (ViewByStatusDropDownList.SelectedItem.Text.Equals("Rejected"))
            {
                ObjJobPostsBO.PostingStatus = "Rejected";
            }
            else if (ViewByStatusDropDownList.SelectedItem.Text.Equals("Closed"))
            {
                ObjJobPostsBO.PostingStatus = "Closed";
            }
            else
                ObjJobPostsBO.PostingStatus = "";
            ObjDataTable.Clear();

            ObjDataTable = ObjJobPostingApprovalBLL.ViewPostsByStatus(ObjJobPostsBO);


            if (ObjDataTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No records found!')", true);
                DetailsGridView.Visible = false;
                SaveButton.Visible = false;
            }
            else
            {
                DetailsGridView.Visible = true;
                SaveButton.Visible = true;
                DetailsGridView.DataSource = ObjDataTable;
                DetailsGridView.DataBind();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string UniqueCode = String.Empty;

            string Action = String.Empty;

            int PostId = 0;

            RadioButton Approve;
            RadioButton Reject;
            RadioButton Close;

            int f = 0, rows = 0;

            foreach (GridViewRow item in DetailsGridView.Rows)
            {
                f = 0;
                #region "GetInputs"
                Approve = item.Cells[0].FindControl("RadioButton1") as RadioButton;
                Reject = item.Cells[1].FindControl("RadioButton2") as RadioButton;
                Close = item.Cells[2].FindControl("RadioButton3") as RadioButton;
                
                if (Approve.Checked == true)
                {
                    Action = "Approved";
                    UniqueCode = item.Cells[3].Text;
                    PostId = int.Parse(item.Cells[5].Text);
                    f++;
                    Approve.Checked = false;
                }
                else if (Reject.Checked == true)
                {
                    Action = "Rejected";
                    UniqueCode = item.Cells[3].Text;
                    PostId = int.Parse(item.Cells[5].Text);
                    f++;
                    Reject.Checked = false;
                }
                else if (Close.Checked == true)
                {
                    Action = "Closed";
                    UniqueCode = item.Cells[3].Text;
                    PostId = int.Parse(item.Cells[5].Text);
                    f++;
                    Close.Checked = false;
                }
                #endregion

                if (UniqueCode != String.Empty && Action != String.Empty && PostId!=0)
                {
                    ObjJobPostsBO.PostingStatus = Action;

                    ObjJobPostsBO.UniqueCode = UniqueCode;

                    ObjJobPostsBO.PostId = PostId;

                    int result = ObjJobPostingApprovalBLL.UpdatePostStatus(ObjJobPostsBO);

                    if (result > 0)
                        f++;

                    UniqueCode = String.Empty;

                    Action = String.Empty;

                    PostId = 0;
                }
                if (f > 0)
                    rows++;
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + Action + "-" + UniqueCode + "')", true);
            }

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + rows + " rows updated successfully..!')", true);
        }

        /***********************************************************************************/

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            LinkButton1.BackColor = System.Drawing.Color.White;
            LinkButton2.BackColor = System.Drawing.Color.Gray;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            LinkButton1.BackColor = System.Drawing.Color.Gray;
            LinkButton2.BackColor = System.Drawing.Color.White;
        }

        /***********************************************************************************/
        
        //protected void CompanyNameRadioButton1_CheckedChanged(object sender, EventArgs e)
        //{
            
        //}

        //protected void IVDateRadioButton1_CheckedChanged(object sender, EventArgs e)
        //{
            
        //}

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Ch = DropDownList1.SelectedItem.Value;

            if (Ch.Equals("UniqueCode"))
            {
                ObjDataTable.Clear();
                ObjDataTable = ObjInterviewApprovalBLL.SortDetailsByUniqueCode();
            }
            else if (Ch.Equals("CompanyName"))
            {
                ObjDataTable.Clear();
                ObjDataTable = ObjInterviewApprovalBLL.SortDetailsByCompanyName();
            }
            else if (Ch.Equals("InterviewDate"))
            {
                ObjDataTable.Clear();
                ObjDataTable = ObjInterviewApprovalBLL.SortDetailsByInterviewDate();
            }


            if (ObjDataTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No records found!')", true);
                DetailsGridView2.Visible = false;
                SaveIVDetailsButton.Visible = false;
            }
            else
            {
                DetailsGridView2.Visible = true;
                SaveIVDetailsButton.Visible = true;
                DetailsGridView2.DataSource = ObjDataTable;
                DetailsGridView2.DataBind();
            }
        }

        protected void ViewButton_Click(object sender, EventArgs e)
        {
            string ViewByCriteriya = String.Empty;
            if (CompanyNameRadioButton1.Checked == true)
            {
                if (ViewByCompanyNameTextBox2.Text != "")
                {
                    ObjRecruiterProfileBO.CompanyName = ViewByCompanyNameTextBox2.Text;

                    ObjDataTable.Clear();

                    ObjDataTable = ObjInterviewApprovalBLL.LoadIVDetailsByCompanyName(ObjRecruiterProfileBO);


                    if (ObjDataTable.Rows.Count == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No records found!')", true);
                        DetailsGridView2.Visible = false;
                        SaveIVDetailsButton.Visible = false;
                    }
                    else
                    {
                        DetailsGridView2.Visible = true;
                        SaveIVDetailsButton.Visible = true;
                        DetailsGridView2.DataSource = ObjDataTable;
                        DetailsGridView2.DataBind();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Enter Company Name!')");
            }
            else if (IVDateRadioButton1.Checked == true)
            {
                if (ViewByCompanyNameTextBox2.Text != "")
                {
                    DateTime dt1;

                    //bool b = DateTime.TryParseExact(ViewByCompanyNameTextBox2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt1);

                    bool b = DateTime.TryParseExact(ViewByCompanyNameTextBox2.Text, "MMM dd yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt1);

                    if (b == false)
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Enter Date in MMM dd yyyy format! eg: May 21 2014')", true);
                    else
                    {
                        ObjApplicationBO.InterviewDatetime = dt1;

                        ObjDataTable.Clear();

                        ObjDataTable = ObjInterviewApprovalBLL.LoadIVDetailsByInterViewDate(ObjApplicationBO);


                        if (ObjDataTable.Rows.Count == 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No records found!')", true);
                            DetailsGridView2.Visible = false;
                        }
                        else
                        {
                            DetailsGridView2.Visible = true;
                            DetailsGridView2.DataSource = ObjDataTable;
                            DetailsGridView2.DataBind();
                        }
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Enter Date in dd-MM-yyyy format!')", true);
            }
        }

        protected void SaveIVDetailsButton_Click(object sender, EventArgs e)
        {
            string UniqueCode = String.Empty;

            int PostId = 0;

            long LoginId = 0;

            RadioButton Approve;
            int RowsUpdated = 0, f = 0;

            foreach (GridViewRow item in DetailsGridView2.Rows)
            {
                #region "Get Inputs"
                Approve = item.Cells[0].FindControl("ApproveRadioButton1") as RadioButton;
                #endregion

                if (Approve.Checked == true)
                {
                    try
                    {
                        UniqueCode = item.Cells[1].Text;
                        PostId = int.Parse(item.Cells[3].Text);
                        LoginId = long.Parse(item.Cells[6].Text);

                        ObjApplicationBO.UniqueCode = UniqueCode;
                        ObjApplicationBO.PostId = PostId;
                        ObjApplicationBO.LoginId = LoginId;

                        int result = ObjInterviewApprovalBLL.UpdateIVDetails(ObjApplicationBO);

                        if (result > 0)
                            f++;
                    }
                    catch (Exception excp)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No row selected.!')", true);
                    }

                    if (f > 0)
                        RowsUpdated++;
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + RowsUpdated + " rows updated successfully..!')", true);
        }

        protected void CompanyNameRadioButton1_CheckedChanged1(object sender, EventArgs e)
        {
            if (CompanyNameRadioButton1.Checked == true)
            {
                LoadPanel.Visible = true;
            }
        }

        protected void IVDateRadioButton1_CheckedChanged1(object sender, EventArgs e)
        {
            if (IVDateRadioButton1.Checked == true)
            {
                LoadPanel.Visible = true;
            }
        }

        protected void logoutLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Server.Transfer("Login.aspx");
        }

        /***********************************************************************************/


    }
}