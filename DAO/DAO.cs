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
            this.con = new SqlConnection("Server=mssql.fhict.local;Database=dbi382997;User Id=dbi382997;Password=12345;");
        }
    }
}
