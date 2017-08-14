using System;
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
            var userService = GetUserService(userRepositoryMock);

            await userService.RegisterAsync(Guid.NewGuid(), "useremail@emia.com", "login", "password", "user");
            //czy metoda add async na mocku wywolala sie raz
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.AtLeastOnce);
        }

        [Fact]
        public async Task calling_get_async_should_invoke_user_when_he_exists()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = GetUserService(userRepositoryMock);
            
            await userService.GetAsync("user1@email.pl");
            var user = new User(Guid.NewGuid(),"userl1@email.pl", "username1", "password1", "salt","user");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(user);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.AtLeastOnce());
        }

        [Fact]
        public async Task calling_get_async_should_invoke_user_when_he_dont_exists()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = GetUserService(userRepositoryMock);
            
            var respose = userService.GetAsync("thisisnotavalidemail").Result;
            // response should be null
            Assert.Null(respose);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.AtLeastOnce());
        }

        private UserService GetUserService(Mock<IUserRepository> userRepositoryMock)
        {
            var mapperMock = new Mock<IMapper>();
            var encrypter = new Mock<Encrypter>();
            var userService = new UserService(userRepositoryMock.Object, encrypter.Object, mapperMock.Object);
            return userService;
        }
    }
}