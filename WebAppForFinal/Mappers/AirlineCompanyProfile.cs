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
        public AirlineCompanyProfile()
        {
            // read from db or cache
            Dictionary<long, string> map_countryid_to_name = new Dictionary<long, string>()
            {
                { 1, "Israel" }
            };

            // 1. auto each with SAME NAME will be mapped from one object to another
            // 2. you can customize the mappings!
            CreateMap<AirlineCompanies, AirlineCompanyDTO>()
                .ForMember(dest => dest.CountryName,
                            opt => opt.MapFrom(src => map_countryid_to_name[src.CountryId]))
                .ForMember(dest => dest.CompanyName,
                            opt => opt.MapFrom(src => src.Name));
        }

    }
}
