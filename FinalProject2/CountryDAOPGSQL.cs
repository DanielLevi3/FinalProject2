using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class CountryDAOPGSQL : ICountryDAO
    {
        string conn_string;
        private void ExecuteNonQuery(string procedure)
        {
            using(var conn= new NpgsqlConnection(procedure))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(procedure, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
        public void Add(Country c)
        {
            ExecuteNonQuery($"call sp_add_country('{c.Name}')");
        }

        public Country GetById(long id)
        {
            Country c = new Country();
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();
                    string sp_name = $"select * from sp_get_country_by_id({id})";

                    NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        c.ID = (long)reader["id"];
                        c.Name= (string)reader["name"];
                    }
                }
            return c;
            }
        public List<Country> GetAll()
        {
            List<Country> c_list = new List<Country>();
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();
                    string sp_name = "sp_get_all_countries";

                    NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    var reader = command.ExecuteReader();
                Country c = new Country();
                    while (reader.Read())
                    {
                         c.ID= (long)reader["id"];
                         c.Name= (string)reader["name"];
                    }
                c_list.Add(c);
                }
            return c_list;
        } 

        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_country({id})");
        }

        public void Update(Country c)
        {
            ExecuteNonQuery($"call sp_update_country({c.ID},'{c.Name}')");
        }
    }
}
