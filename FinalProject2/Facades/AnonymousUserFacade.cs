using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class AnonymousUserFacade : FacadeBase,IAnonymousUserFacade
    {
        public IList<AirlineCompanies> GetAllAirlineCompanies()
        {
            IList<AirlineCompanies> airlineCompanies= _airlineDAO.GetAll();
            return airlineCompanies;
        }

        public IList<Flights> GetAllFlights()
        {
            IList<Flights> flights = _flightDAO.GetAll();
            return flights;
        }

        public Dictionary<Flights, int> GetAllFlightsVacancy()
        {
            Dictionary<Flights, int> flightVacancy =_flightDAO.GetAllFlightsVacancy();
            return flightVacancy;
        }

        public Flights GetFlightById(int id)
        {
            Flights f = _flightDAO.GetById(id);
            return f;
        }

        public IList<Flights> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            IList<Flights> flights = _flightDAO.GetFlightsByDepatrureDate(departureDate);
            return flights;
        }

        public IList<Flights> GetFlightsByDestinationCountry(int countryCode)
        {
            IList<Flights> flights = _flightDAO.GetFlightsByDestinationCountry(countryCode);
            return flights;
        }

        public IList<Flights> GetFlightsByLandingDate(DateTime landingDate)
        {
            IList<Flights> flights = _flightDAO.GetFlightsByLandingDate(landingDate);
            return flights;
        }

        public IList<Flights> GetFlightsByOriginCountry(int countryCode)
        {
            IList<Flights> flights = _flightDAO.GetFlightsByOriginCountry(countryCode);
            return flights;
        }
    }
}
