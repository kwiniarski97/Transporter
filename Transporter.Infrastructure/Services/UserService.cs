using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task RegisterAsync(string email, string userName, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email {email}, already exists.");
            }
            //TODO usunac po zrobieniu szyfrowania
            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, userName, password, salt);
            await _userRepository.AddAsync(user);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user =  await _userRepository.GetAsync(email);
            //map user to user dto from user OBJ
            return _mapper.Map<User, UserDto>(user);
        }
    }
}