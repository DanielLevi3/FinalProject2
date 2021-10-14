using AutoMapper;
using FinalProject2;
using FinalProject2.Classes;
using FinalProject2.DAO_s;
using FinalProject2.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "AirlineCompany")]
    public class AirlineController : FlightControllerBase<AirlineCompanies>
    {
        private readonly IMapper m_mapper;
        public AirlineController(IMapper mapper)
        {
            m_mapper = mapper;
        }
            private void AuthenticateAndGetTokenAndGetFacade(out
                     LoginToken<AirlineCompanies> token_airline, out LoggedInAirlineFacade facade)
            {
             token_airline = GetLoginToken();
                FacadeBase facade1;
                facade1 = FlightCenterSystem.GetInstance.GetFacade(token_airline);
                facade = facade1 as LoggedInAirlineFacade;
            }

//        IList<Flights> result = null;
//        List<FlightDTO> flightDTOs = new List<FlightDTO>();
//        Dictionary<long, long> mapFlightsToTickets = new Dictionary<long, long>();
//            try
//            {
//                result = await Task.Run(() => facade.GetAllMyFlights(token_customer));
//        mapFlightsToTickets = await Task.Run(() => facade.GetAllTicketsIdByFlightsId(token_customer, result));

//                foreach (Flights f in result)
//                {
//                    FlightDTO flightDTO = m_mapper.Map<FlightDTO>(f);
//        flightDTO.TicketId = mapFlightsToTickets[f.ID];
//                    flightDTOs.Add(flightDTO);
//                }
//}

        [HttpGet("GetAllFlights/")]
        public async Task<ActionResult<Flights>> GetAllFlights()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                    token_airline, out LoggedInAirlineFacade facade);

            IList<Flights> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllFlights(token_airline));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{ }");
            }
            return Ok(result);
        }
        [HttpGet("GetAllTickets/")]
        public async Task<ActionResult<Flights>> GetAllTickets()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                    token_airline, out LoggedInAirlineFacade facade);

            IList<Tickets> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllTickets(token_airline));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{ }");
            }
            return Ok(result);
        }
        [HttpGet("GetAirlineDetails")]
        public async Task<ActionResult<AirlineCompanies>> GetAirlineDetails()
        {
            AirlineCompanies result = null;
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                     token_airline, out LoggedInAirlineFacade facade);

            AirlineCompanyDTO airDTO = null;
            try
            {
                result = await Task.Run(() => facade.GetAirlineDetails(token_airline));
                airDTO = m_mapper.Map<AirlineCompanyDTO>(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{ }");
            }
            return Ok(JsonConvert.SerializeObject(airDTO));
        }

        [HttpDelete("CancelFlight")]
        public async Task<ActionResult<AirlineCompanies>> CancelFlight([FromBody] Flights flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                                 token_airline, out LoggedInAirlineFacade facade);
            try
            {
                //Flights flight = m_mapper.Map<Flights>(flightDTO);
                await Task.Run(() => facade.CancelFlight(token_airline, flight));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPost("CreateFlight")]
        public async Task<ActionResult> CreateFlight([FromBody] FlightDTO flightDTO)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                                 token_airline, out LoggedInAirlineFacade facade);

            try
            {
                Flights f = m_mapper.Map<Flights>(flightDTO);
                await Task.Run(() => facade.CreateFlight(token_airline, f));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPost("ChangeMyPassword")]
        public async Task<ActionResult> ChangeMyPassword([FromBody] AirlineCompanies airlineUser,string newPassword)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                                 token_airline, out LoggedInAirlineFacade facade);

            try
            {
                await Task.Run(() => facade.ChangeMyPassword(token_airline, airlineUser.User.Password,newPassword));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPut("UpdateAirlineDetails")]
        public async Task<ActionResult> UpdateAirlineDetails([FromBody] AirlineCompanyDTO airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                                 token_airline, out LoggedInAirlineFacade facade);

            try
            {
                AirlineCompanies air = m_mapper.Map<AirlineCompanies>(airline);
                await Task.Run(() => facade.ModifyAirlineDetails(token_airline, air));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpPut("UpdateFlight")]
        public async Task<ActionResult> UpdateFlight([FromBody] FlightDTO flightDTO)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                                 token_airline, out LoggedInAirlineFacade facade);

            try
            {
                //foreach (FlightDTO flight in flightDTO)
                //{
                    Flights f = m_mapper.Map<Flights>(flightDTO);
                    await Task.Run(() => facade.UpdateFlight(token_airline, f));
              //  }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpGet("GetAllFlightsByAirline/")]
        public async Task<ActionResult<Flights>> GetAllFlightsByAirline()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                    token_airline, out LoggedInAirlineFacade facade);

            IList<Flights> result = null;
            List<FlightDTO> flightDTOs = new List<FlightDTO>();
            try
            {
                result = await Task.Run(() => facade.GetAllFlightsByAirline(token_airline));
                foreach (Flights f in result)
                {
                    FlightDTO flight = m_mapper.Map<FlightDTO>(f);
                    flightDTOs.Add(flight);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{ }");
            }
            return Ok(JsonConvert.SerializeObject(flightDTOs));
        }
    }
}
