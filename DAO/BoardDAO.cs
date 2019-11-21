using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class BoardDAO : DAO
    {
        List<Board> boards = new List<Board>();

        public List<Board> GetAllBoardsFromUser(int userId)
        {
            using (SqlConnection SqlCon = con)
            {
                // where needs to be added
                string query = "SELECT * FROM Board WHERE UserId = @userid";
                List<Board> boards = new List<Board>();

                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    command.Parameters.Add("@userid", SqlDbType.Int);
                    command.Parameters["@userId"].Value = userId;
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            Board board = new Board();
                            board.BoardId = read.GetInt32(0);
                            boards.Add(board);
                        }
                    }
                    con.Close();
                }
                return boards;
            }
        }
        public Board GetBoard(int boardId)
        {
            TilesDAO til = new TilesDAO();
            PortDAO port = new PortDAO();
            Board returnBoard = new Board();
            using (SqlConnection SqlCon = con)
            {
                // where needs to be added
                string query = "SELECT * FROM Board WHERE Id= @Id";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add(new SqlParameter("@Id", boardId));
                    command.Parameters["@Id"].Value = boardId;
                    //command.Parameters["Id"].Value = boardId;
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            returnBoard.BoardId = read.GetInt32(0);
                            returnBoard.UserId = read.GetInt32(1);
                        }
                    }
                    con.Close();
                    returnBoard.Tiles = til.GetAllTilesFromBoard(boardId);
                    returnBoard.Ports = port.GetAllPortsFromBoard(boardId);
                }
                return returnBoard;

                //daarna ga naar tiles en port en haal alle gegevens op
            }

        }
        public void InsertBoard(Board board, int userId)
        {
            PortDAO PortDAO = new PortDAO();
            TilesDAO TilesDAO = new TilesDAO();
            using (SqlConnection SqlCon = con)
            {

                string query = "INSERT INTO Board(UserId)";

                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    command.Parameters.Add("@UserId", SqlDbType.Int);
                    command.Parameters["@UserId"].Value = userId;

                    command.ExecuteNonQuery();

                    con.Close();
                    foreach (Port port in board.Ports)
                    {
                        PortDAO.InsertPort(board.BoardId, port);
                    }
                    foreach (Tile tile in board.Tiles)
                    {
                        TilesDAO.InsertTiles(tile, board.BoardId);
                    }
                }
            }

        }

        public void DeleteBoard(int boardId)
        {
            using (SqlConnection SqlCon = con)
            {
                string query = "DELETE FROM Board WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["board.Id"].Value = boardId;

                    command.ExecuteNonQuery();

                    con.Close();

                }
            }
        }
    }
}
