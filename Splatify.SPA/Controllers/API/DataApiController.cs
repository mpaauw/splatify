using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Splatify.SPA.Models;

namespace Splatify.SPA.Controllers.API
{
    [RoutePrefix("api")]
    public class DataApiController : ApiController 
    {
        [HttpGet]
        [Route("test/{testId}")]
        public HttpResponseMessage GetTest(HttpRequestMessage request, int testId)
        {
            var test = "test!";

            return null;
        }
    }
}