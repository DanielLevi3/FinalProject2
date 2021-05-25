using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.Classes
{
   public class FlightCenterSystem
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static FlightCenterSystem _Instance;
        private static object key = new object();
        public LoginService _loginService = new LoginService();

        //public static FlightsCenterSystem Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            lock (key_singleton)
        //            {
        //                if (instance == null)
        //                {
        //                    instance = new FlightsCenterSystem();
        //                }
        //            }
        //        }
        //        return instance;
        //    }
        //}

        public static FlightCenterSystem GetInstance
        {
            get
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
        }
        private FlightCenterSystem()
        {
            
        }
        public FacadeBase GetFacade<T>(LoginToken<T> token) where T : IUser
        {
            try
            {
                if (typeof(T) == typeof(Administrator))
                    return new LoggedInAdministratorFacade();
                else if (typeof(T) == typeof(Customers))
                    return new LoggedInCustomerFacade();
                else if (typeof(T) == typeof(AirlineCompanies))
                    return new LoggedInAirlineFacade();
            }
            catch (Exception ex)
            {
                log.Error($"There is a problem to get facade check {ex}");
            }
                return new AnonymousUserFacade();
        }
       

    }
}
