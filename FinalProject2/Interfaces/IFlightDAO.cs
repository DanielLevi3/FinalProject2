using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public interface IFlightDAO : IBasicDb<Flights>
    {
        Dictionary<Flights, int> GetAllFlightsVacancy();
        IList<Flights> GetFlightsByOriginCountry(long countryCode);
        IList<Flights> GetFlightsByDestinationCountry(long countryCode);
        IList<Flights> GetFlightsByDepatrureDate(DateTime departureDate);
        IList<Flights> GetFlightsByLandingDate(DateTime landingDate);
        IList<Flights> GetFlightsByCustomerId(long customer_id);
    }
}
