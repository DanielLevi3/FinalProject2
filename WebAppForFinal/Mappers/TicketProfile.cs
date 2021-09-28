using AutoMapper;
using FinalProject2;
using FinalProject2.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForFinal.Mappers
{
    //    public class TicketProfile : Profile
    //    {
    //        static Dictionary<long, string> map_airlineCompany_id_to_name = new Dictionary<long, string>();
    //        AirlineCompaniesDAOPGSQL AirlineCompaniesDAOPGSQL = new AirlineCompaniesDAOPGSQL();
    //        public TicketProfile()
    //        {
    //            List<AirlineCompanies> airlineCompanies = AirlineCompaniesDAOPGSQL.GetAll();
    //            foreach (AirlineCompanies airline in airlineCompanies)
    //            {
    //                map_airlineCompany_id_to_name.Add(airline.ID, airline.Name);
    //            }
    //            CreateMap<Tickets, TicketDTO>().ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
    //              .ForMember(dest => dest.AirlineCompanyName, opt => opt.MapFrom(src => map_airlineCompany_id_to_name[src.AirlineCompanyId]))
    //             .ForMember(dest => dest.FlightId,opt => opt.MapFrom(src=>src.FlightID));
    //        }
    //    }
    //}
}