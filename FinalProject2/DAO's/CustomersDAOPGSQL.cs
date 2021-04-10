using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class CustomersDAOPGSQL : ICustomerDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string conn_string;
        public CustomersDAOPGSQL()
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
        public void Add(Customers c)
        {
            ExecuteNonQuery($"call sp_add_customers('{c.FirstName}','{c.LastName}','{c.Address}','{c.PhoneNumber}','{c.CreditNumber}',{c.UserId})");
        }
        public Customers GetById(long id)
        {
            Customers c = new Customers();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_customers_by_id", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("x", id));
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            c.ID = (long)reader["id"];
                            c.FirstName = (string)reader["first_name"];
                            c.LastName = (string)reader["last_name"];
                            c.Address = (string)reader["address"];
                            c.PhoneNumber = (string)reader["phone_no"];
                            c.CreditNumber = (string)reader["credit_card_no"];
                            c.UserId = (long)reader["user_id"];
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetCustomersById {ex} check connection");
            }
            return c;
        }
        public List<Customers> GetAll()
        {
            List<Customers> c_list = new List<Customers>();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();
                    string sp_name = "sp_get_all_customers";
                    NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Customers c = new Customers();
                        {
                            c.ID = (long)reader["id"];
                            c.FirstName = (string)reader["first_name"];
                            c.LastName = (string)reader["last_name"];
                            c.Address = (string)reader["address"];
                            c.PhoneNumber = (string)reader["phone_no"];
                            c.CreditNumber = (string)reader["credit_card_no"];
                            c.UserId = (long)reader["user_id"];
                        }
                        c_list.Add(c);
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAllCustomers {ex} check connection");
            }
            return c_list;
        }

        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_customers({id})");
        }
        public void Update(Customers c)
        {
            ExecuteNonQuery($"call sp_update_customers({c.ID},'{c.FirstName}','{c.LastName}','{c.Address}','{c.PhoneNumber}','{c.CreditNumber}',{c.UserId})");
        }
        public Customers GetCustomerByUserame(string name)
        {
            Customers c = new Customers();
            try
            {
                using (var conn = new NpgsqlConnection(conn_string))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_customers_by_username", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("uname", name));

                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            c.ID = (long)reader["id"];
                            c.FirstName = (string)reader["first_name"];
                            c.LastName = (string)reader["last_name"];
                            c.Address = (string)reader["address"];
                            c.PhoneNumber = (string)reader["phone_no"];
                            c.CreditNumber = (string)reader["credit_card_no"];
                            c.UserId = (long)reader["user_id"];
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetCustomerByUserame {ex} check connection");
            }
            return c;
        }
    }
}
