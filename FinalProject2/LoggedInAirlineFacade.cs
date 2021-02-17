using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        public void CancelFlight(LoginToken<AirlineCompanies> token, Flights flight)
        {
            throw new NotImplementedException();
        }

        public void ChangeMyPassword(LoginToken<AirlineCompanies> token, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void CreateFlight(LoginToken<AirlineCompanies> token, Flights flight)
        {
            throw new NotImplementedException();
        }

        public IList<Tickets> GetAllFlights(LoginToken<AirlineCompanies> token)
        {
            throw new NotImplementedException();
        }

        public IList<Tickets> GetAllTickets(LoginToken<AirlineCompanies> token)
        {
            throw new NotImplementedException();
        }

        public void MofidyAirlineDetails(LoginToken<AirlineCompanies> token, AirlineCompanies airline)
        {
            throw new NotImplementedException();
        }

        public void UpdateFlight(LoginToken<AirlineCompanies> token, Flights flight)
        {
            throw new NotImplementedException();
        }
    }
}
