    using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade
    {
        public void CreateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            throw new NotImplementedException();
        }

        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompanies airline)
        {
            throw new NotImplementedException();
        }

        public void CreateNewCustomer(LoginToken<Administrator> token, Customers customer)
        {
            throw new NotImplementedException();
        }

        public IList<Customers> GetAllCustomers(LoginToken<Administrator> token)
        { 
            IList<Customers> customers = new List<Customers>();
            customers = _customerDAO.GetAll();
            return customers;
        }

        public void RemoveAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            throw new NotImplementedException();
        }

        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompanies airline)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customers customer)
        { 
            throw new NotImplementedException();
        }

        public void UpdateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            throw new NotImplementedException();
        }

        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompanies customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customers customer)
        {
            throw new NotImplementedException();
        }
    }
}
