using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using ECommerce_WebApp.Dtos;

namespace ECommerce_WebApp.Helpers
{
    public class RequestHelper
    {
        /// <summary>
        /// Data must be a model instance, token is required 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="address"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> apiCallAsync(object data, string address, string token, HttpMethod httpMethod)
        {
            if (token != string.Empty && data != null && address != string.Empty && (httpMethod == HttpMethod.Get || httpMethod == HttpMethod.Post))
                {
                if (httpMethod == HttpMethod.Get)
                {
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(PublicConstants.apiURL);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                   
                    var response = await client.GetAsync(address);
                    
                    if(response.IsSuccessStatusCode == true)
                    { return response.Content.ReadAsStringAsync().Result; }
                   
                    //var  = JsonConvert.DeserializeObject<UserDto>(await client.GetStringAsync(address));
                    return null;
                }
                if(httpMethod == HttpMethod.Post)
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else return null;
        }
        

    }
}
