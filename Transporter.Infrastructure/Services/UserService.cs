using System;
using System.Collections.Generic;
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
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task RegisterAsync(Guid id, string email, string userName, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email {email}, already exists.");
            }
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(id, email, userName, hash, salt,role);
            await _userRepository.AddAsync(user);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user =  await _userRepository.GetAsync(email);
            //map user to user dto from user OBJ
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email {email}, doesn't exist.");
            }
            var hash = _encrypter.GetHash(password, user.Salt);

            if (user.Password == hash)
            {
                //LOGIN
                return;
            }
            throw new Exception("Invalid creditensials");
        }
        
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return  _mapper.Map<IEnumerable<User>,IEnumerable<UserDto>>(users);
        }
    }
}