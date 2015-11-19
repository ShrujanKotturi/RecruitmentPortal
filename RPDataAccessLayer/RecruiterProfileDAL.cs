using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace RPDataAccessLayer
{
    public class RecruiterProfileDAL
    {
        
        DatabaseObject databaseObject = new DatabaseObject();

        
        public string GetUniqueCodeIfExists(RecruiterProfileBO recruiterProfileBOObject)
        {
            string uniqueCodeExists = string.Empty;
            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = @"uspGetUniqueCodeIfExists";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@CompanyName";
            param1.Value = recruiterProfileBOObject.CompanyName;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@RecruiterName";
            param2.Value = recruiterProfileBOObject.RecruiterName;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;

                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBCommand.Parameters.Add(param2);

                databaseObject.DBDataReader = databaseObject.DBCommand.ExecuteReader();

                if (databaseObject.DBDataReader.HasRows == true)
                {
                    while (databaseObject.DBDataReader.Read())
                    {
                        uniqueCodeExists = (databaseObject.DBDataReader[0].ToString());
                    }

                }
                else
                {
                }
            }
            catch (SqlException ex)
            {
                return ex.ErrorCode.ToString();
                
            }
            finally
            {
                databaseObject.DBConnection.Close();
            }

            return uniqueCodeExists;
        }


        public string GenerateUniqueCode(string companyName)
        {
            string uniqueCode = string.Empty;
            StringBuilder sb = new StringBuilder();
            string lastUniqueCode = string.Empty;
            string lastUniqueCodeNumberString = string.Empty;

            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = @"uspGetUniqueCode";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@CompanyName";
            param1.Value = companyName;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;

                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);

                databaseObject.DBDataReader = databaseObject.DBCommand.ExecuteReader();

                if (databaseObject.DBDataReader.HasRows == true)
                {
                    while (databaseObject.DBDataReader.Read())
                    {
                        lastUniqueCode = (databaseObject.DBDataReader[0].ToString());
                        
                        lastUniqueCodeNumberString = (int.Parse(lastUniqueCode.Substring(3).ToUpper()) + 1).ToString();

                        if (lastUniqueCodeNumberString.Length == 1)
                        {
                            sb.Append(lastUniqueCode.Substring(0, 3).ToUpper()).Append("0000").Append(lastUniqueCodeNumberString);
                        }
                        else if (lastUniqueCodeNumberString.Length == 2)
                        {
                            sb.Append(lastUniqueCode.Substring(0, 3).ToUpper()).Append("000").Append(lastUniqueCodeNumberString);
                        }
                        else if (lastUniqueCodeNumberString.Length == 3)
                        {
                            sb.Append(lastUniqueCode.Substring(0, 3).ToUpper()).Append("00").Append(lastUniqueCodeNumberString);
                        }
                        else if (lastUniqueCodeNumberString.Length == 4)
                        {
                            sb.Append(lastUniqueCode.Substring(0, 3).ToUpper()).Append("0").Append(lastUniqueCodeNumberString);
                        }
                        else if (lastUniqueCodeNumberString.Length == 5)
                        {
                            sb.Append(lastUniqueCode.Substring(0, 3).ToUpper()).Append(lastUniqueCodeNumberString);
                        }
                        uniqueCode = sb.ToString();
                    }

                }
                else
                {
                    uniqueCode = sb.Append(companyName.Substring(0, 3).ToUpper()).Append("00001").ToString();
                }
            }
            catch (SqlException ex)
            {
                return ex.ErrorCode.ToString();
                
            }
            finally
            {
                databaseObject.DBConnection.Close();
            }

            return uniqueCode;

        }


        public int InsertRecruitmentProfileDetails(RecruiterProfileBO recruiterProfile)
        {
            int queryStatus = 0;

            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = @"uspInsertRecruiterProfile";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            databaseObject.DBDataTable = new DataTable();

            databaseObject.DBDataTable.Columns.Add("LoginId", typeof(long));
            databaseObject.DBDataTable.Columns.Add("RecruiterName", typeof(string));
            databaseObject.DBDataTable.Columns.Add("CompanyName", typeof(string));
            databaseObject.DBDataTable.Columns.Add("Address", typeof(string));
            databaseObject.DBDataTable.Columns.Add("Mail id", typeof(string));
            databaseObject.DBDataTable.Columns.Add("Phone", typeof(string));
            databaseObject.DBDataTable.Columns.Add("UniqueCode", typeof(string));

            databaseObject.DBDataTable.Rows.Add(recruiterProfile.LoginId, recruiterProfile.RecruiterName, recruiterProfile.CompanyName,
                                                recruiterProfile.Address, recruiterProfile.EmailId, recruiterProfile.Phone, recruiterProfile.UniqueCode);

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@RecruiterDetails";
            param1.Value = databaseObject.DBDataTable;

            param1.SqlDbType = SqlDbType.Structured;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;

                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);

                queryStatus=databaseObject.DBCommand.ExecuteNonQuery();

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


        public int UpdateRecruiterAddress(RecruiterProfileBO recruiterProfileBOObject1)
        {
            int queryStatus = 0;

            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = @"uspUpdateAddress";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Address";
            param1.Value = recruiterProfileBOObject1.Address;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@UniqueCode";
            param2.Value = recruiterProfileBOObject1.UniqueCode;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;

                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBCommand.Parameters.Add(param2);

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


        public int UpdateEmailId(RecruiterProfileBO recruiterProfileBOObject2)
        {
            int queryStatus = 0;
            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = @"uspUpdateEmailId";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@mailId";
            param1.Value = recruiterProfileBOObject2.EmailId;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@UniqueCode";
            param2.Value = recruiterProfileBOObject2.UniqueCode;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;

                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBCommand.Parameters.Add(param2);

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


        public int UpdatePhoneNumber(RecruiterProfileBO recruiterProfileBOObject3)
        {
            int queryStatus = 0;

            databaseObject.DBCommand = new SqlCommand();

            databaseObject.DBCommand.CommandText = @"uspUpdatePhoneNumber";
            databaseObject.DBCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@phoneNumber";
            param1.Value = recruiterProfileBOObject3.Phone;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@UniqueCode";
            param2.Value = recruiterProfileBOObject3.UniqueCode;


            try
            {
                databaseObject.DBCommand.Connection = databaseObject.DBConnection;

                databaseObject.DBConnection.Open();

                databaseObject.DBCommand.Parameters.Add(param1);
                databaseObject.DBCommand.Parameters.Add(param2);

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

    }
}
