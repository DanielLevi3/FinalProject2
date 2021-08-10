using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.Interfaces
{
    public interface IWaitingAirlinesDAO: IBasicDb<AirlineCompanies>
    {
        AirlineCompanies GetWaitingAirlineByUserame(string name);
        List<AirlineCompanies> GetAllWaitingAirlinesByCountry(long countryId);
    }
}
