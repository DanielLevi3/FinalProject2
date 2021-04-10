using FinalProject2.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.DAO_s
{
    public class TestingDAO
    {
        private string test_conn;

        public TestingDAO()
        {
            test_conn = TestingGetConnection.GetTestConn;
        }
        public void ExecuteNonQuery(string procedure)
        {
                using (var conn = new NpgsqlConnection(test_conn))
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
