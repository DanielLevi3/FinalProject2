using FinalProject2.DAO_s;
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
                    if(_adminDAO!=null)
                    _adminDAO.Add(admin);
                    else
                    {
                        _adminDAO = new AdministratorDAOPGSQL();
                        _adminDAO.Add(admin);
                    }
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
                if(_airlineDAO!= null)
              _airlineDAO.Add(airline);
                else
                {
                    _airlineDAO = new AirlineCompaniesDAOPGSQL();
                    _airlineDAO.Add(airline);
                }
            }
        }

        public void CreateNewCustomer(LoginToken<Administrator> token, Customers customer)
        {
            if(token !=null)
            {
                if(_customerDAO !=null)
                _customerDAO.Add(customer);
                else
                {
                    _customerDAO = new CustomersDAOPGSQL();
                    _customerDAO.Add(customer);
                }
            }
        }
        public void CreateNewUser(LoginToken<Administrator> token, Users users)
        {
            if (token != null)
            {
                if(_userDAO != null)
                {
                    _userDAO.Add(users);
                }
                else
                {
                    _userDAO = new UsersDAOPGSQL();
                    _userDAO.Add(users);
                }
            }
        }
        public void CreateNewTicket(LoginToken<Administrator> token, Tickets ticket)
        {
            if (token != null)
            {
                if(_ticketDAO!=null)
                _ticketDAO.Add(ticket);
                else
                {
                    _ticketDAO = new TicketsDAOPGSQL();
                    _ticketDAO.Add(ticket);
                }
            }
        }

        public IList<Customers> GetAllCustomers(LoginToken<Administrator> token)
        {
            IList<Customers> customers = new List<Customers>();
            if (token != null)
            {
                if (_customerDAO != null)
                    customers = _customerDAO.GetAll();
                else
                {
                    _customerDAO = new CustomersDAOPGSQL();
                    customers = _customerDAO.GetAll();
                }
            }
            return customers;
        }

        public void RemoveAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if ( token != null)
            {
                if( token.User.Level==3)
                {
                    if(_adminDAO!=null)
                    _adminDAO.Remove(admin.ID);
                    else
                    {
                        _adminDAO = new AdministratorDAOPGSQL();
                        _adminDAO.Remove(admin.ID);
                    }
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
                    if(_airlineDAO!=null)
                    _airlineDAO.Remove(airline.ID);
                    else
                    {
                        _airlineDAO = new AirlineCompaniesDAOPGSQL();
                        _airlineDAO.Remove(airline.ID);
                    }
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
                    if(_customerDAO!=null)
                    _customerDAO.Remove(customer.ID);
                    else
                    {
                        _customerDAO = new CustomersDAOPGSQL();
                        _customerDAO.Remove(customer.ID);
                    }
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
                    if(_adminDAO!=null)
                    _adminDAO.Update(admin);
                    else
                    {
                        _adminDAO = new AdministratorDAOPGSQL();
                        _adminDAO.Update(admin);
                    }
                }
                else
                    Console.WriteLine("Your level of administration is too low, must be level 3 to update administrator");
            }
        }

        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompanies airline)
        {
            if(token!= null)
            {
                if(_airlineDAO!=null)
                _airlineDAO.Update(airline);
                else
                {
                    _airlineDAO = new AirlineCompaniesDAOPGSQL();
                    _airlineDAO.Update(airline);
                }
            }
        }

        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customers customer)
        {
            if(token!=null)
            {
                if(_customerDAO!=null)
                _customerDAO.Update(customer);
                else
                {
                    _customerDAO = new CustomersDAOPGSQL();
                    _customerDAO.Update(customer);
                }
            }
        }
        public AirlineCompanies GetAirlineById(LoginToken<Administrator> token, int id)
        {
            AirlineCompanies air = new AirlineCompanies();
            if (token != null)
            {
                if (_airlineDAO != null)
                    air = _airlineDAO.GetById(id);
                else
                {
                    _airlineDAO = new AirlineCompaniesDAOPGSQL();
                    air = _airlineDAO.GetById(id);
                }
            }
            return air;
        }
        public Customers GetCustomerById(LoginToken<Administrator> token, int id)
        {
            Customers c = new Customers();
            if (token != null)
            {
                if (_customerDAO != null)
                    c = _customerDAO.GetById(id);
                else
                {
                    _customerDAO = new CustomersDAOPGSQL();
                    c = _customerDAO.GetById(id);
                }
            }
            return c;
        }
        public Administrator GetAdministratorById(LoginToken<Administrator> token, int id)
        {
            Administrator a = new Administrator();
            if (token != null)
            {
                if (_adminDAO!= null)
                    a = _adminDAO.GetById(id);
                else
                {
                    _adminDAO = new AdministratorDAOPGSQL();
                    a = _adminDAO.GetById(id);
                }
            }
            return a;
        }
        public void AddAirlineToWaitingTable(LoginToken<Administrator> token, AirlineCompanies airline)
        {
            if (token != null)
            {
                if (_waitingAirlinesDAO != null)
                    _waitingAirlinesDAO.Add(airline);
                else
                {
                    _waitingAirlinesDAO = new WaitingAirlinesDAOPGSQL();
                    _waitingAirlinesDAO.Add(airline);
                }
            }
        }
        public AirlineCompanies GetWaitingAirlineById(LoginToken<Administrator> token, int id)
        {
            AirlineCompanies air = new AirlineCompanies();
            if (token != null)
            {
                if (_waitingAirlinesDAO != null)
                    air = _waitingAirlinesDAO.GetById(id);
                else
                {
                    _waitingAirlinesDAO = new WaitingAirlinesDAOPGSQL();
                    air = _waitingAirlinesDAO.GetById(id);
                }
            }
            return air;
        }
        public void RemoveWaitingAirline(LoginToken<Administrator> token, AirlineCompanies airline)
        {
            if (token != null)
            {
                if (token.User.Level >= 2)
                {
                    if (_waitingAirlinesDAO != null)
                        _waitingAirlinesDAO.Remove(airline.ID);
                    else
                    {
                        _waitingAirlinesDAO = new WaitingAirlinesDAOPGSQL();
                        _waitingAirlinesDAO.Remove(airline.ID);
                    }
                }
                else
                    Console.WriteLine("Your level of administration is too low,you must be level 2 or higher");
            }
        }
        public void UpdateWaitingAirlineDetails(LoginToken<Administrator> token, AirlineCompanies airline)
        {
            if (token != null)
            {
                if (_waitingAirlinesDAO != null)
                    _waitingAirlinesDAO.Update(airline);
                else
                {
                    _waitingAirlinesDAO = new WaitingAirlinesDAOPGSQL();
                    _waitingAirlinesDAO.Update(airline);
                }
            }
        }
        public IList<AirlineCompanies> GetAllWaitingAirlines(LoginToken<Administrator> token)
        {
            IList<AirlineCompanies> airlines = new List<AirlineCompanies>();
            if (token != null)
            {
                if (_waitingAirlinesDAO != null)
                    airlines = _waitingAirlinesDAO.GetAll();
                else
                {
                    _waitingAirlinesDAO = new WaitingAirlinesDAOPGSQL();
                    airlines = _waitingAirlinesDAO.GetAll();
                }
            }
            return airlines;
        }
    }
}
