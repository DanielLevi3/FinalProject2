using FinalProject2;
using FinalProject2.Classes;
using FinalProject2.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebAppForFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public async Task<ActionResult> GetToken([FromBody] UserDetailsDTO userDetails)
        {
            // 1) try login, with userDetails

            // await call FlightSystemCenter.Login(userDetails.Name, userDetails.Password);
            // 1 login failed
            //if (loginResult == false)
            //{

            bool loginSuccess;
            LoginToken<IUser> token;
            loginSuccess =FlightCenterSystem.GetInstance._loginService.TryLogin(userDetails.Name, userDetails.Password, out token, out _); 
           
            if (!loginSuccess)
            {
                return Unauthorized("login falied");
            }
            
            //return Unauthorized("login failed");
            //}
            // 2 success 
            //   facade, LoginToken<T>, role 

            // 2) create key
            // security key
            string securityKey =
       "this_is_our_supper_long_security_key_for_token_validation_project_2018_09_07$smesk.in";

            // symmetric security key
            var symmetricSecurityKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            // signing credentials
            var signingCredentials = new
                  SigningCredentials(symmetricSecurityKey,
                  SecurityAlgorithms.HmacSha256Signature);

            // 3) create claim for specific role
            // add claims
            var claims = new List<Claim>();
            if (token != null)
            {
               
                if (token.User.User.UserRole == 1)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                    claims.Add(new Claim("userid", token.User.User.ID.ToString()));
                    claims.Add(new Claim("username", token.User.User.UserName));
                    claims.Add(new Claim("user_role", token.User.User.UserRole.ToString()));
                }
                else if (token.User.User.UserRole == 2)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "AirlineCompany"));
                    claims.Add(new Claim("userid", token.User.User.ID.ToString()));
                    claims.Add(new Claim("username", token.User.User.UserName));
                    claims.Add(new Claim("user_role", token.User.User.UserRole.ToString()));

                }
                else if (token.User.User.UserRole == 3)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Customer"));
                    claims.Add(new Claim("userid", token.User.User.ID.ToString()));
                    claims.Add(new Claim("username", token.User.User.UserName));
                    claims.Add(new Claim("user_role", token.User.User.UserRole.ToString()));

                }
                else
                {
                    return Unauthorized("user not recognized");
                }
                
            }

            // 4) create token
           
            
                var jwtToken = new JwtSecurityToken(
                issuer: "issuer_of_flight_project",
                audience: "flight_project_users",
                expires: DateTime.Now.AddDays(14), // TTL configure
                signingCredentials: signingCredentials,
                claims: claims);
            
          
            // 5) return token
           return  Ok(new JwtSecurityTokenHandler().WriteToken(jwtToken));
           
        }
      
    }
}
