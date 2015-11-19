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
   public class UserRegistrationDAL
    {
        DatabaseObject dbConnection = new DatabaseObject();
        int queryStatus = 0;
        public int InsertUserDetails(UserDetailsBO userDetailsObj)
        {
            dbConnection.DBDataTable = new System.Data.DataTable("users");
            dbConnection.DBDataTable.Columns.Add("UserId", typeof(string));
            dbConnection.DBDataTable.Columns.Add("UserName", typeof(string));
            dbConnection.DBDataTable.Columns.Add("Password", typeof(string));
            dbConnection.DBDataTable.Columns.Add("Role", typeof(string));

            dbConnection.DBDataTable.Rows.Add(userDetailsObj.UserID, userDetailsObj.UserName, userDetailsObj.Password, userDetailsObj.Role);

            try
            {
                dbConnection.DBConnection.Open();

                using (dbConnection.DBConnection)
                {
                    dbConnection.DBCommand = new System.Data.SqlClient.SqlCommand("dbo.uspInsertUserDetails", dbConnection.DBConnection);
                    dbConnection.DBCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter tvpParam = dbConnection.DBCommand.Parameters.AddWithValue("@TVP", dbConnection.DBDataTable);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    queryStatus = dbConnection.DBCommand.ExecuteNonQuery();
                    return queryStatus;

                }
            }
            catch (SqlException exc)
            {
                return queryStatus;
            }
            finally
            {
                dbConnection.DBConnection.Close();
            }
        }

        public DataTable ValidateUserCredintials(UserDetailsBO userDetails)
        {
            try
            {
                dbConnection.DBAdapter = new SqlDataAdapter();
                dbConnection.DBCommand = new SqlCommand("uspValidateUser",dbConnection.DBConnection);
                dbConnection.DBCommand.CommandType = CommandType.StoredProcedure;
                dbConnection.DBCommand.Parameters.AddWithValue("@userid", userDetails.UserID);
                dbConnection.DBCommand.Parameters.AddWithValue("@password", userDetails.Password);
                dbConnection.DBAdapter.SelectCommand = dbConnection.DBCommand;
                dbConnection.DBDataTable = new DataTable("validate");
                dbConnection.DBAdapter.Fill(dbConnection.DBDataTable);
                return dbConnection.DBDataTable;
            }
            catch (SqlException)
            {
                return dbConnection.DBDataTable;
            }
        }
    }
}
