using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using System.Data.SqlClient;
using System.Data;

namespace RPDataAccessLayer
{
    public class JobPostsDAL
    {
        
        DatabaseObject databaseObject = new DatabaseObject();

        public int InsertJobPostDetails(JobPostsBO jobPostBOObject)
        {
            int queryStatus = 0;

            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = @"uspInsertJobPost";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            databaseObject.DBDataTable = new DataTable();

            databaseObject.DBDataTable.Columns.Add("UniqueCode", typeof(string));
            databaseObject.DBDataTable.Columns.Add("PostId", typeof(int));
            databaseObject.DBDataTable.Columns.Add("PositionName", typeof(string));
            databaseObject.DBDataTable.Columns.Add("NumberOfOpenings", typeof(string));
            databaseObject.DBDataTable.Columns.Add("LocationOfTheOpenings", typeof(string));
            databaseObject.DBDataTable.Columns.Add("ExperienceRequired", typeof(int));
            databaseObject.DBDataTable.Columns.Add("SkillSet", typeof(string));
            databaseObject.DBDataTable.Columns.Add("TentativeSalary", typeof(double));
            databaseObject.DBDataTable.Columns.Add("CloseDate", typeof(DateTime));
            databaseObject.DBDataTable.Columns.Add("JoiningDate", typeof(DateTime));
            databaseObject.DBDataTable.Columns.Add("PostingStatus", typeof(string));
            databaseObject.DBDataTable.Columns.Add("Comments", typeof(string));

            databaseObject.DBDataTable.Rows.Add(jobPostBOObject.UniqueCode, jobPostBOObject.PostId, jobPostBOObject.PositionName,
                                                jobPostBOObject.NumberOfOpenings, jobPostBOObject.LocationOfTheOpenings, jobPostBOObject.ExperienceRequired,
                                                jobPostBOObject.SkillSet, jobPostBOObject.TentativeSalary, jobPostBOObject.CloseDate,
                                                jobPostBOObject.JoiningDate, jobPostBOObject.PostingStatus, jobPostBOObject.Comments);

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@JobPostDetails";
            param1.Value = databaseObject.DBDataTable;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;

                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);

                queryStatus = databaseObject.DBCommand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
            }
            finally
            {
                databaseObject.DBConnection.Close();
            }


            return queryStatus;
        }

        public int UpdateJobPostDetails(JobPostsBO jobPostBOObject)
        {
            int queryStatus = 0;

            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = @"uspUpdateJobDetails";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@UniqueCode";
            param1.Value = jobPostBOObject.UniqueCode;


            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@PositionName";
            param2.Value = jobPostBOObject.PositionName;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@NumberOfOpening";
            param3.Value = jobPostBOObject.NumberOfOpenings;

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@LocationOfOpening";
            param4.Value = jobPostBOObject.LocationOfTheOpenings;

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@ExperienceRequired";
            param5.Value = jobPostBOObject.ExperienceRequired;

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@SkillSet";
            param6.Value = jobPostBOObject.SkillSet;

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "@TentativeSalary";
            param7.Value = jobPostBOObject.TentativeSalary;

            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "@CloseDate";
            param8.Value = jobPostBOObject.CloseDate;

            SqlParameter param9 = new SqlParameter();
            param9.ParameterName = "@JoiningDate";
            param9.Value = jobPostBOObject.JoiningDate;

            SqlParameter param10 = new SqlParameter();
            param10.ParameterName = "@PostingStatus";
            param10.Value = jobPostBOObject.PostingStatus;


            SqlParameter param11 = new SqlParameter();
            param11.ParameterName = "@PostId";
            param11.Value = jobPostBOObject.PostId;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;

                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBCommand.Parameters.Add(param2);
                databaseObject.DBCommand.Parameters.Add(param3);
                databaseObject.DBCommand.Parameters.Add(param4);
                databaseObject.DBCommand.Parameters.Add(param5);
                databaseObject.DBCommand.Parameters.Add(param6);
                databaseObject.DBCommand.Parameters.Add(param7);
                databaseObject.DBCommand.Parameters.Add(param8);
                databaseObject.DBCommand.Parameters.Add(param9);
                databaseObject.DBCommand.Parameters.Add(param10);
                databaseObject.DBCommand.Parameters.Add(param11);
                

                queryStatus = databaseObject.DBCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                databaseObject.DBConnection.Close();
            }

            return queryStatus;
        }


        public int GetPostId()
        {
            int postId = 0;

            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = @"uspGetPostId";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;
                databaseObject.DBConnection.Open();
                databaseObject.DBDataReader = databaseObject.DBCommand.ExecuteReader();
                if (databaseObject.DBDataReader.HasRows)
                {
                    while (databaseObject.DBDataReader.Read())
                    {
                        postId = (int)databaseObject.DBDataReader[0];
                    }
                }
                
            }
            catch(SqlException ex)
            {

            }
            finally
            {
                databaseObject.DBConnection.Close();
            }
            return postId;
        }


        public string GetCompanyName(string uniqueCode)
        {
            string companyName = string.Empty;
            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = Constants.GetCompanyNameBasedOnLoginId;
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@UniqueCode";
            sqlParameter.Value = uniqueCode;
           
            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;
                databaseObject.DBConnection.Open();
                databaseObject.DBCommand.Parameters.Add(sqlParameter);
                databaseObject.DBDataReader = databaseObject.DBCommand.ExecuteReader();
                if (databaseObject.DBDataReader.HasRows)
                {
                    while (databaseObject.DBDataReader.Read())
                    {
                        companyName = databaseObject.DBDataReader[0].ToString();
                    }
                }

            }
            catch (SqlException ex)
            {

            }
            catch (Exception e)
            {

            }
            finally
            {
                databaseObject.DBConnection.Close();
            }

            return companyName;
        }


        public string GetUniqueCode(long loginId)
        {
            string uniqueCode = string.Empty;

            databaseObject.DBCommand = new SqlCommand();
            

            databaseObject.DBCommand.CommandText = @"GetUniqueCodeBasedOnLoginId";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@LoginId";
            param1.Value = loginId;

            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;
                databaseObject.DBConnection.Open();
                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBDataReader = databaseObject.DBCommand.ExecuteReader();
                if (databaseObject.DBDataReader.HasRows)
                {
                    while (databaseObject.DBDataReader.Read())
                    {
                        uniqueCode = databaseObject.DBDataReader[0].ToString();
                    }
                }

            }
            catch (SqlException ex)
            {

            }

            catch (Exception e)
            {

            }
            finally
            {
                databaseObject.DBConnection.Close();
            }

            return uniqueCode;
        }


        public string GetPostingStatus(int postId)
        {
            string postingStatus = string.Empty;

            databaseObject.DBCommand = new SqlCommand();
           

            databaseObject.DBCommand.CommandText = @"GetPostingStatus";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@PostId";
            param1.Value = postId;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;
                databaseObject.DBConnection.Open();
                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBDataReader = databaseObject.DBCommand.ExecuteReader();
                if (databaseObject.DBDataReader.HasRows)
                {
                    while (databaseObject.DBDataReader.Read())
                    {
                        postingStatus = databaseObject.DBDataReader[0].ToString();
                    }
                }

            }
            catch (SqlException ex)
            {

            }
            catch (Exception e)
            {

            }
            finally
            {
                databaseObject.DBConnection.Close();
            }

            return postingStatus;
        }


        public string GetCompanyNameBasedOnPostId(int postId)
        {
            string companyName = string.Empty;

            databaseObject.DBCommand = new SqlCommand();
           

            databaseObject.DBCommand.CommandText = @"GetCompanyNameBasedOnPostId";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@PostId";
            param1.Value = postId;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;
                databaseObject.DBConnection.Open();
                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBDataReader = databaseObject.DBCommand.ExecuteReader();
                if (databaseObject.DBDataReader.HasRows)
                {
                    while (databaseObject.DBDataReader.Read())
                    {
                        companyName = databaseObject.DBDataReader[0].ToString();
                    }
                }

            }
            catch (SqlException ex)
            {

            }
            catch (Exception e)
            {

            }
            finally
            {
                databaseObject.DBConnection.Close();
            }

            return companyName;
        }


        public string GetUniqueCodeBasedOnPostId(int postId)
        {
            string uniqueCode = string.Empty;

            databaseObject.DBCommand = new SqlCommand();
            

            databaseObject.DBCommand.CommandText = @"GetUniqueCodeBasedOnPostId";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@PostId";
            param1.Value = postId;

            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;
                databaseObject.DBConnection.Open();
                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBDataReader = databaseObject.DBCommand.ExecuteReader();
                if (databaseObject.DBDataReader.HasRows)
                {
                    while (databaseObject.DBDataReader.Read())
                    {
                        uniqueCode = databaseObject.DBDataReader[0].ToString();
                    }
                }

            }
            catch (SqlException ex)
            {

            }

            catch (Exception e)
            {

            }
            finally
            {
                databaseObject.DBConnection.Close();
            }

            return uniqueCode;
        }
    }
}
