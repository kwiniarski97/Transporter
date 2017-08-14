using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Transporter.Infrastructure.Commends.Users;
using Transporter.Infrastructure.DTO;
using Xunit;

namespace Transporter.Tests.EndToEnd.Controllers
{
    public class UserControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@email.pl";
            var user = await GetUserAsync(email);
            Assert.Equal(user.Email, email);
        }

        [Fact]
        public async Task given_invalid_email_should_return_404_error()
        {
            var email = "thisemailcantexist";
            var response = await Client.GetAsync($"users/{email}");
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_should_create_new_user()
        {
            var userRequest = new CreateUser
            {
                Email = "testemail1@email.pl",
                Username = "testusername",
                Password = "secrettest"
            };
            var payload = GetPayload(userRequest);
            var response = await Client.PostAsync("users", payload);

            Assert.Equal(response.StatusCode, HttpStatusCode.Created);
            Assert.Equal(response.Headers.Location.ToString(), $"users/{userRequest.Email}");

            var user = await GetUserAsync(userRequest.Email);
            Assert.Equal(userRequest.Email, user.Email);
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