﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public interface ILoggedInAdministratorFacade
    {
        IList<Customers> GetAllCustomers(LoginToken<Administrator> token);
        void CreateNewAirline(LoginToken<Administrator> token, AirlineCompanies airline);
        void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompanies airline);
        void RemoveAirline(LoginToken<Administrator> token, AirlineCompanies airline);
        void CreateNewCustomer(LoginToken<Administrator> token, Customers customer);
        void UpdateCustomerDetails(LoginToken<Administrator> token, Customers customer);
        void RemoveCustomer(LoginToken<Administrator> token, Customers customer);
        void CreateAdmin(LoginToken<Administrator> token, Administrator admin);
        void UpdateAdmin(LoginToken<Administrator> token, Administrator admin);
        void RemoveAdmin(LoginToken<Administrator> token, Administrator admin);
    }
}
