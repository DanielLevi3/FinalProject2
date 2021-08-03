using System;
using System.Collections.Generic;

namespace FinalProject2
{
    public class LoginService : ILoginService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAirlineCompanyDAO _arilineDAO = new AirlineCompaniesDAOPGSQL();
        private ICustomerDAO _customerDAO = new CustomersDAOPGSQL();
        private IAdministratorDAO _adminDAO = new AdministratorDAOPGSQL();
        private IUserDAO _userDAO =new UsersDAOPGSQL();
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
                                        Administrator admin = administrators[b];
                                        admin.User = users[i];
                                        token.User = admin;
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
                                        AirlineCompanies air = airCompanies[b];
                                        air.User = users[i];
                                        token.User = air;
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
                                        Customers cus = customers[b];
                                        cus.User= users[i];
                                        token.User = cus;
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
                    Administrator a = new Administrator();
                    token.User = a;
                    facade = new LoggedInAdministratorFacade();
                }

            }
            catch(WrongCredentialsException ex)
            {
                log.Error($"Wrong credentials... Try again {ex}");
            }
            token = null;
            facade = new AnonymousUserFacade();
            return false;

        }
    }
}
