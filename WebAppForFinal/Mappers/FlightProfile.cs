using AutoMapper;
using FinalProject2;
using FinalProject2.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForFinal.Mappers
{
    public class FlightProfile:Profile
    {
        static Dictionary<string, long> map_country_name_to_id = new Dictionary<string, long>();
        static Dictionary<long, string> map_country_id_to_name = new Dictionary<long, string>();
        static Dictionary<long, string> map_airlineCompany_id_to_name = new Dictionary<long, string>();
        static Dictionary<string,long> map_airlineCompany_name_to_id = new Dictionary<string,long>();

        AirlineCompaniesDAOPGSQL AirlineCompaniesDAOPGSQL = new AirlineCompaniesDAOPGSQL();
        CountryDAOPGSQL countryDAOPGSQL = new CountryDAOPGSQL();
        public FlightProfile()
        {
            List<AirlineCompanies> airlineCompanies = AirlineCompaniesDAOPGSQL.GetAll();
            foreach (AirlineCompanies airline in airlineCompanies)
            {
                map_airlineCompany_id_to_name.Add(airline.ID, airline.Name);
                map_airlineCompany_name_to_id.Add(airline.Name, airline.ID);
            }
            List<Country> countries = countryDAOPGSQL.GetAll();
            foreach (Country country in countries)
            {
                map_country_id_to_name.Add(country.ID, country.Name);
                map_country_name_to_id.Add(country.Name, country.ID);
            }
            CreateMap<Flights, FlightDTO>().ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.AirlineCompanyName, opt => opt.MapFrom(src => map_airlineCompany_id_to_name[src.AirlineCompanyId]))
                .ForMember(dest => dest.OriginCountryName, opt => opt.MapFrom(src => map_country_id_to_name[src.OriginCountryId]))
                .ForMember(dest => dest.DestinationCountryName, opt => opt.MapFrom(src => map_country_id_to_name[src.DestinationCountryId]))
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(src => src.DepartureTime))
                .ForMember(dest => dest.LandingTime, opt => opt.MapFrom(src => src.LandingTime))
                .ForMember(dest => dest.RemainingTickets, opt => opt.MapFrom(src => src.RemainingTickets)).ReverseMap()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.AirlineCompanyId, opt => opt.MapFrom(src => map_airlineCompany_name_to_id[src.AirlineCompanyName]))
                .ForMember(dest => dest.OriginCountryId, opt => opt.MapFrom(src => map_country_name_to_id[src.OriginCountryName]))
                .ForMember(dest => dest.DestinationCountryId, opt => opt.MapFrom(src => map_country_name_to_id[src.DestinationCountryName]));
        }
    }
}
