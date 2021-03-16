using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class UsersDAOPGSQL : IUserDAO
    {
        string conn_string;
        public UsersDAOPGSQL()
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
        public void Add(Users u)
        {
            ExecuteNonQuery($"call sp_add_users('{u.UserName}','{u.Password}','{u.Email}',{u.UserRole})");
        }

        public Users GetById(long id)
        {
            Users u = new Users();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"select * from sp_get_users_by_id({id})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    u.ID = (long)reader["id"];
                    u.UserName = (string)reader["username"];
                    u.Password = (string)reader["password"];
                    u.Email = (string)reader["email"];
                    u.UserRole = (long)reader["user_role"];
                }
            }
            return u;
        }
        public Users GetByUserName(string username)
        {
            Users u = new Users();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"select * from sp_get_users_by_username({username})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    u.ID = (long)reader["id"];
                    u.UserName = (string)reader["username"];
                    u.Password = (string)reader["password"];
                    u.Email = (string)reader["email"];
                    u.UserRole = (long)reader["user_role"];
                }
            }
            return u;
        }
        public List<Users> GetAll()
        {
            List<Users> u_list = new List<Users>();
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
