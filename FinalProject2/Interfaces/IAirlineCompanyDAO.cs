using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public interface IAirlineCompanyDAO : IBasicDb<AirlineCompanies>
    {
        AirlineCompanies GetAirlineByUserame(string name);
        List<AirlineCompanies> GetAllAirlinesByCountry(long countryId);
    }
}
