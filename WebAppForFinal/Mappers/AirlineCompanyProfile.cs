using AutoMapper;
using FinalProject2;
using FinalProject2.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForFinal.Mappers
{
    public class AirlineCompanyProfile : Profile
    {
        static Dictionary<long, string> map_country_id_to_name = new Dictionary<long, string>();
        static Dictionary<string, long> map_country_name_to_id = new Dictionary<string, long>();
        CountryDAOPGSQL countryDAOPGSQL = new CountryDAOPGSQL();
        public AirlineCompanyProfile()
        {
            List<Country> countries = countryDAOPGSQL.GetAll();
            foreach (Country country in countries)
            {
                map_country_id_to_name.Add(country.ID, country.Name);
            }
            List<Country> countries_names_to_id = countryDAOPGSQL.GetAll();
            foreach (Country country in countries)
            {
                map_country_name_to_id.Add(country.Name, country.ID);
            }

            CreateMap<AirlineCompanies, AirlineCompanyDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => map_country_id_to_name[src.CountryId]))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User)).ReverseMap()
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => map_country_name_to_id[src.CountryName]));

        }
    }
}
