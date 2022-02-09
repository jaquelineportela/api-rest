﻿using System;
using System.Threading.Tasks;
using api_rest.Domain.Models;
using api_rest.Domain.Services;
using api_rest.Domain.Repositories;

namespace api_rest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> FirstOrDefaultAsync(String login, String password)
        {
            return await _userRepository.FirstOrDefaultAsync(login, password);
        }
    }
}
