using AutoMapper;
using FinalProject2;
using FinalProject2.DTO_s;
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

    public class AnonymousController : ControllerBase
    {
        private AnonymousUserFacade facade = new AnonymousUserFacade();
        private readonly IMapper m_mapper;

        public AnonymousController( IMapper mapper)
        {
            m_mapper = mapper;
        }

        // GET: api/<AnonymousController>
        [HttpGet("getallairlinecompanies/")]
        public async Task<ActionResult<AirlineCompanies>> GetAllAirlineCompanies()
        {
           

            IList<AirlineCompanies> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllAirlineCompanies());
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

        [HttpGet("getallflights/")]
        public async Task<ActionResult<Flights>> GetAllFlights()
        {
            

            IList<Flights> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllFlights());
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

        [HttpGet("getflightbyid/{flightid}")]
        public async Task<ActionResult<Flights>> GetFlightById(int flightid)
        {

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

        [HttpGet("getairlinebyid/{airlineid}")]
        public async Task<ActionResult<AirlineCompanies>> GetAirlineById(int airlineid)
        {
            

            Flights result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightById(airlineid));
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

        //[HttpGet("getcustomerbyid/{customerid}")]
        //public async Task<ActionResult<Customers>> GetCustomerById(int customerid)
        //{
            

        //    Customers result = null;
        //    try
        //    {
        //        result = await Task.Run(() => facade.getc(customerid));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
        //    }
        //    if (result == null)
        //    {
        //        return StatusCode(204, "{ }");
        //    }
        //    return Ok(result);
        //}

        //[HttpGet("getadminbyid/{adminid}")]
        //public async Task<ActionResult<Customers>> GetAdminById(int adminid)
        //{
            

        //    Administrator result = null;
        //    try
        //    {
        //        result = await Task.Run(() => facade.GetAdminById(adminid));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
        //    }
        //    if (result == null)
        //    {
        //        return StatusCode(204, "{ }");
        //    }
        //    return Ok(result);
        //}

        //[HttpGet("getticketbyid/{ticketid}")]
        //public async Task<ActionResult<Tickets>> GetTicketById(int ticketid)
        //{
        //    Tickets result = null;
        //    try
        //    {
        //        result = await Task.Run(() => facade.get(ticketid));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
        //    }
        //    if (result == null)
        //    {
        //        return StatusCode(204, "{ }");
        //    }
        //    return Ok(result);
        //}

        [HttpGet("getflightsbyorigincountry/{countrycode}")]
        public async Task<ActionResult<Flights>> GetFlightsByOriginCountry(int countrycode)
        {
            IList<Flights> result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightsByOriginCountry(countrycode));
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


        [HttpGet("getflightsbydestinationcountry/{countrycode}")]
        public async Task<ActionResult<Flights>> GetFlightsByDestinationCountry(int countrycode)
        {
            IList<Flights> result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightsByDestinationCountry(countrycode));
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


        [HttpGet("getflightsbydeparturedate/{datetime}")]
        public async Task<ActionResult<Flights>> GetFlightsByDepartureDate(DateTime dateTime)
        {
            IList<Flights> result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightsByDepatrureDate(dateTime));
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


        [HttpGet("getflightsbylandingdate/{datetime}")]
        public async Task<ActionResult<Flights>> GetFlightsByLandingDate(DateTime dateTime)
        {
            IList<Flights> result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightsByLandingDate(dateTime));
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

        // POST api/<AnonymousController>
        [HttpPost("SignUp")]
        public async void SignUp([FromBody] Customers customer)
        {
            try
            {
                await Task.Run(() => facade.SignUp(customer));
                Ok();
            }
            catch (Exception ex)
            {
                StatusCode(400, $"{{error:\"{ex.Message}\"}}");
            }

        }

        [HttpPost("SignUpAirline")]
        public async void SignUpAirline([FromBody] AirlineCompanyDTO airline)

        {
            AirlineCompanies air1 = m_mapper.Map<AirlineCompanies>(airline);
            try
            {
                await Task.Run(() => facade.SignUpAirline(air1));
                Ok();
            }
            catch (Exception ex)
            {
                StatusCode(400, $"{{error:\"{ex.Message}\"}}");
            }

        }
        [HttpPost("SignUpAdmin")]
        public async void SignUpAdmin([FromBody] Administrator admin)
        {
            try
            {
                await Task.Run(() => facade.SignUpAdmin(admin));
                Ok();
            }
            catch (Exception ex)
            {
                StatusCode(400, $"{{error:\"{ex.Message}\"}}");
            }

        }

    }
}