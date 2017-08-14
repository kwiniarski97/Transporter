using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Transporter.Api;

namespace Transporter.Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        public ControllerTestBase()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = Server.CreateClient(); //create api in memory
        }

        /// <summary>
        /// Add http headers
        /// </summary>
        /// <param name="data"> object</param>
        /// <returns>HTTP string content object</returns>
        protected StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}