using FinalProject2.DAO_s;
using FinalProject2.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade
    {
        public IList<AirlineCompanies> GetAllAirlineCompanies()
        {
            IList<AirlineCompanies> airlineCompanies = new List<AirlineCompanies>();
            if (_airlineDAO != null)
            {
                airlineCompanies = _airlineDAO.GetAll();
            }
            else
            {
                _airlineDAO = new AirlineCompaniesDAOPGSQL();
                airlineCompanies = _airlineDAO.GetAll();
            }
            return airlineCompanies;
        }

        public IList<Flights> GetAllFlights()
        {
            IList<Flights> flights = new List<Flights>();
            if (_flightDAO != null)
                flights = _flightDAO.GetAll();
            else
            {
                _flightDAO = new FlightsDAOPGSQL();
                flights = _flightDAO.GetAll();
            }
            return flights;
        }

        public Dictionary<Flights, int> GetAllFlightsVacancy()
        {
            Dictionary<Flights, int> flightVacancy = new Dictionary<Flights, int>();
            if (_flightDAO != null)
                flightVacancy = _flightDAO.GetAllFlightsVacancy();
            else
            {
                _flightDAO = new FlightsDAOPGSQL();
                flightVacancy = _flightDAO.GetAllFlightsVacancy();
            }
            return flightVacancy;
        }

        public Flights GetFlightById(int id)
        {
            Flights f = new Flights();
            if (_flightDAO != null)
                f = _flightDAO.GetById(id);
            else
            {
                _flightDAO = new FlightsDAOPGSQL();
                f = _flightDAO.GetById(id);
            }
            return f;
        }

        public IList<Flights> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            IList<Flights> flights = new List<Flights>();
            if (_flightDAO != null)
            {
                flights = _flightDAO.GetFlightsByDepatrureDate(departureDate);
            }
            else
            {
                _flightDAO = new FlightsDAOPGSQL();
                flights = _flightDAO.GetFlightsByDepatrureDate(departureDate);
            }
            return flights;
        }

        public IList<Flights> GetFlightsByDestinationCountry(int countryCode)
        {
            IList<Flights> flights = new List<Flights>();
            if (_flightDAO != null)
            {
                flights = _flightDAO.GetFlightsByDestinationCountry(countryCode);
            }
            else
            {
                _flightDAO = new FlightsDAOPGSQL();
                flights = _flightDAO.GetFlightsByDestinationCountry(countryCode);
            }
            return flights;
        }

        public IList<Flights> GetFlightsByLandingDate(DateTime landingDate)
        {
            IList<Flights> flights = new List<Flights>();
            if (_flightDAO != null)
            {
                flights = _flightDAO.GetFlightsByLandingDate(landingDate);
            }
            else
            {
                _flightDAO = new FlightsDAOPGSQL();
                flights = _flightDAO.GetFlightsByLandingDate(landingDate);
            }
            return flights;
        }
        public IList<Flights> GetFlightsByParameters (DateTime landingDate, DateTime departureDate, long originCountry, long destCountry)
        {
            IList<Flights> flights = new List<Flights>();
            if (_flightDAO != null)
            {
                flights = _flightDAO.GetFlightsByParameters(landingDate,departureDate,originCountry,destCountry);
            }
            else
            {
                _flightDAO = new FlightsDAOPGSQL();
                flights = _flightDAO.GetFlightsByParameters(landingDate, departureDate, originCountry, destCountry);
            }
            return flights;
        }
        public IList<Flights> GetFlightsByOriginCountry(int countryCode)
        {
            IList<Flights> flights = new List<Flights>();
            if (_flightDAO != null)
            {
                flights = _flightDAO.GetFlightsByOriginCountry(countryCode);
            }
            else
            {
                _flightDAO = new FlightsDAOPGSQL();
                flights = _flightDAO.GetFlightsByOriginCountry(countryCode);
            }
            return flights;
        }

        // Add to interface
        public void SignUp(Customers customer)
        {
            int user_role = 3;
            if (_customerDAO != null)
            {
                if (customer.User.UserRole == 0)
                {
                    customer.User.UserRole = user_role;
                }
                _userDAO.Add(customer.User);
                List<Users> users = _userDAO.GetAll();
                Users createdUser = users[users.Count - 1];
                customer.UserId = createdUser.ID;
               
                _customerDAO.Add(customer);
                // check that user is created - if not throw error
            }
            else
            {
                _userDAO = new UsersDAOPGSQL();
                _userDAO.Add(customer.User);
                _customerDAO = new CustomersDAOPGSQL();
                _customerDAO.Add(customer);
            }
        }
        public void SignUpAirline(AirlineCompanies airline)
        {
            int user_role = 2;
            if(_waitingAirlinesDAO != null)
            {
                if(airline.User.UserRole== 0 )
                {
                    airline.User.UserRole = user_role;
                }
                _userDAO.Add(airline.User);
                List<Users> users = _userDAO.GetAll();
                Users createdUser = users[users.Count - 1];
                airline.UserId = createdUser.ID;
                _waitingAirlinesDAO.Add(airline);
            }
            else
            {
                _userDAO = new UsersDAOPGSQL();
                _userDAO.Add(airline.User);
                _waitingAirlinesDAO = new WaitingAirlinesDAOPGSQL();
                _waitingAirlinesDAO.Add(airline);
            }
        }
        public void SignUpAdmin(Administrator admin)
        {
            int user_role = 1;
            if (_adminDAO != null)
            {
                if (admin.User.UserRole == 0)
                {
                    admin.User.UserRole = user_role;
                }
                _userDAO.Add(admin.User);
                List<Users> users = _userDAO.GetAll();
                Users createdUser = users[users.Count - 1];
                admin.User_id = createdUser.ID;
                _adminDAO.Add(admin);
            }
            else
            {
                _userDAO = new UsersDAOPGSQL();
                _userDAO.Add(admin.User);
                _adminDAO = new AdministratorDAOPGSQL();
                _adminDAO.Add(admin);
            }
        }
    }
}
