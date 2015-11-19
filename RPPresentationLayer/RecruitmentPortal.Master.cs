using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RPPresentationLayer
{
    public partial class RecruitmentPortal : System.Web.UI.MasterPage
    {
        //public string userId
        //{
        //    get
        //    {
        //        return userIdLabel.Text;
        //    }
        //    set
        //    {
        //        userIdLabel.Text = value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginStatus2_LoggingOut(object sender, LoginCancelEventArgs e)
        {

        }
        protected void LogoutAnchor(object sender, EventArgs e)
        {
            Server.Transfer("~/Login.aspx");
        }
    }
}