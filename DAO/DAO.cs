using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public abstract class DAO
    {
        public SqlConnection con;
        public DAO()
        {
            this.con = new SqlConnection("Server=192.71.226.6:1433;Database=catanAdmin;User Id=CatanAdmin;Password=CatanAdmin!@1;");
        }
    }
}
