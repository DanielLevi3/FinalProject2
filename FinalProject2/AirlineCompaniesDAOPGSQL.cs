using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class AirlineCompaniesDAOPGSQL : IAirlineCompanyDAO
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
                string sp_name = $"select * from sp_get_airlinecompanies_by_id({id})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ac.ID = (long)reader["id"];
                    ac.CountryId= (long)reader["country_id"];
                    ac.UserId = (long)reader["user_id"];
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
                AirlineCompanies ac = new AirlineCompanies();
                while (reader.Read())
                {
                    ac.ID = (long)reader["id"];
                    ac.CountryId = (long)reader["country_id"];
                    ac.UserId = (long)reader["user_id"];
                }
                ac_list.Add(ac);
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
                string sp_name = $"select * from sp_get_airlinecompanies_by_username('{u_name}')";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ac.ID = (long)reader["id"];
                    ac.CountryId = (long)reader["country_id"];
                    ac.UserId = (long)reader["user_id"];
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
                string sp_name = $"sp_get_airlinecompanies_by_country_id({countryId})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                AirlineCompanies ac = new AirlineCompanies();
                while (reader.Read())
                {
                    ac.ID = (long)reader["id"];
                    ac.CountryId = (long)reader["country_id"];
                    ac.UserId = (long)reader["user_id"];
                }
                ac_list.Add(ac);
            }
            return ac_list;
        }
    }
}
