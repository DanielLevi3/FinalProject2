﻿using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class FlightsDAOPGSQL : IFlightDAO
    {
        private readonly string conn_string;
        public FlightsDAOPGSQL()
        {
            GetConnection g = new GetConnection();
            conn_string = g.getConn;
        }
        private void ExecuteNonQuery(string procedure)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            { 
                conn.Open();
                using (var cmd = new NpgsqlCommand(procedure,conn))
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = procedure;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Add(Flights f)
        {
            ExecuteNonQuery($"call sp_add_flights({f.AirlineCompanyId},{f.OriginCountryId},{f.DestinationCountryId},'{f.DepartureTime}','{f.LandingTime}',{f.RemainingTickets})");
        }
        public Flights GetById(long id)
        {
            Flights f = new Flights();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("sp_get_flights_by_id", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new NpgsqlParameter("x", id));

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        f.ID = (long)reader["id"];
                        f.AirlineCompanyId = (long)reader["airline_company_id"];
                        f.OriginCountryId = (long)reader["origin_country_id"];
                        f.DestinationCountryId = (long)reader["destination_country_id"];
                        f.DepartureTime = (DateTime)reader["departure_time"];
                        f.LandingTime = (DateTime)reader["landing_time"];
                        f.RemainingTickets = (int)reader["remaining_tickets"];
                    }
                }
            }
            return f;
        }
        public List<Flights> GetAll()
        {
            List<Flights> f_list = new List<Flights>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_all_flights()";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Flights f = new Flights();
                        {
                            f.ID = (long)reader["id"];
                            f.AirlineCompanyId = (long)reader["airline_company_id"];
                            f.OriginCountryId = (long)reader["origin_country_id"];
                            f.DestinationCountryId = (long)reader["destination_country_id"];
                            f.DepartureTime = (DateTime)reader["departure_time"];
                            f.LandingTime = (DateTime)reader["landing_time"];
                            f.RemainingTickets = (int)reader["remaining_tickets"];
                        }
                        f_list.Add(f);
                    }
                }
            }
            return f_list;
        }


        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_flights({id})");
        }

        public void Update(Flights f)
        { 
            ExecuteNonQuery($"call sp_update_flights({f.ID},{f.LandingTime},{f.OriginCountryId},{f.RemainingTickets},{f.DestinationCountryId},{f.DepartureTime},{f.AirlineCompanyId})");
        }

        public Dictionary<Flights, int> GetAllFlightsVacancy()
        {
            Dictionary<Flights, int> flightVacancy = new Dictionary<Flights, int>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "sp_get_all_flights";
                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Flights f = new Flights();
                    {
                        f.ID = (long)reader["id"];
                        f.AirlineCompanyId = (long)reader["airline_company_id"];
                        f.OriginCountryId = (long)reader["origin_country_id"];
                        f.DestinationCountryId = (long)reader["destination_country_id"];
                        f.DepartureTime = (DateTime)reader["departure_time"];
                        f.LandingTime = (DateTime)reader["landing_time"];
                        f.RemainingTickets = (int)reader["remaining_tickets"];
                    }
                    flightVacancy.Add(f, f.RemainingTickets);
                }
            }
            return flightVacancy;
        }
        public IList<Flights> GetFlightsByOriginCountry(long countryCode)
        {
            IList<Flights> f_list = new List<Flights>();
                using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("sp_get_flights_by_origin_country", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;  
                    cmd.Parameters.Add(new NpgsqlParameter("o_country", countryCode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Flights f = new Flights();
                        {
                            f.ID = (long)reader["id"];
                            f.AirlineCompanyId = (long)reader["airline_company_id"];
                            f.OriginCountryId = (long)reader["origin_country_id"];
                            f.DestinationCountryId = (long)reader["destination_country_id"];
                            f.DepartureTime = (DateTime)reader["departure_time"];
                            f.LandingTime = (DateTime)reader["landing_time"];
                            f.RemainingTickets = (int)reader["remaining_tickets"];
                        }
                        f_list.Add(f);
                    }
                }
            }
            return f_list;
        }
        public IList<Flights> GetFlightsByDestinationCountry(long countryCode)
        {
            List<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("sp_get_flights_by_destination_country", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new NpgsqlParameter("d_country", countryCode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Flights f = new Flights();
                        {
                            f.ID = (long)reader["id"];
                            f.AirlineCompanyId = (long)reader["airline_company_id"];
                            f.OriginCountryId = (long)reader["origin_country_id"];
                            f.DestinationCountryId = (long)reader["destination_country_id"];
                            f.DepartureTime = (DateTime)reader["departure_time"];
                            f.LandingTime = (DateTime)reader["landing_time"];
                            f.RemainingTickets = (int)reader["remaining_tickets"];
                        }
                        f_list.Add(f);
                    }
                }              
            }
            return f_list;
        }
        public IList<Flights> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            IList<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("sp_get_flights_by_departure_time", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new NpgsqlParameter("d_time", departureDate));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Flights f = new Flights();
                        {
                            f.ID = (long)reader["id"];
                            f.AirlineCompanyId = (long)reader["airline_company_id"];
                            f.OriginCountryId = (long)reader["origin_country_id"];
                            f.DestinationCountryId = (long)reader["destination_country_id"];
                            f.DepartureTime = (DateTime)reader["departure_time"];
                            f.LandingTime = (DateTime)reader["landing_time"];
                            f.RemainingTickets = (int)reader["remaining_tickets"];
                        }
                        f_list.Add(f);
                    }
                }
            }
            return f_list;
        }
        public IList<Flights> GetFlightsByLandingDate(DateTime landingDate)
        { 
            List<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("sp_get_flights_by_landing_time", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new NpgsqlParameter("l_time", landingDate));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Flights f = new Flights();
                        {
                            f.ID = (long)reader["id"];
                            f.AirlineCompanyId = (long)reader["airline_company_id"];
                            f.OriginCountryId = (long)reader["origin_country_id"];
                            f.DestinationCountryId = (long)reader["destination_country_id"];
                            f.DepartureTime = (DateTime)reader["departure_time"];
                            f.LandingTime = (DateTime)reader["landing_time"];
                            f.RemainingTickets = (int)reader["remaining_tickets"];
                        }
                        f_list.Add(f);
                    }
                }
            }
            return f_list;
        }
        public IList<Flights> GetFlightsByCustomerId(long customer_id)
        {
            List<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("sp_get_flights_by_customerid", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new NpgsqlParameter("customerid", customer_id));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Flights f = new Flights();
                        {
                            f.ID = (long)reader["id"];
                            f.AirlineCompanyId = (long)reader["airline_company_id"];
                            f.OriginCountryId = (long)reader["origin_country_id"];
                            f.DestinationCountryId = (long)reader["destination_country_id"];
                            f.DepartureTime = (DateTime)reader["departure_time"];
                            f.LandingTime = (DateTime)reader["landing_time"];
                            f.RemainingTickets = (int)reader["remaining_tickets"];
                        }
                        f_list.Add(f);
                    }
                }
            }
            return f_list;
        }
    }
}
