﻿using System;
using System.Collections.Generic;

namespace FinalProject2
{
    public class LoginService : ILoginService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAirlineCompanyDAO _arilineDAO;
        private ICustomerDAO _customerDAO;
        private IAdministratorDAO _adminDAO;
        private IUserDAO _userDAO;
        public bool TryLogin(string userName, string password, out LoginToken<IUser> token, out FacadeBase facade)
        {
            token = new LoginToken<IUser>();
            List<Users> users = _userDAO.GetAll();
            try
            {
                if(userName!="admin"&& password != "9999")
                { 
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].UserName == userName && users[i].Password == password)
                        {
                            if (users[i].UserRole == 1)
                            {

                                List<Administrator> administrators = _adminDAO.GetAll();
                                for (int b = 0; b < administrators.Count; b++)
                                {
                                    if (administrators[b].User_id == users[i].ID)
                                    {
                                        token.User = administrators[b];
                                        facade = new LoggedInAdministratorFacade();
                                        return true;
                                    }
                                }
                            }
                            else if (users[i].UserRole == 2)
                            {
                                List<AirlineCompanies> airCompanies = _arilineDAO.GetAll();
                                for (int b = 0; b < airCompanies.Count; b++)
                                {
                                    if (airCompanies[b].UserId == users[i].ID)
                                    {
                                        token.User = airCompanies[b];
                                        facade = new LoggedInAirlineFacade();
                                        return true;
                                    }
                                }
                            }
                            else if (users[i].UserRole == 3)
                            {
                                List<Customers> customers = _customerDAO.GetAll();
                                for (int b = 0; b < customers.Count; b++)
                                {
                                    if (customers[b].UserId == users[i].ID)
                                    {
                                        token.User = customers[b];
                                        facade = new LoggedInCustomerFacade();
                                        return true;
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    token.User = new Administrator();
                    facade = new LoggedInAdministratorFacade();
                }

            }
            catch(WrongCredentialsException ex)
            {
                log.Error($"Wrong credentials... Try again {ex}");
            }
            token = null;
            facade = null;
            return false;

        }
    }
}