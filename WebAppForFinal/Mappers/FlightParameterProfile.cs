using AutoMapper;
using FinalProject2;
using FinalProject2.Classes;
using FinalProject2.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForFinal.Mappers
{
    public class FlightParameterProfile : Profile
    {
        static Dictionary<string, long> map_country_name_to_id = new Dictionary<string, long>();
        static Dictionary<long, string> map_country_id_to_name = new Dictionary<long, string>();


        CountryDAOPGSQL countryDAOPGSQL = new CountryDAOPGSQL();
        public FlightParameterProfile()
        {
            List<Country> countries = countryDAOPGSQL.GetAll();
            foreach (Country country in countries)
            {
                map_country_id_to_name.Add(country.ID, country.Name);
                map_country_name_to_id.Add(country.Name, country.ID);
            }
            CreateMap<FlightParameters, FlightParametersDTO>()
          .ForMember(dest => dest.OriginCountryName, opt => opt.MapFrom(src => map_country_id_to_name[src.OriginCountryId]))
          .ForMember(dest => dest.DestinationCountryName, opt => opt.MapFrom(src => map_country_id_to_name[src.DestinationCountryId]))
          .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(src => src.DepartureTime))
          .ForMember(dest => dest.LandingTime, opt => opt.MapFrom(src => src.LandingTime)).ReverseMap()
                .ForMember(dest => dest.OriginCountryId, opt => opt.MapFrom(src => map_country_name_to_id[src.OriginCountryName]))
                .ForMember(dest => dest.DestinationCountryId, opt => opt.MapFrom(src => map_country_name_to_id[src.DestinationCountryName]));


        }

    }
}