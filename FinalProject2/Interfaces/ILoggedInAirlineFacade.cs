﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public interface ILoggedInAirlineFacade
    {
        IList<Tickets> GetAllTickets(LoginToken<AirlineCompanies> token);
        IList<Flights> GetAllFlights(LoginToken<AirlineCompanies> token);
        void CancelFlight(LoginToken<AirlineCompanies> token, Flights flight);
        void CreateFlight(LoginToken<AirlineCompanies> token, Flights flight);
        void UpdateFlight(LoginToken<AirlineCompanies> token, Flights flight);
        void ChangeMyPassword(LoginToken<AirlineCompanies> token, string oldPassword, string newPassword);
        void ModifyAirlineDetails(LoginToken<AirlineCompanies> token, AirlineCompanies airline);
    }
}
