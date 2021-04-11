using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class AirlineCompaniesDAOPGSQL : IAirlineCompanyDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string conn_string;
        public AirlineCompaniesDAOPGSQL()
        {
            
        }
        private void ExecuteNonQuery(string procedure)
        {
            try
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
            catch (Exception ex)
            {
                log.Fatal($"Check your connection to database {ex}");
            }
        }
        public void Add(AirlineCompanies ac)
        {
            ExecuteNonQuery($"call sp_add_airlinecompanies('{ac.Name}',{ac.CountryId},{ac.UserId})");
            log.Info($"New Airline has added {ac}");
        }
        public AirlineCompanies GetById(long id)
        {

            AirlineCompanies ac = new AirlineCompanies();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_airlinecompanies_by_id", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("x", id));

                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            ac.Name = (string)reader["name"];
                            ac.ID = (long)reader["id"];
                            ac.CountryId = (long)reader["country_id"];
                            ac.UserId = (long)reader["user_id"];
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAirlineCompaniesById {ex} check connection");
            }
            return ac;
        }
        public List<AirlineCompanies> GetAll()
        {
            List<AirlineCompanies> ac_list = new List<AirlineCompanies>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
                {
                    conn.Open();
                    string sp_name = "sp_get_all_airlinecomapnies";
                    NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AirlineCompanies ac = new AirlineCompanies();
                        {
                            ac.Name = (string)reader["name"];
                            ac.ID = (long)reader["id"];
                            ac.CountryId = (long)reader["country_id"];
                            ac.UserId = (long)reader["user_id"];
                        }
                        ac_list.Add(ac);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error($"Something went wrong in GetAll AirlineCompanies {ex} check connection");

            }
            return ac_list;
        }
        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_airlinecompany({id})");
            log.Info($"Airline company with id:{id} has removed");
        }
        public void Update(AirlineCompanies ac)
        {
            ExecuteNonQuery($"call sp_update_airlinecompany({ac.ID},{ac.CountryId},{ac.UserId})");
        }
        public AirlineCompanies GetAirlineByUserame(string u_name)
        {
            AirlineCompanies ac = new AirlineCompanies();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_airlinecompanies_by_username", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("user_name", u_name));
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            ac.Name = (string)reader["name"];
                            ac.ID = (long)reader["id"];
                            ac.CountryId = (long)reader["country_id"];
                            ac.UserId = (long)reader["user_id"];

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error($"Something went wrong in GetAirlineByUserame {ex} check connection");
            }
            return ac;
        }
        public List<AirlineCompanies> GetAllAirlinesByCountry(long countryId)
        {
            List<AirlineCompanies> ac_list = new List<AirlineCompanies>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_airlinecompanies_by_country_id", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("country_id_parm", countryId));

                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            AirlineCompanies ac = new AirlineCompanies();
                            {
                                ac.Name = (string)reader["name"];
                                ac.ID = (long)reader["id"];
                                ac.CountryId = (long)reader["country_id"];
                                ac.UserId = (long)reader["user_id"];
                            }
                            ac_list.Add(ac);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAllAirlinesByCountry {ex} check connection");

            }
            return ac_list;
        }
    }
}
