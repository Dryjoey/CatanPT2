using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAO.Util;

namespace DAO
{
    public class UserDAO
    {
        private readonly DatabaseConnection _db;
        readonly SqlConnection con = new SqlConnection("Server=198.71.226.6,1433;Database=CatanDB;User Id=CatanAdmin;Password = CatanAdmin!@1;");
        private void InsertUser(int user)
        {
           
                //string query = "INSERT INTO Users(UserId) VALUES (@UserId)";
                ////using (SqlCommand command = new SqlCommand(query, con))
                ////{
                ////    con.Open();
                ////    command.Parameters.Add("@UserID", SqlDbType.Int);
                ////    command.Parameters["@UserID"].Value = user;
                ////    command.ExecuteNonQuery();
                ////    con.Close();
                ////}
            
        }

        public int GetLastUser()
        {
            int user = 0;
           
                string query = "Select MAX(id) FROM Users";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    user = (int)command.ExecuteScalar() + 1;

                }
            con.Close();
            InsertUser(user);
            return user;
        }
    }
}
