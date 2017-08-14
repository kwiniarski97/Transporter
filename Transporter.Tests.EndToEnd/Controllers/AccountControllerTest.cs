using System.Net;
using System.Threading.Tasks;
using Transporter.Infrastructure.Commends.Users;
using Xunit;

namespace Transporter.Tests.EndToEnd.Controllers
{
    public class AccountControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task given_valid_current_and_new_password_it_should_be_changed()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "password",
                NewPassword = "Newpassw0rd"
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync("account/password", payload);
            Assert.Equal(response.StatusCode, HttpStatusCode.NoContent);
        }
    }
}