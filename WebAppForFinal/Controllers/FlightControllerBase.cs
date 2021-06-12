﻿using FinalProject2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class FlightControllerBase<T> : ControllerBase where T : IUser, new()
    {
        protected LoginToken<T> GetLoginToken()
        {
            string jwtToken = Request.Headers["Authorization"];

            jwtToken = jwtToken.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var decodedJwt = jsonToken as JwtSecurityToken;

            string userName = decodedJwt.Claims.First(_ => _.Type == "username").Value;
            int id = Convert.ToInt32(decodedJwt.Claims.First(_ => _.Type == "userid").Value);

            LoginToken<T> login_token = new LoginToken<T>()
            {
                User = new T()
                {
                    Id = id,
                    UserName = userName,
                }
            };
            return login_token;
        }
    }

}