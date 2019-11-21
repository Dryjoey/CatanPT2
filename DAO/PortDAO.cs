using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class PortDAO : DAO
    {
        public void InsertPort(int boardId, Port port)
        {
            //inserting all ports into database from board
            using (SqlConnection SqlCon = con)
            {
                string query = "INSERT INTO Port (BoardId, Converserion, Position) VALUES(@BoardId, @Conversion, @Placement)";

                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    command.Parameters.Add("@BoardId", SqlDbType.Int);
                    command.Parameters["board.Id"].Value = boardId;
                    command.Parameters.Add("@conversion", SqlDbType.VarChar);
                    command.Parameters["port.Conversion"].Value = port.Conversion;
                    command.Parameters.Add("@Placement", SqlDbType.Int);
                    command.Parameters["port.Placement"].Value = port.Placement;
                    command.ExecuteNonQuery();
                }

                SqlCon.Close();
            }
        }

        public List<Port> GetAllPortsFromBoard(int boardId)
        {
            using (SqlConnection SqlCon = con)
            {

                string query = "SELECT * FROM Port WHERE BoardId = @BoardId";
                List<Port> result = new List<Port>();

                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    command.Parameters.Add("@BoardId", SqlDbType.Int);
                    command.Parameters["@BoardId"].Value = boardId;
                    using (SqlDataReader Reader = command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Port port = new Port(Reader.GetString(1), Reader.GetInt32(2));
                            // result is every port from that board
                            result.Add(port);
                        }
                    }
                    SqlCon.Close();
                }
                return result;
            }
        }

        public void DeletePorts(int boardId)
        {
            //deleting al ports from one board
            using (SqlConnection SqlCon = con)
            {
                string query = "DELETE * FROM Port Where BoardId = @BoardId";

                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    command.Parameters.Add("@BoardId", SqlDbType.Int);
                    command.Parameters["board.Id"].Value = boardId;
                    command.ExecuteNonQuery();
                }
                SqlCon.Close();
            }
        }
    }
}
