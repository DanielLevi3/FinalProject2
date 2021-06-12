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
        private void AuthenticateAndGetTokenAndGetFacade(out
           LoginToken<Customers> token_customer, out LoggedInCustomerFacade facade)
        {
            
            LoginToken<IUser> token;
            FacadeBase facadeBase;

            FlightCenterSystem.GetInstance._loginService.TryLogin("Gid23", "01236", out token,out facadeBase);

            token_customer = (IUser)token as LoginToken<Customers>;
            facadeBase = FlightCenterSystem.GetInstance.GetFacade(token_customer);
            facade = facadeBase as LoggedInCustomerFacade;
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
       
    }
}
