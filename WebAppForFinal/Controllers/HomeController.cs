using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppForFinal.Models;

namespace WebAppForFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //return View();
            //  var res = System.IO.File.
            //         ReadAllText("wwwroot\\loginpage.html");
            //return Content(res, "text/html");
            var res = System.IO.File.
                     ReadAllText("Views\\login\\login.html");
            return Content(res, "text/html");
        }

        public ActionResult CustomerRegister()
        {
            var res = System.IO.File.
                ReadAllText("Views\\CustomerRegister\\customer.html");
            return Content(res, "text/html");
        }

        public ActionResult CustomerRegisterCSS()
        {
            var res = System.IO.File.
                ReadAllText("Views\\CustomerRegister\\customer.css");
            return Content(res, "text/css");
        }

        public ActionResult CustomerRegisterJs()
        {
            var res = System.IO.File.
                ReadAllText("Views\\CustomerRegister\\customer.js");
            return Content(res, "text/js");
        }

        public ActionResult AirlineRegister()
        {
            var res = System.IO.File.
                ReadAllText("Views\\AirlineRegister\\airline.html");
            return Content(res, "text/html");
        }
        public ActionResult AirlineRegisterJs()
        {
            var res = System.IO.File.
                ReadAllText("Views\\AirlineRegister\\airline.js");
            return Content(res, "text/js");
        }
        public ActionResult AirlineRegisterCSS()
        {
            var res = System.IO.File.
                ReadAllText("Views\\AirlineRegister\\airline.css");
            return Content(res, "text/css");
        }
       
        public ActionResult AdminRegister()
        {
            var res = System.IO.File.
                ReadAllText("Views\\AdminRegister\\admin.html");
            return Content(res, "text/html");
        }
        public ActionResult AdminRegisterJs()
        {
            var res = System.IO.File.
                ReadAllText("Views\\AdminRegister\\admin.js");
            return Content(res, "text/js");
        }

        public ActionResult AdminRegisterCSS()
        {
            var res = System.IO.File.
                ReadAllText("Views\\AdminRegister\\admin.css");
            return Content(res, "text/css");
        }

      

        public ActionResult AcceptPagePOST()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<html><body>");
            //foreach (var key in Request.Form.Keys)
            //{
            //    sb.Append($"<h1>{key} : {Request.Form[key]} </h1>");
            //}
            //sb.Append("</html>");
            ////return Content(sb.ToString());

            //if (Request.Form["password"].ToString().ToUpper() == Request.Form["username"].ToString().ToUpper())
            //{
            //    if (Request.Form["username"].ToString().ToUpper() == "admin".ToUpper())
            //    {
            //        var res = System.IO.File.
            //        ReadAllText("wwwroot\\adminpage.html");
            //        return Content(res, "text/html");
            //    }
            //    if(Request.Form["username"].ToString().ToUpper() == "airline".ToUpper())
            //    {
            //        var res = System.IO.File.
            //        ReadAllText("wwwroot\\airlinepage.html");
            //        return Content(res, "text/html");
            //    }
            //    if(Request.Form["username"].ToString().ToUpper() == "customer".ToUpper())
            //    {
            //        var res = System.IO.File.
            //        ReadAllText("wwwroot\\customerpage.html");
            //        return Content(res, "text/html");
            //    }
            //}
            //else
            //{
            //    //var res = System.IO.File.ReadAllText("wwwroot\\login\\login.html");
            //    //res = res + "<br><p style=\"color:red\">wrong password</p>";
            //    //return Content(res, "text/html");
            //    return View();
            //}
            return View();
        }

        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("<html><body>");
        //            foreach (var key in Request.Form.Keys)
        //            {
        //                sb.Append($"<h1>{key} : {Request.Form[key]} </h1>");
        //            }
        //    sb.Append("</html>");
        //            //return Content(sb.ToString(), "text/html");

        //            if (Request.Form["pwd"] != "1234")
        //            {
        //                return View("wrong");
        //}
        //            else
        //{
        //    return View("app");
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
