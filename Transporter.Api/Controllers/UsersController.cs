using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Transporter.Infrastructure.Commends.Users;
using Transporter.Infrastructure.DTO;
using Transporter.Infrastructure.Services;

namespace Transporter.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public UserDto Get(string email) =>
            _userService.Get(email);


        [HttpPost("")]
        public void Post([FromBody]CreateUser request)
        {
            _userService.Register(request.Email, request.Username, request.Password);
        }
    }
    
}