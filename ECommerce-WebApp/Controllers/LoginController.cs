using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce_WebApp.Dtos;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

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
        public async Task<IActionResult> RegisterUser(UserDto userDto)
        {
            if(ModelState.IsValid)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:2622");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiVXNlciIsIm5iZiI6MTU2MzExNTMwNSwiZXhwIjoxNTYzNzIwMTA1LCJpYXQiOjE1NjMxMTUzMDUsImlzcyI6ImZhdGloY2Fua3VydGFyYW4uY29tIiwiYXVkIjoiZmF0aWgifQ.nTeglVKitMumNWGZ5NQeGruz8Hos8tTHpiWVwZwrRYs");
                var result = await client.GetStringAsync("/users/getall");
                
                
                Console.WriteLine(result);

                HttpContext.Session.Set("SessionId", Encoding.UTF8.GetBytes(HttpContext.Session.Id));
                return RedirectToAction(controllerName: "Home", actionName: "Index");

            }
            return View(viewName: "Index");

        }
    }
}