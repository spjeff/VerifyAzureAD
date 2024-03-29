using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace VerifyAzureAD.Controllers
{
    // CORS - Enable HTTP calls from any source URL
	//      - To allow specific caller DNS domains only use this syntax:
	//        (origins: "http://domain1, http://domain1",
    [EnableCors(origins: "*",
        headers: "*",
        methods: "*",
        SupportsCredentials = true)]
    [Authorize]
    public class HelloController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            DateTime now = DateTime.Now;
            return new string[] { "Hello", now.ToLongDateString() + " " + now.ToLongTimeString() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            DateTime now = DateTime.Now;
            return id.ToString() + " " + now.ToLongDateString() + " " + now.ToLongTimeString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
