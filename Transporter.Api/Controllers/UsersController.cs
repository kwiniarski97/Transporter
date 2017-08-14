﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Transporter.Infrastructure.Commends.Users;
using Transporter.Infrastructure.Services;

namespace Transporter.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = _userService.GetAllAsync();
            return Json(users);
        }
        
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user, new JsonSerializerSettings()); // without jsonserializersetting it doesnt work
        }

        //21.21
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Created($"users/{command.Email}", new object());
        }
        
    }
}