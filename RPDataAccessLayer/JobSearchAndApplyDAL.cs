using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using System.Data;
using System.Data.SqlClient;

namespace RPDataAccessLayer
{
    public class JobSearchAndApplyDAL
    {
        DataTable dataset = null;
        SqlDataAdapter dataAdapter;
        DatabaseObject dbo = new DatabaseObject();

        RecruiterProfileBO rpb = new RecruiterProfileBO();
        JobPostsBO jpb = new JobPostsBO();

        public DataTable NotAppliedJobSearchMethod(string CompanyName, string PositionName, string ExperienceRequired, string SkillSet, string LocationOfTheOpenings,long loginId)
        {
            try
            {
                dbo.DBCommand = new SqlCommand();
                dbo.DBCommand.CommandText = "uspNotAppliedJobSearch";
                dbo.DBCommand.CommandType = CommandType.StoredProcedure;
                dbo.DBCommand.Connection = dbo.DBConnection;

                //dataAdapter = new SqlDataAdapter(@"uspSearchJobs",dbo.DBConnection);
                dataAdapter = new SqlDataAdapter();
                dataset = new DataTable();

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@CompanyName";
                parameter1.Value = CompanyName;

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@PositionName";
                parameter2.Value = PositionName;

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@ExperienceRequired";
                parameter3.Value = ExperienceRequired;

                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@Skillset";
                parameter4.Value = SkillSet;

                SqlParameter parameter5 = new SqlParameter();
                parameter5.ParameterName = "@LocationOfOpening";
                parameter5.Value = LocationOfTheOpenings;

                SqlParameter parameter6 = new SqlParameter();
                parameter6.ParameterName = "@LoginId";
                parameter6.Value = loginId;

                dbo.DBCommand.Parameters.Add(parameter1);
                dbo.DBCommand.Parameters.Add(parameter2);
                dbo.DBCommand.Parameters.Add(parameter3);
                dbo.DBCommand.Parameters.Add(parameter4);
                dbo.DBCommand.Parameters.Add(parameter5);
                dbo.DBCommand.Parameters.Add(parameter6);

                dataAdapter.SelectCommand = dbo.DBCommand;
                dataAdapter.Fill(dataset);
            }
            catch (Exception)
            {
                return dataset;
            }
            return dataset;
        }

        public DataTable AppliedJobSearchMethod(string CompanyName, string PositionName, string ExperienceRequired, string SkillSet, string LocationOfTheOpenings,long loginId)
        {
            try
            {
                dbo.DBCommand = new SqlCommand();
                dbo.DBCommand.CommandText = "uspAppliedJobSearch";
                dbo.DBCommand.CommandType = CommandType.StoredProcedure;
                dbo.DBCommand.Connection = dbo.DBConnection;

                //dataAdapter = new SqlDataAdapter(@"uspSearchJobs",dbo.DBConnection);
                dataAdapter = new SqlDataAdapter();
                dataset = new DataTable();

                SqlParameter parameter6 = new SqlParameter();
                parameter6.ParameterName = "@CompanyName";
                parameter6.Value = CompanyName;

                SqlParameter parameter7 = new SqlParameter();
                parameter7.ParameterName = "@PositionName";
                parameter7.Value = PositionName;

                SqlParameter parameter8 = new SqlParameter();
                parameter8.ParameterName = "@ExperienceRequired";
                parameter8.Value = ExperienceRequired;

                SqlParameter parameter9 = new SqlParameter();
                parameter9.ParameterName = "@Skillset";
                parameter9.Value = SkillSet;

                SqlParameter parameter10 = new SqlParameter();
                parameter10.ParameterName = "@LocationOfOpening";
                parameter10.Value = LocationOfTheOpenings;

                SqlParameter parameter11 = new SqlParameter();
                parameter11.ParameterName = "@LoginId";
                parameter11.Value = loginId;

                dbo.DBCommand.Parameters.Add(parameter6);
                dbo.DBCommand.Parameters.Add(parameter7);
                dbo.DBCommand.Parameters.Add(parameter8);
                dbo.DBCommand.Parameters.Add(parameter9);
                dbo.DBCommand.Parameters.Add(parameter10);
                dbo.DBCommand.Parameters.Add(parameter11);

                dataAdapter.SelectCommand = dbo.DBCommand;
                dataAdapter.Fill(dataset);
            }
            catch (Exception)
            {
                return dataset;
            }
            return dataset;
        }


        public int GetPostIdMethod(string UniqueCode, string LocationOfOpening, string Skillset, double TentativeSalary, int ExperienceRequired, string PositionName, string NumberOfOpening, DateTime CloseDate)
        {
            int postid = 0;
            try
            {

                dbo.DBConnection.Open();
                using (dbo.DBConnection)
                {
                    dbo.DBCommand = new SqlCommand();
                    dbo.DBCommand.CommandText = "uspToGetPostId";
                    dbo.DBCommand.CommandType = CommandType.StoredProcedure;
                    dbo.DBCommand.Connection = dbo.DBConnection;

                    //dataAdapter = new SqlDataAdapter(@"uspSearchJobs",dbo.DBConnection);
                    //dataAdapter = new SqlDataAdapter();


                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@UniqueCode";
                    parameter1.Value = UniqueCode;

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@LocationOfOpening";
                    parameter2.Value = LocationOfOpening;

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@Skillset";
                    parameter3.Value = Skillset;

                    SqlParameter parameter4 = new SqlParameter();
                    parameter4.ParameterName = "@TentativeSalary";
                    parameter4.Value = TentativeSalary;

                    SqlParameter parameter5 = new SqlParameter();
                    parameter5.ParameterName = "@ExperienceRequired";
                    parameter5.Value = ExperienceRequired;

                    SqlParameter parameter6 = new SqlParameter();
                    parameter6.ParameterName = "@PositionName";
                    parameter6.Value = PositionName;

                    SqlParameter parameter7 = new SqlParameter();
                    parameter7.ParameterName = "@NumberOfOpening";
                    parameter7.Value = NumberOfOpening;

                    SqlParameter parameter8 = new SqlParameter();
                    parameter8.ParameterName = "@CloseDate";
                    parameter8.Value = CloseDate;

                    dbo.DBCommand.Parameters.Add(parameter1);
                    dbo.DBCommand.Parameters.Add(parameter2);
                    dbo.DBCommand.Parameters.Add(parameter3);
                    dbo.DBCommand.Parameters.Add(parameter4);
                    dbo.DBCommand.Parameters.Add(parameter5);
                    dbo.DBCommand.Parameters.Add(parameter6);
                    dbo.DBCommand.Parameters.Add(parameter7);
                    dbo.DBCommand.Parameters.Add(parameter8);

                    postid = (int)dbo.DBCommand.ExecuteScalar();
                    return postid;
                }
            }
            catch (SqlException)
            {
                return postid;
            }
            finally
            {
                dbo.DBConnection.Close();
            }

        }

        public int InsertIntoTblApplicationMethod(int PostId, string UniqueCode,long LoginId)
        {
            int QuaryStatus = 0;
            try
            {
                //dbo.DBConnection = new SqlConnection();
                dbo.DBConnection1.Open();

                using (dbo.DBConnection1)
                {
                    dbo.DBCommand = new SqlCommand();
                    dbo.DBCommand.CommandText = "uspInsertIntoTblApplication";
                    dbo.DBCommand.CommandType = CommandType.StoredProcedure;
                    dbo.DBCommand.Connection = dbo.DBConnection1;


                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@PostId";
                    parameter1.Value = PostId;

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@UniqueCode";
                    parameter2.Value = UniqueCode;

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@LoginId";
                    parameter3.Value = LoginId;

                    dbo.DBCommand.Parameters.Add(parameter1);
                    dbo.DBCommand.Parameters.Add(parameter2);
                    dbo.DBCommand.Parameters.Add(parameter3);

                    
                    QuaryStatus = dbo.DBCommand.ExecuteNonQuery();
                    return QuaryStatus;
                }

            }
            catch (SqlException)
            {
                return QuaryStatus;
            }
            finally
            {
                dbo.DBConnection1.Close();
            }
        }

        public DataTable GetInterviewScheduleMethod()
        {
            try
            {
                dbo.DBCommand = new SqlCommand();
                dbo.DBCommand.CommandText = "uspGetInterviewSchedule";
                dbo.DBCommand.CommandType = CommandType.StoredProcedure;
                dbo.DBCommand.Connection = dbo.DBConnection;

                
                dataAdapter = new SqlDataAdapter();
                dataset = new DataTable();

               

                dataAdapter.SelectCommand = dbo.DBCommand;
                dataAdapter.Fill(dataset);
            }
            catch (Exception)
            {
                return dataset;
            }
            return dataset;
        }

        public DataTable GetPostDetailMethod(int PostId)
        {
            try
            {
                dbo.DBCommand = new SqlCommand();
                dbo.DBCommand.CommandText = "uspGetJobDetails";
                dbo.DBCommand.CommandType = CommandType.StoredProcedure;
                dbo.DBCommand.Connection = dbo.DBConnection;

                dataAdapter = new SqlDataAdapter();
                dataset = new DataTable();

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.Value = PostId;

                dbo.DBCommand.Parameters.Add(parameter1);

                dataAdapter.SelectCommand = dbo.DBCommand;
                dataAdapter.Fill(dataset);
            }
            catch (Exception)
            {
                return dataset;
            }
            return dataset;
        }


        public DataTable GetRecruiterProfileHavingMathchingJobPost(long LoginId)
        {
            try
            {
                dbo.DBCommand = new SqlCommand();
                dbo.DBCommand.CommandText = "uspGetRecruiterProfile";
                dbo.DBCommand.CommandType = CommandType.StoredProcedure;
                dbo.DBCommand.Connection = dbo.DBConnection;

                dataAdapter = new SqlDataAdapter();
                dataset = new DataTable();

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@LoginId";
                parameter1.Value = LoginId;

                dbo.DBCommand.Parameters.Add(parameter1);

                dataAdapter.SelectCommand = dbo.DBCommand;
                dataAdapter.Fill(dataset);
            }
            catch (Exception)
            {
                return dataset;
            }
            return dataset;
        }

    }
}