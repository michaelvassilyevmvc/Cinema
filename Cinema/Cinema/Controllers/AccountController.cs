using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class AccountController:Controller
    {
        [HttpGet]
        public ActionResult LogIn()
        {
            var myLogin = new LogIn();
            return View("~/Views/LogIn.cshtml", myLogin);
        }

        [HttpPost]
        public ActionResult LogIn(LogIn loginResult)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/LogIn.cshtml", loginResult);
            }
            return View("~/Views/LoginResult.cshtml", loginResult);
        }
    }
}
