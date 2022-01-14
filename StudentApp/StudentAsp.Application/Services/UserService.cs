using AutoMapper;
using StudentASP.Domain.Models;
using StudentASP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        //private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
            //_mapper = mapper;
        }

        public async Task<int> Create(User newUser)
        {
            if (newUser is null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            return await _userRepository.Create(newUser);
        }
    }
}
