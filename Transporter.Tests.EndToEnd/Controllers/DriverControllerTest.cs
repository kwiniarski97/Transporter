using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Transporter.Core.Domain;
using Transporter.Infrastructure.DTO;
using Xunit;

namespace Transporter.Tests.EndToEnd.Controllers
{
    public class DriverControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task create_driver_when_user_of_this_id_exists_should_return_created_httpcode()
        {
            var email = "user1@email.pl";
            var userId = GetUserAsync($"{email}").Result.Id;
            var vehicle = new Vehicle("mercedes", "vito", 9);
            var payload = GetPayload(new Driver(Guid.NewGuid(), vehicle));
            var response = await Client.PostAsync("drivers", payload);

            Assert.Equal(response.StatusCode, HttpStatusCode.Created);
        }


        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}