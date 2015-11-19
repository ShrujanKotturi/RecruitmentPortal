using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace RPDataAccessLayer
{
    public class JobSeekerProfileDAL
    {


        DatabaseObject dbConnection = new DatabaseObject();

        int queryStatus = 0;

        public int InsertJobSeekerProfile(JobSeekerProfileBO jobSeeker)
        {
            dbConnection.DBDataTable = new DataTable("JobSeekerProfile");
            dbConnection.DBDataTable.Columns.Add("LoginId", typeof(long));
            dbConnection.DBDataTable.Columns.Add("CandidateName", typeof(string));
            dbConnection.DBDataTable.Columns.Add("YearsOfExp", typeof(int));
            dbConnection.DBDataTable.Columns.Add("SkillSet", typeof(string));
            dbConnection.DBDataTable.Columns.Add("Address", typeof(string));
            dbConnection.DBDataTable.Columns.Add("mail_id", typeof(string));
            dbConnection.DBDataTable.Columns.Add("Phone", typeof(string));
            dbConnection.DBDataTable.Columns.Add("Industry", typeof(string));
            dbConnection.DBDataTable.Columns.Add("CurrentPosition", typeof(string));
            dbConnection.DBDataTable.Columns.Add("CurrentSalary", typeof(float));
            dbConnection.DBDataTable.Columns.Add("ExpectedPosition", typeof(string));
            dbConnection.DBDataTable.Columns.Add("ExpectedJobLocation", typeof(string));
            dbConnection.DBDataTable.Columns.Add("ResumeFileName", typeof(string));
            dbConnection.DBDataTable.Columns.Add("ResumeFilePath", typeof(string));

            dbConnection.DBDataTable.Rows.Add(jobSeeker.LoginId, jobSeeker.CandidateName,jobSeeker.YearsOfExperience,jobSeeker.SkillSet, jobSeeker.Address, jobSeeker.EmailId, jobSeeker.Phone,
                                              jobSeeker.Industry, jobSeeker.CurrentPosition, jobSeeker.CurrentSalary, jobSeeker.ExpectedPosition, jobSeeker.ExpectedJobLocation,jobSeeker.ResumeFileName,jobSeeker.ResumeFilePath);

            try
            {
                dbConnection.DBConnection.Open();

                using (dbConnection.DBConnection)
                {
                    dbConnection.DBCommand = new SqlCommand("uspInsertJobSeekerProfile", dbConnection.DBConnection);
                    dbConnection.DBCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter tvpParameter = dbConnection.DBCommand.Parameters.AddWithValue("@TVP", dbConnection.DBDataTable);
                    tvpParameter.SqlDbType = SqlDbType.Structured;
                    queryStatus = dbConnection.DBCommand.ExecuteNonQuery();
                    return queryStatus;

                }
            }
            catch (SqlException)
            {
                return queryStatus;
            }
            finally
            {
                dbConnection.DBConnection.Close();
            }

        }
    }
}
