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
    public class AdministratorController : ControllerBase
    {
        private void AuthenticateAndGetTokenAndGetFacade(out
          LoginToken<Administrator> token_admin, out LoggedInAdministratorFacade facade)
        {
            FacadeBase facade1;
            LoginToken<IUser> token;
            LoginService loginService = new LoginService();
            loginService.TryLogin("AsafCohen", "asafcohen", out token,out facade1);

            token_admin =(IUser)token as LoginToken<Administrator>;
            facade = FlightCenterSystem.GetInstance.GetFacade(token_admin) as LoggedInAdministratorFacade;
        }

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

        // POST api/<AdminController>
        [HttpPost("AddNewAirline")]
        public async Task<ActionResult> AddNewAirline([FromBody] AirlineCompanies airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateNewAirline(token_admin, airline));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        
    }
}
