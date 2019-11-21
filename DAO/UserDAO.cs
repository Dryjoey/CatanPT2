using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace DAO
{
   public class UserDAO :DAO
    {
        public int GetUser()
        {
            con.Open();
            string query = "Select MAX(id) FROM Users";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.ExecuteNonQuery();

                con.Close();

                return result;
            }
            return 0;
        }
    }
}
