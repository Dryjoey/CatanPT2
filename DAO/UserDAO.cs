using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace DAO
{
    public class UserDAO : DAO
    {
        public int GetLastUser()
        {
            int user = 0;
            using (SqlConnection SqlCon = con)
            {
                string query = "Select MAX(id) FROM Users";
                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    user = (int)command.ExecuteScalar() + 1;

                }
                SqlCon.Close();
            }
            return user;
        }
    }
}
