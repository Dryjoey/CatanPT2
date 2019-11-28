using DAO.Util;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class PortDAO
    {
        private readonly DatabaseConnection _db;
        public PortDAO()
        {
            
        }
        readonly SqlConnection con = new SqlConnection("Server=198.71.226.6,1433;Database=CatanDB;User Id=CatanAdmin;Password = CatanAdmin!@1;");
        public void InsertPort(int boardId, Port port)
        {

            //inserting all ports into database from board
            
                string query = "INSERT INTO Port (BoardId, Conversion, Position) VALUES(@BoardId, @Conversion, @Placement)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    command.Parameters.Add("@BoardId", SqlDbType.Int);
                    command.Parameters["@BoardId"].Value = boardId;
                    command.Parameters.Add("@Conversion", SqlDbType.VarChar);
                    command.Parameters["@Conversion"].Value = port.Conversion;
                    command.Parameters.Add("@Placement", SqlDbType.Int);
                    command.Parameters["@Placement"].Value = port.Placement;
                    command.ExecuteNonQuery();
                }

                con.Close();
            
        }

        public List<Port> GetAllPortsFromBoard(int boardId)
        {
            List<Port> result = new List<Port>();
            

                string query = "SELECT * FROM Port WHERE BoardId = @BoardId";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
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
                    con.Close();
                }
                return result;
        }

        public void DeletePorts(int boardId)
        {
            //deleting al ports from one board
            
                string query = "DELETE * FROM Port Where BoardId = @BoardId";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    command.Parameters.Add("@BoardId", SqlDbType.Int);
                    command.Parameters["@board.Id"].Value = boardId;
                    command.ExecuteNonQuery();
                }
                con.Close();
            
        }
    }
}
