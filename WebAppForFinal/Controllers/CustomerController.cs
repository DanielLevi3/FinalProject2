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
    public class CustomerController : ControllerBase
    {
        /*
        private void AuthenticateAndGetTokenAndGetFacade(out
           LoginToken<Customers> token_customer, out LoggedInCustomerFacade facade)
        {
            var a= GlobalConfig.GetConn;

            ILoginToken token;
            LoginService loginService = new LoginService();
            loginService.TryLogin("AsafCohen", "asafcohen", out token);

            token_customer = token as LoginToken<Customers>;
            facade = FlightCenterSystem.GetInstance.(token_customer) as LoggedInCustomerFacade;
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
        */
    }
}
