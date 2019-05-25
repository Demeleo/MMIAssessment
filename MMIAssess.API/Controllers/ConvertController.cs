using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMIAssess.Core.Models;

namespace MMIAssess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{type}/{from}/{to}/{value:decimal}")]
        public ActionResult<string> Get(string type, string from, string to, decimal value)
        {
            return Ok(new ConversionRequest(type, from, to, value).Convert());
        }
    }
}