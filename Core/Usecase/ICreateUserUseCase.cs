using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Repository;

namespace Core.Usecase
{
    public interface ICreateUserUseCase
    {
        Task ExecuteAsync(User user);
    }
}