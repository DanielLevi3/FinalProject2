using System;
using System.Collections.Generic;

namespace FinalProject2
{
    class LoginService : ILoginService
    {
        private IAirlineCompanyDAO _arilineDAO;
        private ICustomerDAO _customerDAO;
        private IAdministratorDAO _adminDAO;
       
        public bool TryLogin(string userName, string password, out LoginToken<IUser> token, out FacadeBase facade)
        {
            token = new LoginToken<IUser>();
            UsersDAOPGSQL u = new UsersDAOPGSQL();
            List<Users> users = u.GetAll();
            try
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
            catch(WrongCredentialsException ex)
            {
                Console.WriteLine($"Wrong credentials... Try again {ex}");
            }
            token = null;
            facade = null;
            return false;

        }
    }
}
