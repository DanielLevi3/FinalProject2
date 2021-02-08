using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class CustomersDAOPGSQL : ICustomerDAO
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
        public void Add(Customers c)
        {
            ExecuteNonQuery($"call sp_add_customers('{c.FirstName}','{c.LastName}','{c.Address}','{c.PhoneNumber}','{c.CreditNumber}',{c.UserId})");
        }

        public Customers GetById(long id)
        {
            Customers c = new Customers();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"select * from sp_get_customers_by_id({id})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
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
            return c;
        }
        public List<Customers> GetAll()
        {
            List<Customers> c_list = new List<Customers>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "sp_get_all_customers";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                Customers c = new Customers();
                while (reader.Read())
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
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"select * from sp_get_customers_by_username('{name}')";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
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
            return c;
        }
    }
}
