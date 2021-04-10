using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class AdministratorDAOPGSQL : IAdministratorDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string conn_string;
        public AdministratorDAOPGSQL()
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
        public void Add(Administrator t)
        {
                ExecuteNonQuery($"call sp_add_administrator('{t.FirstName}','{t.LastName}',{t.Level},{t.User_id})");
                log.Info($"There is a new admin {t}");
                log.Debug($"There is a new admin {t}");

        }
        public Administrator GetById(long id)
        {
            Administrator t = new Administrator();
            try
            {
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
                            t.User_id = (long)reader["user_id"];
                            t.Level = (int)reader["level"];
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAdminById {ex} check connection");
            }
            return t;
        }
        public List<Administrator> GetAll()
        {
            List<Administrator> a_list = new List<Administrator>();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();
                    string sp_name = "sp_get_all_administrators";
                    using (var cmd = new NpgsqlCommand(sp_name, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Administrator t = new Administrator();
                            {
                                t.ID = (long)reader["id"];
                                t.FirstName = (string)reader["first_name"];
                                t.LastName = (string)reader["last_name"];
                                t.Level = (int)reader["level"];
                                t.User_id = (long)reader["user_id"];
                            }
                            a_list.Add(t);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAll Administrators {ex} check connection");
            }
            return a_list;
        }
        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_administrator({id})");
            log.Info($"Admin id {id} as removed");
        }
        public void Update(Administrator t)
        {
            ExecuteNonQuery($"call sp_update_administrator({t.ID},'{t.FirstName}','{t.LastName}',{t.Level},{t.User_id})");
            log.Info($"Admin {t} has updated");
        }
    }
}
