using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce_WebApp.Dtos;
using System.Text;

namespace ECommerce_WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterUser(UserDto userDto)
        {
            if(ModelState.IsValid)
            {
                HttpContext.Session.Set("SessionId", Encoding.UTF8.GetBytes(HttpContext.Session.Id));
                return RedirectToAction(controllerName: "Home", actionName: "Index");

            }
            return View(viewName: "Index");

        }
    }
}