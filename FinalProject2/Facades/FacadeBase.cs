using FinalProject2.DAO_s;
using FinalProject2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public abstract class FacadeBase
    {
        protected IAirlineCompanyDAO _airlineDAO = new AirlineCompaniesDAOPGSQL();
        protected ICountryDAO _countryDAO = new CountryDAOPGSQL();
        protected ICustomerDAO _customerDAO = new CustomersDAOPGSQL();
        protected IAdministratorDAO _adminDAO = new AdministratorDAOPGSQL();
        protected IUserDAO _userDAO = new UsersDAOPGSQL();
        protected IFlightDAO _flightDAO = new FlightsDAOPGSQL();
        protected ITicketsDAO _ticketDAO = new TicketsDAOPGSQL();
        protected IWaitingAirlinesDAO _waitingAirlinesDAO = new WaitingAirlinesDAOPGSQL();
    }
}
