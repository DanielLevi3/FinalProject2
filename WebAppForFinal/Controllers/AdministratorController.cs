using AutoMapper;
using FinalProject2;
using FinalProject2.Classes;
using FinalProject2.DTO_s;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAppForFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles ="Administrator")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdministratorController : FlightControllerBase<Administrator>
    {
        private ILoggedInAdministratorFacade m_facade;
        private readonly IMapper m_mapper;

        public AdministratorController(ILoggedInAdministratorFacade adminFacade, IMapper mapper)
        { 
            m_facade = adminFacade;
            m_mapper = mapper;
        }
        private void AuthenticateAndGetTokenAndGetFacade(out
          LoginToken<Administrator> token_admin, out LoggedInAdministratorFacade facade)
        {
            token_admin = GetLoginToken();
            FacadeBase facade1;
            facade1= FlightCenterSystem.GetInstance.GetFacade(token_admin);
            facade = facade1 as LoggedInAdministratorFacade;
        }

            //  return CreatedAtRoute(nameof(GetTestByIdv1), new { id = id });
            //return new CreatedResult("/api/admin/getcompanybyid/" + company.Id, company);
      

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
        [HttpDelete("DeleteAdmin")]
        public async Task<ActionResult<Administrator>> DeleteAdmin([FromBody] Administrator admin)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.RemoveAdmin(token_admin, admin));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpDelete("DeleteCustomer")]
        public async Task<ActionResult<Administrator>> RemoveCustomer([FromBody] Customers customer)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.RemoveCustomer(token_admin, customer));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<Administrator>> GetAllCustomers()
        {
            IList<Customers> cus = new List<Customers>();
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);
            
            try
            {
                await Task.Run(() =>cus= facade.GetAllCustomers(token_admin));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok(JsonConvert.SerializeObject(cus));
        }
        
        [HttpGet("GetAirlineByID/{airlineID}")]
        public async Task<ActionResult<AirlineCompanies>> GetAirlineByID(int airlineID)
        {
            AirlineCompanies result = null;
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);
            try
            {
                result = await Task.Run(() => facade.GetAirlineById(token_admin,airlineID));
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

        [HttpGet("GetAdminByID/{adminID}")]
        public async Task<ActionResult<AirlineCompanies>> GetAdminByID(int adminID)
        {
            Administrator result = null;
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);
            try
            {
                result = await Task.Run(() => facade.GetAdministratorById(token_admin, adminID));
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
        [HttpGet("GetCustomerByID/{customerID}")]
        public async Task<ActionResult<AirlineCompanies>> GetCustomerByID(int customerID)
        {
            Customers result = null;
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);
            try
            {
                result = await Task.Run(() => facade.GetCustomerById(token_admin, customerID));
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
        [HttpPost("AddNewCustomer")]
        public async Task<ActionResult> AddNewCustomer([FromBody] Customers customer)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            { 
                await Task.Run(() => facade.CreateNewCustomer(token_admin, customer));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpPost("AddNewAdmin")]
        public async Task<ActionResult> AddNewAdmin([FromBody] Administrator admin)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateAdmin(token_admin, admin));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpPost("CreateTicket")]
        public async Task<ActionResult> CreateTicket([FromBody] Tickets ticket)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateNewTicket(token_admin, ticket));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpPut("UpadateAdmin")]
        public async Task<ActionResult> UpdateAdmin([FromBody] Administrator admin)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.UpdateAdmin(token_admin, admin));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpPut("UpadateAirline")]
        public async Task<ActionResult> UpadateAirline([FromBody] AirlineCompanies airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.UpdateAirlineDetails(token_admin, airline));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
        [HttpPut("UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer([FromBody] Customers customer)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.UpdateCustomerDetails(token_admin, customer));
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
