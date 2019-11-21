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
            using (SqlConnection SqlCon = con)
            {
                string query = "INSERT INTO Users( UserId) VALUES (UserId = @UserId)";
                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    command.Parameters.Add("@UserID", SqlDbType.Int);
                    command.Parameters["@UserID"].Value = user;
                }
            }
        }

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
                InsertUser(user);
            }
            return user;
        }
    }
}
