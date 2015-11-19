using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RPBusinessObject;


namespace RPDataAccessLayer
{
    public class SearchJobSeekerProfileDAL
    {
        SqlDataAdapter dataAdapter;
        DataTable table;
        DatabaseObject databaseObject = new DatabaseObject();
        JobPostsBO jobpostbo = new JobPostsBO();
        public DataTable SearchJobSeekerProfileUsingPostDetails(int postId)
        {
            dataAdapter = new SqlDataAdapter();
            table = new DataTable();
            databaseObject.DBCommand = new SqlCommand("uspSearchJobSeekerProfileByPostIdAndPositionName", databaseObject.DBConnection);
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            databaseObject.DBCommand.Parameters.Add("@PostId", SqlDbType.Int).Value = postId;
            //databaseObject.DBCommand.Parameters.Add("@PositionName", SqlDbType.VarChar).Value = positionName;

            dataAdapter.SelectCommand = databaseObject.DBCommand;
            dataAdapter.Fill(table);

            return table;
        }

        public DataTable BindPostDetails(int loginId)
        {
            dataAdapter = new SqlDataAdapter();
            table = new DataTable();
            databaseObject.DBCommand = new SqlCommand("uspGetPostIdAndPositionName", databaseObject.DBConnection);
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            databaseObject.DBCommand.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
            //databaseObject.DBCommand.Parameters.Add("@PositionName", SqlDbType.VarChar).Value = positionName;

            dataAdapter.SelectCommand = databaseObject.DBCommand;
            dataAdapter.Fill(table);

            return table;
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
    }
}
