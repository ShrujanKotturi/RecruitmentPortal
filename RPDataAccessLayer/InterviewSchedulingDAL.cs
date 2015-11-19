using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using System.Data;
using System.Data.SqlClient;

namespace RPDataAccessLayer
{
    public class InterviewSchedulingDAL
    {
        DatabaseObject databaseObject = new DatabaseObject();
        DataTable table;
        SqlDataAdapter dataAdapter;

        public DataTable ShowApplicantsDetails(long recruiterLiginId)
        {
            dataAdapter = new SqlDataAdapter();
            table = new DataTable();
            databaseObject.DBCommand = new SqlCommand("uspShowApplicantsDetails", databaseObject.DBConnection);
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            databaseObject.DBCommand.Parameters.Add("@RecruiterLoginId", SqlDbType.BigInt).Value = recruiterLiginId;

            dataAdapter.SelectCommand = databaseObject.DBCommand;
            dataAdapter.Fill(table);

            return table;
        }

        public int UpdateApplication(string candidateName, int postId, char interviewStatus, DateTime interviewDatetime)
        {
            databaseObject.DBCommand = new SqlCommand("uspUpdateJobApplication", databaseObject.DBConnection);
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@CandidateName";
            param1.Value = candidateName;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@PostId";
            param2.Value = postId;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@InterviewStatus";
            param3.Value = interviewStatus;

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@InterviewDatetime";
            param4.Value = interviewDatetime;


            //dataAdapter.SelectCommand = databaseObject.DBCommand;

            try
            {
                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBCommand.Parameters.Add(param2);
                databaseObject.DBCommand.Parameters.Add(param3);
                databaseObject.DBCommand.Parameters.Add(param4);

                int status = 0;

                status = databaseObject.DBCommand.ExecuteNonQuery();

                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception)
            {
                return 2;
            }
            finally
            {
                databaseObject.DBConnection.Close();

            }
        }

        public int UpdateUnscheduledApplication(string candidateName, int postId, char interviewStatus)
        {
            
            databaseObject.DBCommand = new SqlCommand("uspUpdateJobApplication", databaseObject.DBConnection);
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@CandidateName";
            param1.Value = candidateName;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@PostId";
            param2.Value = postId;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@InterviewStatus";
            param3.Value = interviewStatus;

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@InterviewDatetime";
            param4.Value = null;


            //dataAdapter.SelectCommand = databaseObject.DBCommand;

            try
            {
                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBCommand.Parameters.Add(param2);
                databaseObject.DBCommand.Parameters.Add(param3);
                databaseObject.DBCommand.Parameters.Add(param4);

                int status = 0;

                status = databaseObject.DBCommand.ExecuteNonQuery();

                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception)
            {
                return 2;
            }
            finally
            {
                databaseObject.DBConnection.Close();

            }
        }

        public DataTable JobSeekerDetails(string candidateName)
        {
            dataAdapter = new SqlDataAdapter();
            table = new DataTable();
            databaseObject.DBCommand = new SqlCommand("uspGetJobSeekerDetails", databaseObject.DBConnection);
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            databaseObject.DBCommand.Parameters.Add("@CandidateName", SqlDbType.VarChar).Value = candidateName;

            dataAdapter.SelectCommand = databaseObject.DBCommand;
            dataAdapter.Fill(table);

            return table;
        }

        public void DummyMethod()
        {
            table = new DataTable();
            foreach (DataRow element in table.Rows)
            {

            }
        }

        public DataTable GetRecruiterUserName(int loginId)
        {
            dataAdapter = new SqlDataAdapter();
            table = new DataTable();
            //string recruiterName;
            databaseObject.DBCommand = new SqlCommand("uspGetRecruiterUserName", databaseObject.DBConnection);
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            databaseObject.DBCommand.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;

            dataAdapter.SelectCommand = databaseObject.DBCommand;
            dataAdapter.Fill(table);

            return table;
        }

        public DataTable GetResumePathOfCandidate(string candidateName)
        {
            dataAdapter = new SqlDataAdapter();
            table = new DataTable();
            //string recruiterName;
            databaseObject.DBCommand = new SqlCommand("uspGetResumePath", databaseObject.DBConnection);
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            databaseObject.DBCommand.Parameters.Add("@CandidateName", SqlDbType.VarChar).Value = candidateName;

            dataAdapter.SelectCommand = databaseObject.DBCommand;
            dataAdapter.Fill(table);

            return table;
        }
    }
}
