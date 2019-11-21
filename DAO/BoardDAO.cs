﻿using DAO.Util;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class BoardDAO
    {
        TilesDAO tile;
        PortDAO port;
        List<Board> boards = new List<Board>();

        private readonly DatabaseConnection _db;

        public BoardDAO(DatabaseConnection db)
        {
            _db = db;
            port = new PortDAO(_db);
            tile = new TilesDAO(_db);
        }
        public List<Board> GetAllBoardsFromUser(int userId)
        {
            using (var con = _db.SqlConnection)
            {
                // where needs to be added
                string query = "SELECT * FROM Board WHERE UserId = @userid";
                List<Board> boards = new List<Board>();

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    command.Parameters.Add("@userid", SqlDbType.Int);
                    command.Parameters["@userId"].Value = userId;
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            Board board = new Board();
                            board.BoardId = read.GetInt32(0);
                            board.UserId = read.GetInt32(1);
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
            Board returnBoard = new Board();
            using (var con = _db.SqlConnection)
            {
                // where needs to be added
                string query = "SELECT * FROM Board WHERE Id= @Id";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
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
                    returnBoard.Tiles = tile.GetAllTilesFromBoard(boardId);
                    returnBoard.Ports = port.GetAllPortsFromBoard(boardId);
                }
                return returnBoard;

                //daarna ga naar tiles en port en haal alle gegevens op
            }

        }
        public void InsertBoard(Board board, int userId)
        {
            using (var con = _db.SqlConnection)
            {

                string query = "INSERT INTO Board (UserId) Values (@UserId)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    command.Parameters.Add("@UserId", SqlDbType.Int);
                    command.Parameters["@UserId"].Value = userId;

                    command.ExecuteNonQuery();

                    con.Close();
                    board.BoardId = GetBoardId();

                    foreach (Port harbor in board.Ports)
                    {
                        port.InsertPort(board.BoardId, harbor);
                    }
                    foreach (Tile tilehex in board.Tiles)
                    {
                        tile.InsertTiles(tilehex, board.BoardId);
                    }
                }
            }
        }

        public int GetBoardId()
        {
            int boardid = 0;
            using (var con = _db.SqlConnection)
            {
                con.Open();
                string query = "SELECT TOP 1 * FROM Board ORDER BY Id DESC";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    
                    boardid = (int)command.ExecuteScalar();
                }
                con.Close();
            }
            return boardid;
        }

        public void DeleteBoard(int boardId)
        {
            using (var con = _db.SqlConnection)
            {
                // delete port and delete tiles first 
                port.DeletePorts(boardId);
                tile.DeleteTiles(boardId);

                string query = "DELETE FROM Board WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["board.Id"].Value = boardId;

                    command.ExecuteNonQuery();

                    con.Close();

                }
            }
        }
    }
}
