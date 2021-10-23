using FinalProject2.DAO_s;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class FlightsDAOPGSQL : IFlightDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public FlightsDAOPGSQL()
        {
            
        }
        private void ExecuteNonQuery(string procedure)
        {
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
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
            catch(Exception ex)
            {
                log.Fatal($"Check your connection to database {ex}");
            }
        }
        public void Add(Flights f)
        {
            ExecuteNonQuery($"call sp_add_flights( {f.AirlineCompanyId},{f.OriginCountryId},{f.DestinationCountryId},'{f.DepartureTime}','{f.LandingTime}',{f.RemainingTickets})");
            log.Debug($"New Flight {f}");
        }
        public Flights GetById(long id)
        {
            Flights f = new Flights();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
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
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetFlightsById {ex} check connection");
            }
            return f;
        }
        public List<Flights> GetAll()
        {
            List<Flights> f_list = new List<Flights>();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    using (cmd.Connection = new NpgsqlConnection(GlobalConfig.GetConn))
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
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAllFlights {ex} check connection");
            }
            return f_list;
        }


        public void Remove(long id)
        {
            ExecuteNonQuery($"call sp_remove_flights({id})");
            log.Info($"Flight number {id} Has been removed");
        }

        public void Update(Flights f)
        { 
            ExecuteNonQuery($"call sp_update_flights( {f.ID},{f.AirlineCompanyId},{f.OriginCountryId},{f.DestinationCountryId},'{f.DepartureTime}','{f.LandingTime}',{f.RemainingTickets})");
        }

        public Dictionary<Flights, int> GetAllFlightsVacancy()
        {
            Dictionary<Flights, int> flightVacancy = new Dictionary<Flights, int>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
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
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetAllFlightsVacancy {ex} check connection");
            }
            return flightVacancy;
        }
        public IList<Flights> GetFlightsByOriginCountry(long countryCode)
        {
            IList<Flights> f_list = new List<Flights>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
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
            }
            catch (Exception ex)
            {
                log.Error($"Something went wrong in GetFlightsByOriginCountry {ex} check connection");
            }
            return f_list;
        }
        public IList<Flights> GetFlightsByDestinationCountry(long countryCode)
        {
            List<Flights> f_list = new List<Flights>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
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
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetFlightsByDestinationCountry {ex} check connection");
            }
            return f_list;
        }
        public IList<Flights> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            IList<Flights> f_list = new List<Flights>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
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
            }
            catch (Exception ex)
            {
                log.Error($"Something went wrong in GetFlightsByDepatrureDate {ex} check connection");
            }
            return f_list;
        }
        public IList<Flights> GetFlightsByLandingDate(DateTime landingDate)
        { 
            List<Flights> f_list = new List<Flights>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
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
            }
            catch (Exception ex)
            {
                log.Error($"Something went wrong in GetFlightsByLandingDate {ex} check connection");
            }
            return f_list;
        }
        public IList<Flights> GetFlightsByCustomerId(long customer_id)
        {
            List<Flights> f_list = new List<Flights>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
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
            }
            catch(Exception ex)
            {
                log.Error($"Something went wrong in GetFlightsByCustomerId {ex} check connection");

            }
            return f_list;
        }
        //sp_get_flights_by_airline_id
        public IList<Flights> GetByAirlineId(long id)
        {
            List<Flights> f_list = new List<Flights>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_flights_by_airline_id", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("x", id));

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
            }
            catch (Exception ex)
            {
                log.Error($"Something went wrong in GetFlightsByLandingDate {ex} check connection");
            }
            return f_list;
        }
        public IList<Flights> GetFlightsByParameters(DateTime departureDate, DateTime landingDate, long originCountry, long destCountry)
        {
            IList<Flights> f_list = new List<Flights>();
            try
            {
                using (var conn = new NpgsqlConnection(GlobalConfig.GetConn))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("sp_get_flights_by_parameters", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("d_time", departureDate));
                        cmd.Parameters.Add(new NpgsqlParameter("l_time", landingDate));
                        cmd.Parameters.Add(new NpgsqlParameter("o_country", originCountry));
                        cmd.Parameters.Add(new NpgsqlParameter("d_country", destCountry));

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
            }
            catch (Exception ex)
            {
                log.Error($"Something went wrong in GetFlightsByDepatrureDate {ex} check connection");
            }
            return f_list;
        }
    }
}
