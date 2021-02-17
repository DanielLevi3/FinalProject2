using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    abstract class FacadeBase
    {
        protected IAirlineCompanyDAO _airlineDAO;
        protected ICountryDAO _countryDAO;
        protected ICustomerDAO _customerDAO;
        protected IAdministratorDAO _adminDAO;
        protected IUserDAO _userDAO;
        protected IFlightDAO _flightDAO;
        protected ITicketsDAO _ticketDAO;
    }
}
