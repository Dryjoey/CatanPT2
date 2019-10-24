using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class BoardDAO: DAO
    {
        List<Board> board = new List<Board>();

        public List<Board> GetAllBoards()
        {
            con.Open();
            // where needs to be added
            string query = "SELECT * FROM Board WHERE UserId = @userid";
            List<Board> result = new List<Board>();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.ExecuteNonQuery();

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    result.Add(new Board(read.GetInt32(0), read.GetInt32(1)));
                }

                con.Close();

                return result;
            }
        }
        public void InsertBoard(Board board)
        {
            //inserting board
            con.Open();

            string query =

                "INSERT INTO Board(UserId)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@UserId", SqlDbType.Int);
                command.Parameters["board.UserId"].Value = board.UserId;
    
                command.ExecuteNonQuery();

                con.Close();
            }
            
        }

        public void DeleteBoard(Board board)
        {
            con.Open();

            string query = 
                "DELETE FROM Board WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["board.Id"].Value = board.Id;

                command.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
