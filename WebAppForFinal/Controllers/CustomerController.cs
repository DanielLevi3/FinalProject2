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
    [Authorize(Roles = "Customer")]
    public class CustomerController : FlightControllerBase<Customers>
    {
        private readonly IMapper m_mapper;
        public CustomerController(IMapper mapper)
        {
            m_mapper = mapper;
        }
        private void AuthenticateAndGetTokenAndGetFacade(out
                      LoginToken<Customers> token_customer, out LoggedInCustomerFacade facade)
        {
            token_customer = GetLoginToken();
            FacadeBase facade1;
            facade1 = FlightCenterSystem.GetInstance.GetFacade(token_customer);
            facade = facade1 as LoggedInCustomerFacade;
        }

        [HttpGet("getflight/{flightid}")]
        public async Task<ActionResult<Flights>> GetFlightById(int flightid)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customers>
                    token_customer, out LoggedInCustomerFacade facade);

            Flights result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightById(flightid));
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
        [HttpGet("GetAllFlight")]
        public async Task<ActionResult<Flights>> GetAllFlight()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customers>
                    token_customer, out LoggedInCustomerFacade facade);

            IList<Flights> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllMyFlights(token_customer));
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

        [HttpDelete("CancelTicket")]
        public async Task<ActionResult<Customers>> CancelTicket([FromBody] Tickets ticket)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customers>
                     token_customer, out LoggedInCustomerFacade facade);
            try
            {
                await Task.Run(() => facade.CancelTicket(token_customer, ticket));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpPost("CreateTicket")]
        public async Task<ActionResult<Customers>> CreateTicket([FromBody] Flights flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customers>
                     token_customer, out LoggedInCustomerFacade facade);
            try
            {
                await Task.Run(() => facade.PurchaseTicket(token_customer, flight));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpGet("GetCustomerDetails")]
        public async Task<ActionResult<Customers>> GetCustomerDetails()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customers>
                    token_customer, out LoggedInCustomerFacade facade);

            Customers c = new Customers();
            try
            {
                c = await Task.Run(() => facade.GetCustomerDetails(token_customer));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (c == null)
            {
                return StatusCode(204, "{ }");
            }
            return Ok(c);
        }
    }
}
