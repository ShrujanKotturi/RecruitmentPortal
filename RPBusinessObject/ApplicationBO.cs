using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPBusinessObject
{
    public class ApplicationBO
    {
        public long LoginId { set; get; }
        public int PostId { get; set; }
        public string UniqueCode { get; set; }
        public char InterviewStatus { get; set; }
        public DateTime InterviewDatetime { get; set; }
        public string Comments { get; set; }
        public char IsAdminApproved { get; set; }
    }
}
