using AutoMapper;
using FinalProject2;
using FinalProject2.Classes;
using FinalProject2.DAO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("GetAirlineByID/{airlineID}")]
        public async Task<ActionResult<AirlineCompanies>> GetAirlineByID(int airlineID)
        {
            AirlineCompanies result = null;
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                     token_airline, out LoggedInAirlineFacade facade);

            try
            {
                result = await Task.Run(() => facade.GetAirlineById(token_airline, airlineID));
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

        [HttpDelete("CancelFlight")]
        public async Task<ActionResult<AirlineCompanies>> CancelFlight([FromBody] Flights flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                                 token_airline, out LoggedInAirlineFacade facade);
            try
            {
                await Task.Run(() => facade.CancelFlight(token_airline, flight));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPost("CreateFlight")]
        public async Task<ActionResult> CreateFlight([FromBody] Flights flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                                 token_airline, out LoggedInAirlineFacade facade);

            try
            {
                await Task.Run(() => facade.CreateFlight(token_airline, flight));
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
        public async Task<ActionResult> UpdateAirlineDetails([FromBody] AirlineCompanies airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                                 token_airline, out LoggedInAirlineFacade facade);

            try
            {
                await Task.Run(() => facade.ModifyAirlineDetails(token_airline, airline));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpPut("UpdateFlight")]
        public async Task<ActionResult> UpdateFlight([FromBody] Flights flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
                                 token_airline, out LoggedInAirlineFacade facade);

            try
            {
                await Task.Run(() => facade.UpdateFlight(token_airline, flight));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
    }
}
