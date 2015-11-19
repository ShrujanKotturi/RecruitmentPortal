using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RPBusinessObject;
using System.Data.SqlClient;

namespace RPDataAccessLayer
{
    public class ShowPostingsDAL
    {
        DatabaseObject databaseObject = new DatabaseObject();

        public DataSet GetJobPostingDetails1(string uniqueCode)
        {
            databaseObject.DBDataSet = new DataSet();
            databaseObject.DBAdapter = new SqlDataAdapter();

            databaseObject.DBCommand = new SqlCommand();


            databaseObject.DBCommand.CommandText = @"GetJobPostingDetails";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();

            param1.ParameterName = "@UniqueCode";
            param1.Value = uniqueCode;

            databaseObject.DBCommand.Parameters.Add(param1);
            

            databaseObject.DBAdapter.SelectCommand = databaseObject.DBCommand;
            databaseObject.DBAdapter.SelectCommand.Connection = databaseObject.DBConnection;
            databaseObject.DBAdapter.Fill(databaseObject.DBDataSet);

            return databaseObject.DBDataSet;
        }

        public DataTable GetJobPostingDetails(string uniqueCode)
        {
            databaseObject.DBDataTable = new DataTable();
            databaseObject.DBCommand = new SqlCommand();
            databaseObject.DBAdapter = new SqlDataAdapter();

            databaseObject.DBCommand.CommandText = @"GetJobPostingDetails";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@UniqueCode";
            param1.Value = uniqueCode;
            databaseObject.DBCommand.Parameters.Add(param1);

            try
            {
                
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;
                databaseObject.DBConnection.Open();
                databaseObject.DBAdapter.SelectCommand = databaseObject.DBCommand;
                databaseObject.DBAdapter.Fill(databaseObject.DBDataTable);
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                databaseObject.DBConnection.Close();
            }
            return databaseObject.DBDataTable;
        }
    }
}
