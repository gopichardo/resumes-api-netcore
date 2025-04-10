using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Repository;

namespace Core.Usecase.Users
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public CreateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(User user)
        {
            try
            {
                await _userRepository.InsertUser(user);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}