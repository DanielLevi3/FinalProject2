using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    interface ILoggedInAirlineFacade
    {
        IList<Tickets> GetAllTickets(LoginToken<AirlineCompanies> token);
        IList<Tickets> GetAllFlights(LoginToken<AirlineCompanies> token);
        void CancelFlight(LoginToken<AirlineCompanies> token, Flights flight);
        void CreateFlight(LoginToken<AirlineCompanies> token, Flights flight);
        void UpdateFlight(LoginToken<AirlineCompanies> token, Flights flight);
        void ChangeMyPassword(LoginToken<AirlineCompanies> token, string oldPassword, string newPassword);
        void MofidyAirlineDetails(LoginToken<AirlineCompanies> token, AirlineCompanies airline);

    }
}
