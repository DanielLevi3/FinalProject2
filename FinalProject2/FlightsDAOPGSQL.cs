﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class FlightsDAOPGSQL : IFlightDAO
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
                string sp_name = $"select * from sp_get_flights_by_id({id})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
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
            return f;
        }
        public List<Flights> GetAll()
        {
            List<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "sp_get_all_flights";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                Flights f = new Flights();
                while (reader.Read())
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
            return f_list;
        }

        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_flights({id})");
        }

        public void Update(Flights f)
        {
            ExecuteNonQuery($"call sp_update_flights({f.ID},{f.AirlineCompanyId},{f.OriginCountryId},{f.DestinationCountryId},'{f.DepartureTime}','{f.LandingTime}',{f.RemainingTickets})");
        }

        public Dictionary<Flights, int> GetAllFlightsVacancy()
        {
            throw new NotImplementedException();
        }

        public IList<Flights> GetFlightsByOriginCountry(long countryCode)
        {

            List<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"sp_get_flights_by_origin_country({countryCode})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                Flights f = new Flights();
                while (reader.Read())
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
            return f_list;
        }


        public IList<Flights> GetFlightsByDestinationCountry(long countryCode)
        {
            List<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"sp_get_flights_by_destination_country({countryCode})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                Flights f = new Flights();
                while (reader.Read())
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
            return f_list;
        }
    

        public IList<Flights> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            List<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"sp_get_flights_by_departure_time('{departureDate}')";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                Flights f = new Flights();
                while (reader.Read())
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
            return f_list;
        }
    

        public IList<Flights> GetFlightsByLandingDate(DateTime landingDate)
        { 
            List<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"sp_get_flights_by_landing_time('{landingDate}')";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                Flights f = new Flights();
                while (reader.Read())
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
            return f_list;
        }

        public IList<Flights> GetFlightsByCustomerId(Customers customer)
        {
            List<Flights> f_list = new List<Flights>();
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"sp_get_flights_by_customerid({customer.ID})";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                var reader = command.ExecuteReader();
                Flights f = new Flights();
                while (reader.Read())
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
            return f_list;
        }


    }
}
