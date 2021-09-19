using FinalProject2;
using FinalProject2.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class FlightControllerBase<T> : ControllerBase where T : IUser
    {
        private AdministratorDAOPGSQL admin= new AdministratorDAOPGSQL();
        private AirlineCompaniesDAOPGSQL airline = new AirlineCompaniesDAOPGSQL();
        private CustomersDAOPGSQL customer = new CustomersDAOPGSQL();
        private UsersDAOPGSQL users = new UsersDAOPGSQL();
       
        protected LoginToken<T> GetLoginToken()
        {
            LoginToken<T> login_token = new LoginToken<T>();
            string jwtToken = Request.Headers["Authorization"].ToString();

            jwtToken = jwtToken.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var decodedJwt = jsonToken as JwtSecurityToken;

            string userName = decodedJwt.Claims.First(_ => _.Type == "username").Value;
            int id = Convert.ToInt32(decodedJwt.Claims.First(_ => _.Type == "userid").Value);
            int user_role = Convert.ToInt32(decodedJwt.Claims.First(_ => _.Type == "user_role").Value);
           
            if (user_role==1)
            {// need to figure out how to cast the login token to the user i want 
                Administrator a = admin.GetAdministratorByUserame(userName);
                //logintoken.user to get the user within with fileds and not null but should use a mapper to save some fileds
                a.User = users.GetById(id);
                login_token.User = (T)(a as IUser);
                return login_token;
            }
            else if (user_role == 2)
            {
                AirlineCompanies air = airline.GetAirlineByUserame(userName);
                air.User = users.GetById(id);
                login_token.User = (T)(air as IUser);
                return login_token;
            }
            else if (user_role == 3)
            {
                Customers cus = customer.GetCustomerByUserame(userName);
                cus.User = users.GetById(id);
                cus.UserId = cus.User.ID;
                login_token.User = (T)(cus as IUser);
                return login_token;
            }

            return login_token;
            //need to figure out how to get the all user(administrator/ airlinecompany / customer ) in to not get null fileds;
           
            //{
            //    User = new T()
            //    {
            //        User = new Users()
            //        {
            //            ID = id,
            //            UserName = userName,
            //            UserRole = user_role

            //        }
            //    }

            //};

           
        }
    }

}

/*
string jwtToken = Request.Headers["Authorization"].ToString();

jwtToken = jwtToken.Replace("Bearer ", "");

var handler = new JwtSecurityTokenHandler();
var jsonToken = handler.ReadToken(jwtToken);
var decodedJwt = jsonToken as JwtSecurityToken;

string userName = decodedJwt.Claims.First(_ => _.Type == "username").Value;
long id = Convert.ToInt64(decodedJwt.Claims.First(_ => _.Type == "mainUserId").Value);
long user_id = Convert.ToInt64(decodedJwt.Claims.First(_ => _.Type == "userid").Value);

LoginToken<T> login_token = new LoginToken<T>()
{
    User = new T()
    {
        Id = id,
        User_Id = user_id,
        Name = userName,
        Password = "no password. created from JWT"
    }
};
return login_token; */