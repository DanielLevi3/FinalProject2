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
        
        private void AuthenticateAndGetTokenAndGetFacade(out
         LoginToken<AirlineCompanies> token_airline, out LoggedInAirlineFacade facade)
        {

            FacadeBase facade1;
            LoginToken<IUser> token;
            FlightCenterSystem.GetInstance._loginService.TryLogin("Danilev", "0123456", out token, out facade1);

           

            token_airline = (IUser)token as LoginToken<AirlineCompanies>;
            facade1 = FlightCenterSystem.GetInstance.GetFacade(token_airline);
            facade = facade1 as LoggedInAirlineFacade;
        }

        [HttpGet("getallflights/")]
        public async Task<ActionResult<Flights>> GetAllFlights()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompanies>
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
       
    }
}
