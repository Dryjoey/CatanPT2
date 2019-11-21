using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class UserDAO : DAO
    {
        private void InsertUser(int user)
        {
            using (con)
            {
                string query = "INSERT INTO Users(UserId) VALUES (@UserId)";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    command.Parameters.Add("@UserID", SqlDbType.Int);
                    command.Parameters["@UserID"].Value = user;
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public int GetLastUser()
        {
            int user = 0;
            using (con)
            {
                string query = "Select MAX(id) FROM Users";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    user = (int)command.ExecuteScalar() + 1;

                }
                con.Close();
                InsertUser(user);
            }
            return user;
        }
    }
}
