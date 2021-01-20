using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class AdministratorDAO : IBasicDb<Administrator>
    {
        string conn_string;
        private void ExecuteNonQuery(string procedure)
        {
            using (var conn = new NpgsqlConnection(procedure))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(procedure, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
        public void Add(Administrator t)
        {
            ExecuteNonQuery($"call sp_add_administrator('{t.FirstName}','{t.LastName}',{t.Level})");
        }

        public Administrator Get(long id)
        {
            Administrator t = new Administrator();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"select * from sp_get_administrator_by_id({id})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    t.ID = (long)reader["id"];
                    t.FirstName = (string)reader["first_name"];
                    t.LastName = (string)reader["last_name"];
                    t.Level = (int)reader["level"];
                }
            }
            return t;
        }
        public List<Administrator> GetAll()
        {
            List<Administrator> a_list = new List<Administrator>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "sp_get_all_administrators";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                Administrator t = new Administrator();
                while (reader.Read())  
                {
                    t.ID = (long)reader["id"];
                    t.FirstName = (string)reader["first_name"];
                    t.LastName = (string)reader["last_name"];
                    t.Level = (int)reader["level"];
                }
               a_list.Add(t);
            }
            return a_list;
        }

        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_administrator({id})");
        }

        public void Update(Administrator t)
        {
            ExecuteNonQuery($"call sp_update_administrator({t.ID},'{t.FirstName}','{t.LastName}',{t.Level})");
        }
    }
}
