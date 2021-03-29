using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.Classes
{
   public class FlightCenterSystem
    {
        private static FlightCenterSystem _Instance;
        private static object key = new object();
        public LoginService _loginService = new LoginService();
        
        public static FlightCenterSystem GetInstance()
        {
            if (_Instance == null)
            {
                lock (key)
                {
                    if (_Instance == null)
                    {
                        _Instance = new FlightCenterSystem();
                    }
                }
            }
            return _Instance;
        }
        private FlightCenterSystem()
        {
            
        }
        public FacadeBase GetFacade<T>(LoginToken<T> token) where T : IUser
        {
            if (typeof(T) == typeof(Administrator))
                return new LoggedInAdministratorFacade();
            else if (typeof(T) == typeof(Customers))
                return new LoggedInCustomerFacade();
            else if (typeof(T) == typeof(AirlineCompanies))
                return new LoggedInAirlineFacade();
            else 
                return new AnonymousUserFacade();
        }
       

    }
}
