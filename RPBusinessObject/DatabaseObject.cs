using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace RPBusinessObject
{
    public class DatabaseObject
    {
        public SqlConnection DBConnection { get; set; }
        public SqlCommand DBCommand { get; set; }
        public SqlDataReader DBDataReader { get; set; }
        public SqlDataAdapter DBAdapter { get; set; }
        public DataTable DBDataTable { get; set; }
        public DataSet DBDataSet { get; set; }
        public SqlConnection DBConnection1 { get; set; }
        public DatabaseObject()
        {
            DBConnection = new SqlConnection(@"Data Source =pc182680;" +
                                             @"Initial Catalog = RecruitmentPortalDB;" +
                                             @"Integrated Security = true;");

            DBConnection1 = new SqlConnection(@"Data Source=PC182680;"
                      + "Initial Catalog=RecruitmentPortalDB;"
                      + "Integrated Security=true;");

            //DBCommand = new SqlCommand();

            //DBDataTable = new DataTable();
        }

    }
}
