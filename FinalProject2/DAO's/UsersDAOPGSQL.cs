using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class UsersDAOPGSQL : IUserDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string conn_string;
        public UsersDAOPGSQL()
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
        public void Add(Users u)
        {
            ExecuteNonQuery($"call sp_add_users('{u.UserName}','{u.Password}','{u.Email}',{u.UserRole})");
            log.Info($"new User in the system {u}");
        }

        public Users GetById(long id)
        {
            Users u = new Users();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_users_by_id", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("x", id));


                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            u.ID = (long)reader["id"];
                            u.UserName = (string)reader["username"];
                            u.Password = (string)reader["password"];
                            u.Email = (string)reader["email"];
                            u.UserRole = (long)reader["user_role"];
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetUsersById {ex} check connection");
            }
            return u;
        }
        public Users GetByUserName(string username)
        {
            Users u = new Users();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_users_by_username", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("username1", username));

                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            u.ID = (long)reader["id"];
                            u.UserName = (string)reader["username"];
                            u.Password = (string)reader["password"];
                            u.Email = (string)reader["email"];
                            u.UserRole = (long)reader["user_role"];
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetUserByUserName {ex} check connection");
            }
            return u;
        }
        public List<Users> GetAll()
        {
            List<Users> u_list = new List<Users>();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();
                    string sp_name = "sp_get_all_users";

                    NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Users u = new Users();
                        u.ID = (long)reader["id"];
                        u.UserName = (string)reader["username"];
                        u.Password = (string)reader["password"];
                        u.Email = (string)reader["email"];
                        u.UserRole = (long)reader["user_role"];
                        u_list.Add(u);
                    }

                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAllUsers {ex} check connection");
            }
            return u_list;
        }

        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_users({id})");
        }

        public void Update(Users u)
        {
            ExecuteNonQuery($"call sp_update_users({u.ID},'{u.UserName}','{u.Password}','{u.Email}',{u.UserRole})");
        }
    }
}
