using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IAEW_ApiRest_App.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class CallBack : ControllerBase
    {
 
        // GET: api/callback/3
        [HttpGet("{code}")]
        public IActionResult Get(int code)
        {
            return Ok();
        }       
    }
}