using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Usecase.Users
{
    public interface IQueryAllUsersUseCase
    {
        Task<IEnumerable<User>> QueryAllAsync();
    }
}