using FinalProject2;
using FinalProject2.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAppForFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private void AuthenticateAndGetTokenAndGetFacade(out
          LoginToken<Administrator> token_admin, out LoggedInAdministratorFacade facade)
        {
            FacadeBase facade1;
            LoginToken<IUser> token;

            FlightCenterSystem.GetInstance._loginService.TryLogin("Danilev", "0123456", out token, out facade1);

            token_admin = (IUser)token as LoginToken<Administrator>;
            facade1 = FlightCenterSystem.GetInstance.GetFacade(token_admin);
            facade =facade1 as LoggedInAdministratorFacade;
        }


        [HttpDelete("DeleteAirline")]
        public async Task<ActionResult<Administrator>> RemoveAirline([FromBody] AirlineCompanies airlineCompany)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.RemoveAirline(token_admin, airlineCompany));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPost("AddNewUser")]
        public async Task<ActionResult> AddNewUser([FromBody] Users user)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateNewUser(token_admin, user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpPost("AddNewAirline")]
        public async Task<ActionResult> AddNewAirline([FromBody] AirlineUser airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                //await Task.Run(() => facade.CreateUser(token_admin, airline.UserDetails));
                await Task.Run(() => facade.CreateNewAirline(token_admin, airline.AirlineCompanyDetails));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        // POST api/<AdminController>
        //[HttpPost("AddNewAirline")]
        //public async Task<ActionResult> AddNewAirline([FromBody] AirlineCompanies airline)
        //{ 
        //    AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
        //            token_admin, out LoggedInAdministratorFacade facade);

        //    try
        //    {
        //        await Task.Run(() => facade.CreateNewAirline(token_admin, airline));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
        //    }

        //    return Ok();
        //}

    }
}
