using DAO.Util;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class TilesDAO
    {
        private readonly DatabaseConnection _db;
        readonly SqlConnection con = new SqlConnection("Server=198.71.226.6,1433;Database=CatanDB;User Id=CatanAdmin;Password = CatanAdmin!@1;");

        public List<Tile> GetAllTilesFromBoard(int boardId)
        {
           
                string query = "SELECT * FROM Tiles WHERE BoardId = @BoardId";
                List<Tile> result = new List<Tile>();

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    command.Parameters.Add("@BoardId", SqlDbType.Int);
                    command.Parameters["@BoardId"].Value = boardId;

                    using (SqlDataReader Reader = command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Tile tile = new Tile(Reader.GetInt32(1), Reader.GetString(2), Reader.GetInt32(3));

                            // all tiles in list
                            result.Add(tile);
                        }
                    }
                    con.Close();
                }
                return result;
            
        }

        public void InsertTiles(Tile tile, int boardId)
        {
            // adding all tiles in tiles with all their specification
            
                string query = "INSERT INTO Tiles (BoardId, Position, Resource, Chip) VALUES (@Boardid, @Tileposition, @Resource, @chip)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    command.Parameters.Add("@BoardId", SqlDbType.Int);
                    command.Parameters["@BoardId"].Value = boardId;

                    command.Parameters.Add("@Tileposition", SqlDbType.Int);
                    command.Parameters["@Tileposition"].Value = tile.Position;

                    command.Parameters.Add("@Resource", SqlDbType.VarChar);
                    command.Parameters["@Resource"].Value = tile.Resource;

                    command.Parameters.Add("@chip", SqlDbType.Int);
                    command.Parameters["@chip"].Value = tile.Chip;

                    command.ExecuteNonQuery();

                    con.Close();
                }
            
        }

        public void DeleteTiles(int boardId)
        {
            //deleting al tiles from one board
           
                string query = "DELETE * FROM Tiles Where BoardId = @BoardId";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    command.Parameters.Add("@BoardId", SqlDbType.Int);
                    command.Parameters["@BoardId"].Value = boardId;

                    command.ExecuteNonQuery();

                    con.Close();
                }
            
        }
    }
}
