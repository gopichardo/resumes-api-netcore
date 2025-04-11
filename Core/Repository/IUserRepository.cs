using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Repository
{
    public interface IUserRepository
    {
        Task InsertUser(User user);
        Task<User> GetUser(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}