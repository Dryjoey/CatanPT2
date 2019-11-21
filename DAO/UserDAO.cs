using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace DAO
{
   public class UserDAO :DAO
    {
        public int GetLastUser()
        {
            int user = 0;
            con.Open();
            string query = "Select MAX(id) FROM Users";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    read.GetInt32(0);
                     read.GetInt32(1);
                }
                con.Close();
                
            }
            return user;
        }
    }
}
