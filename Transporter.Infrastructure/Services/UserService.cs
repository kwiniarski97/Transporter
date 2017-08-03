using System;
using System.Threading;
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

        public void Register(string email, string userName, string password)
        {
            var user = _userRepository.Get(email);
            if (user != null)
            {
                throw new Exception($"User with email {email}, already exists.");
            }
            //TODO usunac po zrobieniu szyfrowania
            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, userName, password, salt);
            _userRepository.Add(user);
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);
            //map user to user dto from user OBJ
            return _mapper.Map<User, UserDto>(user);
        }
    }
}