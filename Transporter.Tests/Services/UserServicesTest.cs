using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;
using Transporter.Infrastructure.Services;
using Xunit;

namespace Transporter.Tests.Services
{
    public class UserServicesTest
    {
        //TODO
        [Fact]
        public async Task calling_registerasync_should_register_one_user_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.RegisterAsync("useremail@emia.com", "login", "password");

            //czy metoda add async na mocku wywolala sie raz
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.AtLeastOnce);
        }
        //TODO nie validacja nie dziala sprawdza tylko czy wywoluje
        [Fact]
        public async Task calling_get_async_should_invoke_user_when_he_exists()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.GetAsync("email1@email.pl");
            
            var user = new User("email1@email.pl", "username1", "password1", "salt");
            
            
            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(user);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.AtLeastOnce());
        }
        //TODO nie validacja nie dziala sprawdza tylko czy wywoluje
        [Fact]
        public async Task calling_get_async_should_invoke_user_when_he_dont_exists()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            var respose = userService.GetAsync("thisisnotavalidemail").Result;
            // response should be null
            Assert.Null(respose);
//            userRepositoryMock.Setup(x => x.GetAsync("thisisnotavalidemail")).ReturnsAsync(() => user);    
            userRepositoryMock.Verify(x=> x.GetAsync(It.IsAny<string>()),Times.AtLeastOnce());
        }
    }
}