using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
   public class PortDAO :DAO
    {
        public void InsertPort(Board board, Port port)
        {
            //inserting all ports into database from board
            con.Open();

           string query = "INSERT INTO Port (BoardId, Converserion, Position) VALUES(@BoardId, @Conversion, @Placement)";
           
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@BoardId", SqlDbType.Int);
                command.Parameters["board.Id"].Value = board.Id;
                command.Parameters.Add("@conversion", SqlDbType.VarChar);
                command.Parameters["port.Conversion"].Value = port.Conversion;
                command.Parameters.Add("@Placement", SqlDbType.Int);
                command.Parameters["port.Placement"].Value = port.Placement;
            }

            con.Open();
        }

        public List<Port> GetAllPorts(Board board)
        {
            con.Open();

            string query = "SELECT * FROM Port WHERE BoardId = @BoardId";
            List<Port> result = new List<Port>();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.ExecuteNonQuery();
                command.Parameters.Add("@BoardId", SqlDbType.Int);
                command.Parameters["@BoardId"].Value = board.Id;
                SqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Port port = new Port(Reader.GetString(1), Reader.GetInt32(2));
                
                    // result is every port from that board
                    result.Add(port);
                }

                con.Close();

                return result;
            }
        }
    }
}
