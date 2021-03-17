﻿using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class AdministratorDAOPGSQL : IAdministratorDAO
    {
       private readonly string conn_string;
        public AdministratorDAOPGSQL()
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
        public void Add(Administrator t)
        {

            ExecuteNonQuery($"call sp_add_administrator('{t.FirstName}','{t.LastName}',{t.Level})");
        }
        public Administrator GetById(long id)
        {
            Administrator t = new Administrator();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("sp_get_administrator_by_id", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new NpgsqlParameter("x", id));
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        t.ID = (long)reader["id"];
                        t.FirstName = (string)reader["first_name"];
                        t.LastName = (string)reader["last_name"];
                        t.Level = (int)reader["level"];
                    }
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
                while (reader.Read())  
                {
                    Administrator t = new Administrator();
                    t.ID = (long)reader["id"];
                    t.FirstName = (string)reader["first_name"];
                    t.LastName = (string)reader["last_name"];
                    t.Level = (int)reader["level"];
                    a_list.Add(t);
                }
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
