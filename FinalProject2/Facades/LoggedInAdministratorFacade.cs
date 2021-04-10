    using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade
    {
        public void CreateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if(token != null)
            {
                if (token.User.Level == 3)
                {
                    _adminDAO.Add(admin);
                }
                else
                {
                    Console.WriteLine("Your level of administration is too low, must be level 3 to add administrator");
                }
            }
        }

        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompanies airline)
        {
            if(token != null)
            {
              _airlineDAO.Add(airline);
            }
        }

        public void CreateNewCustomer(LoginToken<Administrator> token, Customers customer)
        {
            if(token !=null)
            {
                _customerDAO.Add(customer);
            }
        }
        public void CreateNewUser(LoginToken<Administrator> token, Users users)
        {
            if (token != null)
            {
                _userDAO.Add(users);
            }
        }
        public void CreateNewTicket(LoginToken<Administrator> token, Tickets ticket)
        {
            if (token != null)
            {
                _ticketDAO.Add(ticket);
            }
        }

        public IList<Customers> GetAllCustomers(LoginToken<Administrator> token)
        {
            IList<Customers> customers = new List<Customers>();
            if (token != null)
            { 
                customers = _customerDAO.GetAll();
            }
            return customers;
        }

        public void RemoveAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if ( token != null)
            {
                if( token.User.Level==3)
                {
                    _adminDAO.Remove(admin.ID);
                }
                else
                    Console.WriteLine("Your level of administration is too low, must be level 3 to remove administrator");
            }
        }

        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompanies airline)
        {
            if(token!=null)
            {
                if(token.User.Level>=2)
                {
                    _airlineDAO.Remove(airline.ID);
                }
                else
                    Console.WriteLine("Your level of administration is too low,you must be level 2 or higher");
            }
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customers customer)
        {
            if(token!=null)
            {
                if(token.User.Level>=2)
                {
                    _customerDAO.Remove(customer.ID);
                }
                else
                    Console.WriteLine("Your level of administration is too low,you must be level 2 or higher");
            }
        }

        public void UpdateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if(token!=null)
            {
                if(token.User.Level==3)
                {
                    _adminDAO.Update(admin);
                }
                else
                    Console.WriteLine("Your level of administration is too low, must be level 3 to update administrator");
            }
        }

        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompanies airline)
        {
            if(token!= null)
            {
                _airlineDAO.Update(airline);
            }
        }

        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customers customer)
        {
            if(token!=null)
            {
                _customerDAO.Update(customer);
            }
        }
    }
}
