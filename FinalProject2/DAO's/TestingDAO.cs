using FinalProject2.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.DAO_s
{
    public class TestingDAO
    {
        public TestingDAO()
        {

        }
        public void ExecuteNonQuery(string procedure)
        {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
            {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(procedure, conn))
               {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = procedure;
                        cmd.ExecuteNonQuery();
               }
           }
        }
    }
}
