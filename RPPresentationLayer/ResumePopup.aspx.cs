using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.ClientServices;
using System.Net;

namespace RPPresentationLayer
{
    public partial class ResumePopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string filePath = Request.QueryString[0];

            Byte[] buffer = client.DownloadData(filePath);

            if (filePath.EndsWith(".doc") || filePath.EndsWith(".docx"))
            {
                Response.ContentType = "application/msword";
            }
            else if (filePath.EndsWith(".pdf"))
            {
                Response.ContentType = "application/pdf";
            }
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.BinaryWrite(buffer);
        }
    }
}