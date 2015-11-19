using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace RPPresentationLayer
{
    public partial class JobSeekerDetails : System.Web.UI.Page
    {
        ShowApplicantsDetailsPL ApplicantsDetails = new ShowApplicantsDetailsPL();

        DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            //string candidateName="Avadhoot";
            string candidateName = Request.QueryString[0];
            showDetailsDetailsView.DataSource = ApplicantsDetails.JobSeekerDetails(candidateName);
            showDetailsDetailsView.DataBind();
        }
    }
}