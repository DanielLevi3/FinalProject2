using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    interface IAnonymousUserFacade
    {
        IList<Flights> GetAllFlights();
        IList<AirlineCompanies> GetAllAirlineCompanies();
        Dictionary<Flights, int> GetAllFlightsVacancy();
        Flights GetFlightById(int id);
        IList<Flights> GetFlightsByOriginCountry(int countryCode);
        IList<Flights> GetFlightsByDestinationCountry(int countryCode);
        IList<Flights> GetFlightsByDepatrureDate(DateTime departureDate);
        IList<Flights> GetFlightsByLandingDate(DateTime landingDate);
    }
}
