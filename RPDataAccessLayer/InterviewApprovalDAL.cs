using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using System.Data;
using System.Data.SqlClient;

namespace RPDataAccessLayer
{
    public class InterviewApprovalDAL
    {

        DatabaseObject ObjDatabaseObject = new DatabaseObject();

        RecruiterProfileBO ObjRecruiterProfileBO = new RecruiterProfileBO();

        JobPostsBO ObjJobPostsBO = new JobPostsBO();

        ApplicationBO ObjApplicationBO = new ApplicationBO();

        public DataTable LoadIVDetails()
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();


            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspLoadIVDetails", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;

        }

        public DataTable SortDetailsByUniqueCode()
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();



            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspSortDetailsByUniqueCode", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;
        }

        public DataTable SortDetailsByCompanyName()
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();



            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspSortDetailsByCompanyName", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;
        }

        public DataTable SortDetailsByInterviewDate()
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();



            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspSortDetailsByInterviewDate", ObjDatabaseObject.DBConnection);

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;
        }

        public DataTable LoadIVDetailsByCompanyName(RecruiterProfileBO ObjRecruiterProfileBO1)
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();



            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspLoadIVDetailsByCompanyName", ObjDatabaseObject.DBConnection);

            SqlParameter Param1 = new SqlParameter();
            Param1.ParameterName = "@CompanyName";
            Param1.Value = ObjRecruiterProfileBO1.CompanyName;

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            ObjDatabaseObject.DBAdapter.SelectCommand.Parameters.Add(Param1);
            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;
        }

        public DataTable LoadIVDetailsByInterViewDate(ApplicationBO ObjApplicationBO1)
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();



            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspLoadIVDetailsByInterViewDate", ObjDatabaseObject.DBConnection);

            SqlParameter Param1 = new SqlParameter();
            Param1.ParameterName = "@InterviewDatetime";
            Param1.Value = ObjApplicationBO1.InterviewDatetime;

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            ObjDatabaseObject.DBAdapter.SelectCommand.Parameters.Add(Param1);
            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;
        }

        public int UpdateIVDetails(ApplicationBO ObjApplicationBO1)
        {
            ObjDatabaseObject.DBCommand = new SqlCommand();

            ObjDatabaseObject.DBCommand.CommandText = @"uspUpdateIVDetails";

            ObjDatabaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            #region "params"
            SqlParameter Param1 = new SqlParameter();
            Param1.ParameterName = "@UniqueCode";
            Param1.Value = ObjApplicationBO1.UniqueCode;

            SqlParameter Param2 = new SqlParameter();
            Param2.ParameterName = "@PostId";
            Param2.Value = ObjApplicationBO1.PostId;

            SqlParameter Param3 = new SqlParameter();
            Param3.ParameterName = "@LoginId";
            Param3.Value = ObjApplicationBO1.LoginId;
            #endregion

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

        public DataTable LoadApplicantDetails(JobSeekerProfileBO ObjJobSeekerProfile)
        {
            ObjDatabaseObject.DBDataTable = new DataTable();

            ObjDatabaseObject.DBAdapter = new SqlDataAdapter();

            ObjDatabaseObject.DBAdapter.SelectCommand = new SqlCommand(@"uspLoadApplicantDetails", ObjDatabaseObject.DBConnection);

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@LoginId";
            sqlParameter.Value = ObjJobSeekerProfile.LoginId;

            ObjDatabaseObject.DBAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            ObjDatabaseObject.DBAdapter.SelectCommand.Parameters.Add(sqlParameter);
            ObjDatabaseObject.DBAdapter.Fill(ObjDatabaseObject.DBDataTable);

            return ObjDatabaseObject.DBDataTable;
        }


    }
}
