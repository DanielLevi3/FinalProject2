using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class AirlineCompaniesDAOPGSQL : IAirlineCompanyDAO
    {
        private readonly string conn_string;
        public AirlineCompaniesDAOPGSQL()
        {
            GetConnection g = new GetConnection();
            conn_string = g.getConn;
        }
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
        public void Add(AirlineCompanies ac)
        {
            ExecuteNonQuery($"call sp_add_airlinecompanies({ac.CountryId},{ac.UserId})");
        }
        public AirlineCompanies GetById(long id)
        {
            AirlineCompanies ac = new AirlineCompanies();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("sp_get_airlinecompanies_by_id", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new NpgsqlParameter("x", id));

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ac.ID = (long)reader["id"];
                        ac.CountryId = (long)reader["country_id"];
                        ac.UserId = (long)reader["user_id"];
                    }
                }
            }
            return ac;
        }
        public List<AirlineCompanies> GetAll()
        {
            List<AirlineCompanies> ac_list = new List<AirlineCompanies>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "sp_get_all_airlinecomapnies";
                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AirlineCompanies ac = new AirlineCompanies();
                    ac.ID = (long)reader["id"];
                    ac.CountryId = (long)reader["country_id"];
                    ac.UserId = (long)reader["user_id"];
                    ac_list.Add(ac);
                }
            }
            return ac_list;
        }
        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_airlinecompany({id})");
        }
        public void Update(AirlineCompanies ac)
        {
            ExecuteNonQuery($"call sp_update_airlinecompany({ac.ID},{ac.CountryId},{ac.UserId})");
        }
        public AirlineCompanies GetAirlineByUserame(string u_name)
        {
            AirlineCompanies ac = new AirlineCompanies();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("sp_get_airlinecompanies_by_username", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new NpgsqlParameter("user_name", u_name));
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ac.ID = (long)reader["id"];
                        ac.CountryId = (long)reader["country_id"];
                        ac.UserId = (long)reader["user_id"];

                    }
                }
            }
            return ac;
        }
        public List<AirlineCompanies> GetAllAirlinesByCountry(long countryId)
        {
            List<AirlineCompanies> ac_list = new List<AirlineCompanies>();
            using (var conn = new NpgsqlConnection(conn_string))
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
                        ac.ID = (long)reader["id"];
                        ac.CountryId = (long)reader["country_id"];
                        ac.UserId = (long)reader["user_id"];
                        ac_list.Add(ac);
                    }
                }       
            }

            return ac_list;
        }
    }
}
