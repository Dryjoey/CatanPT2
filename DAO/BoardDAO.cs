using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAO
{
    public class BoardDAO: DAO
    {
        List<Board> board = new List<Board>();

        public List<Board> GetAllBoards()
        {
            con.Open();

            string query = "SELECT * FROM Board";
            List<Board> result = new List<Board>();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.ExecuteNonQuery();

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    result.Add(new Board(read.GetInt32(0), read.GetInt32(1), read.GetInt32(2)));
                }

                con.Close();

                return result;
            }
        }
        public void AddEntity(Board board)
        {
            con.Open();

            string query =

                "INSERT INTO Board(Id, TileId, PortId )";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Id", board.Id);
                command.Parameters.AddWithValue("@TileId", board.Tileid);
                command.Parameters.AddWithValue("@PortId", board.Portid);
                 


                command.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
