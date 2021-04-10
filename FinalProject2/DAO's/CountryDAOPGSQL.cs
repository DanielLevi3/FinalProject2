using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class CountryDAOPGSQL : ICountryDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string conn_string;
        public CountryDAOPGSQL()
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
        public void Add(Country c)
        {
            ExecuteNonQuery($"call sp_add_country('{c.Name}')");
            log.Info($"There is a new Destination {c.Name}");
        }

        public Country GetById(long id)
        {
            Country c = new Country();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_country_by_id", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("x", id));
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            c.ID = (long)reader["id"];
                            c.Name = (string)reader["name"];
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetCountryById {ex} check connection");
            }
            return c;
        }
        public List<Country> GetAll()
        {
            List<Country> c_list = new List<Country>();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();
                    string sp_name = "sp_get_all_countries";

                    NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Country c = new Country();
                        {
                            c.ID = (long)reader["id"];
                            c.Name = (string)reader["name"];
                        }
                        c_list.Add(c);
                    }

                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAllCountries {ex} check connection");
            }
            return c_list;
        } 

        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_country({id})");
            log.Info($"A country id:{id} has removed");
        }

        public void Update(Country c)
        {
            ExecuteNonQuery($"call sp_update_country({c.ID},'{c.Name}')");
        }
    }
}
