using FinalProject2;
using FinalProject2.Classes;
using FinalProject2.DAO_s;
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
    public class AirlineController : ControllerBase
    {
        /*
        private void AuthenticateAndGetTokenAndGetFacade(out
         LoginToken<Customers> token_customer, out LoggedInCustomerFacade facade)
        {

            ILoginToken token;
            LoginService loginService = new LoginService();
            loginService.TryLogin("AsafCohen", "asafcohen", out token);

            token_customer = token as LoginToken<Customers>;
            facade = FlightCenterSystem.GetInstance.GetFacade(token_customer) as LoggedInCustomerFacade;
        }

        [HttpGet("getallflights/")]
        public async Task<ActionResult<Flights>> GetAllFlights()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

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
        */
    }
}
