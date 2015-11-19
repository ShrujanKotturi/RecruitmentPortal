using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using System.Data;
using System.Data.SqlClient;

namespace RPDataAccessLayer
{
   public class JobPostingApprovalDAL
    {
        DatabaseObject ObjDatabaseObject = new DatabaseObject();

        RecruiterProfileBO ObjRecruiterProfileBO = new RecruiterProfileBO();

        JobPostsBO ObjJobPostsBO = new JobPostsBO();

        ApplicationBO ObjApplicationBO = new ApplicationBO();

        public DataTable LoadPendingPosts()
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();

            

            //ObjDatabaseObject.DBCommand = new SqlCommand(@"uspLoadPendingPosts", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspLoadPendingPosts", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;

        }

        public DataTable ViewAllPosts()
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();

            

            //ObjDatabaseObject.DBCommand = new SqlCommand(@"uspViewAllPosts", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspViewAllPosts", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;

        }

        public DataTable ViewPostsByCompanyName(RecruiterProfileBO ObjRecruiterProfileBO1)
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();

           

            //ObjDatabaseObject.DBCommand = new SqlCommand(@"uspViewPostsByCompanyName", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspViewPostsByCompanyName", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompanyName",ObjRecruiterProfileBO1.CompanyName));

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType= CommandType.StoredProcedure;

            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;

        }

        public DataTable ViewPostsByStatus(JobPostsBO ObjJobPostsBO1)
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();


            //ObjDatabaseObject.DBCommand = new SqlCommand(@"uspViewPostsByStatus", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspViewPostsByStatus", ObjDatabaseObject.DBConnection);

            SqlParameter Param1=new SqlParameter();
            Param1.ParameterName="@PostingStatus";
            Param1.Value=ObjJobPostsBO1.PostingStatus;

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            ObjDatabaseObject.DBAdapter.SelectCommand.Parameters.Add(Param1);
            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;
        }

        public int UpdatePostStatus(JobPostsBO ObjJobPostsBO1)
        {
            ObjDatabaseObject.DBCommand = new SqlCommand();

            ObjDatabaseObject.DBCommand.CommandText = @"uspUpdatePostStatus";

            ObjDatabaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter Param1 = new SqlParameter();
            Param1.ParameterName = "@PostingStatus";
            Param1.Value = ObjJobPostsBO1.PostingStatus;

            SqlParameter Param2 = new SqlParameter();
            Param2.ParameterName = "@UniqueCode";
            Param2.Value = ObjJobPostsBO1.UniqueCode;

            SqlParameter Param3 = new SqlParameter();
            Param3.ParameterName = "@PostId";
            Param3.Value = ObjJobPostsBO1.PostId;


            try
            {
                ObjDatabaseObject.DBCommand.Connection = ObjDatabaseObject.DBConnection;

                ObjDatabaseObject.DBConnection.Open();

                ObjDatabaseObject.DBCommand.Parameters.Add(Param1);
                ObjDatabaseObject.DBCommand.Parameters.Add(Param2);
                ObjDatabaseObject.DBCommand.Parameters.Add(Param3);

                return ObjDatabaseObject.DBCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                ObjDatabaseObject.DBConnection.Close();
            }

        }
    }
}
