using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPBusinessObject;
using RPDataAccessLayer;
using System.Data.Sql;
using System.Data;

namespace RPBusinessLogicLayer
{
  public  class UserRegistrationBLL
    {
      UserRegistrationDAL accountCreate = new UserRegistrationDAL();
        public int InsertUserDetails(UserDetailsBO userDetailsObj)
        {
            return accountCreate.InsertUserDetails(userDetailsObj);
        }

        public DataTable ValidateUserCredintials(UserDetailsBO userDetails)
        {
            return accountCreate.ValidateUserCredintials(userDetails);
        }
    }
}
