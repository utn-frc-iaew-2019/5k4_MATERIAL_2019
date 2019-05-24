using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace IAEW_ApiRest_App.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class CallBack : ControllerBase
    {

        // GET: api/callback
        [HttpGet]
        public IActionResult Get(string code, string scope, string authuser, string session_state, string prompt)
        {
            dynamic token = new
            {
                client_id = "105195994028-5i0265tl7cfod9lu1lfl3ef36p5r3t6q.apps.googleusercontent.com",
                client_secret = "-7vqcDW5P5NiX7kqODdNNdY8",
                grant_type = "authorization_code",
                redirect_uri = "http://localhost:65513/api/callback"
            };

            var client = new RestClient("https://www.googleapis.com/oauth2/v4/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"code={code}&client_id={token.client_id}&client_secret={token.client_secret}&grant_type={token.grant_type}&redirect_uri={token.redirect_uri}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Error obteniendo el access_token.");
                return Unauthorized();
            }

            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);

            return Ok(tokenResponse);
        }
    }
}