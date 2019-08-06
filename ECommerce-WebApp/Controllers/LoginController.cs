using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce_WebApp.Dtos;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using ECommerce_WebApp.Helpers;
using Newtonsoft.Json;

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
            if (ModelState.IsValid)
            {

                var client = new HttpClient();
                client.BaseAddress = new Uri(PublicConstants.apiURL);
              //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiVXNlciIsIm5iZiI6MTU2NTA0NjM3MiwiZXhwIjoxNTY1NjUxMTcyLCJpYXQiOjE1NjUwNDYzNzIsImlzcyI6ImZhdGloY2Fua3VydGFyYW4uY29tIiwiYXVkIjoiZmF0aWgifQ.icJzwuT0JGEBsydQixqAndjeOtvOwAlcDj3cdP-oGKw");
               

                StringContent content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
                using (var registerResponse = await client.PostAsync("/users/register", content))
                {
                    if (registerResponse.IsSuccessStatusCode == true)
                    {
                        string apiResponse = await registerResponse.Content.ReadAsStringAsync();
                        
                        HttpContext.Session.Set("SessionId", Encoding.UTF8.GetBytes(HttpContext.Session.Id));
                            
                        return RedirectToAction(controllerName: "Home", actionName: "Index");
                    }
                    else
                    {
                      var errorMessage =  JsonConvert.DeserializeObject<ErrorDto>(registerResponse.Content.ReadAsStringAsync().Result);
                        

                    }
                }
            


            }
            return View(viewName: "Index");

        }
    }
}