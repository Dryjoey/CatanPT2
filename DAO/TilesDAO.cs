using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class TilesDAO : DAO
    {
        List<Tile> Tiles = new List<Tile>();

        public List<Tile> GetAllTiles()
        {
            con.Open();

            string query = "SELECT * FROM Tiles WHERE BoardId = @BoardId";
            List<Tile> result = new List<Tile>();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.ExecuteNonQuery();
                command.Parameters.Add("@BoardId");
                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    // result.Add(new Tile());
                }

                con.Close();

                return result;
            }
        }

        public void InsertTiles(List<Tile> tiles, Board board)
        {
            //all tiles need to be filled


            foreach (Tile tile in tiles)
            {
                con.Open();
                string query =

                    "INSERT INTO Tiles (BoardId, TilePosition, Resource, Chip) " +
                    "VALUES(@Boardid, @Tileposition, @Resource, @chip)";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Boardid", board.Id);
                    command.Parameters.AddWithValue("@Tileposition", tile.id);
                    command.Parameters.AddWithValue("@Resource", tile.tilecategorie);
                    command.Parameters.AddWithValue("@chip", tile.chip);

                    command.ExecuteNonQuery();

                    con.Close();
                }
            }
        }

        public void DeleteTiles(Board board)
        {

            con.Open();
            string query =

                "DELETE * FROM Tiles Where BoardId = @BoardId";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("BoardId", board.Id);

                command.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
