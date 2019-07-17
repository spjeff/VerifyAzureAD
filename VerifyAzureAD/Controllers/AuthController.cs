using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Threading.Tasks;
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
    ///[Authorize]
    public class AuthController : ApiController
    {
        // GET api/values
        public async Task<string> Get()
        {
            // Parse parameters
            string username = "spjeff@spjeff.com";
            string password = "test";
            string clientId = "7974c676-2202-4459-b27d-d37f053dfdc4";
            string tenant = "spjeff.com";

            // Open connection
            string authority = "https://login.microsoftonline.com/" + tenant;
            string[] scopes = new string[] { "user.read" };
            IPublicClientApplication app;
            app = PublicClientApplicationBuilder.Create(clientId)
                  .WithAuthority(authority)
                  .Build();
            var securePassword = new SecureString();
            foreach (char c in password.ToCharArray())  // you should fetch the password
                securePassword.AppendChar(c);  // keystroke by keystroke
            var result = await app.AcquireTokenByUsernamePassword(scopes, username, securePassword).ExecuteAsync(); ;

            // Return
            return result.IdToken;
        }

        // GET api/values/5
        public string Get(int id)
        {
            DateTime now = DateTime.Now;
            return id.ToString() + " " + now.ToLongDateString() + " " + now.ToLongTimeString();
        }

        // POST api/values
        public void Put([FromBody]string value)
        {

        }

        // PUT api/values/5
        public async Task<string> Post(int id, [FromBody]AuthParams authparam)
        {
            // Parse parameters
            string username = authparam.username;
            string password = authparam.password;
            string clientId = authparam.clientid;
            string tenant = authparam.tenant;

            // Open connection
            string authority = "https://login.microsoftonline.com/" + tenant;
            string[] scopes = new string[] { "user.read" };
            IPublicClientApplication app;
            app = PublicClientApplicationBuilder.Create(clientId)
                  .WithAuthority(authority)
                  .Build();
            var securePassword = new SecureString();
            foreach (char c in password.ToCharArray())  // you should fetch the password
                securePassword.AppendChar(c);  // keystroke by keystroke
            var result = await app.AcquireTokenByUsernamePassword(scopes, username, securePassword).ExecuteAsync(); ;

            // Return
            return result.IdToken;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    // Parameters
    public class AuthParams
    {
        public string tenant;
        public string clientid;
        public string username;
        public string password;
    }
}
