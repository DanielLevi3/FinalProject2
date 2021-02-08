using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class TicketsDAOPGSQL : ITicketsDAO
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
        public void Add(Tickets t)
        {
            ExecuteNonQuery($"call sp_add_ticket({t.CustomerID},{t.FlightID})");
        }

        public Tickets GetById(long id)
        {
            Tickets t = new Tickets();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"select * from sp_get_tickets_by_id({id})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    t.ID = (long)reader["id"];
                    t.CustomerID = (long)reader["customer_id"];
                    t.FlightID=(long)reader["flight_id"];
                }
            }
            return t;
        }
        public List<Tickets> GetAll()
        {
            List<Tickets> t_list = new List<Tickets>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "sp_get_all_tickets";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                Tickets t = new Tickets();
                while (reader.Read())
                {
                    t.ID = (long)reader["id"];
                    t.CustomerID = (long)reader["customer_id"];
                    t.FlightID = (long)reader["flight_id"];
                }
                t_list.Add(t);
            }
            return t_list;
        }

        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_tickets({id})");
        }

        public void Update(Tickets t)
        {
            ExecuteNonQuery($"call sp_update_tickets({t.ID},{t.CustomerID},{t.FlightID})");
        }
    }
}
