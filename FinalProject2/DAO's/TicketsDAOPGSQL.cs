using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class TicketsDAOPGSQL : ITicketsDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string conn_string;
        public TicketsDAOPGSQL()
        {
            conn_string = GetConnection.GetTestConn;
        }
        private void ExecuteNonQuery(string procedure)
        {
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
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
            catch (Exception ex)
            {
                log.Fatal($"Check your connection to database {ex}");
            }
        }
        public void Add(Tickets t)
        {
            ExecuteNonQuery($"call sp_add_ticket({t.CustomerID},{t.FlightID})");
        }

        public Tickets GetById(long id)
        {
            Tickets t = new Tickets();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_tickets_by_id", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("x", id));

                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            t.ID = (long)reader["id"];
                            t.CustomerID = (long)reader["customer_id"];
                            t.FlightID = (long)reader["flight_id"];
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetTicketsById {ex} check connection");
            }
            return t;
        }
        public List<Tickets> GetAll()
        {
            List<Tickets> t_list = new List<Tickets>();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();
                    string sp_name = "sp_get_all_tickets";
                    NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Tickets t = new Tickets();
                        t.ID = (long)reader["id"];
                        t.CustomerID = (long)reader["customer_id"];
                        t.FlightID = (long)reader["flight_id"];
                        t_list.Add(t);
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAllTickets {ex} check connection");
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
            log.Info($"Ticket has updated {t}");
        }
    }
}
