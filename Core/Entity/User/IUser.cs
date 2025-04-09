using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity.User
{
    public interface IUser
    {
        string Name { get; set; }
        string Email { get; set; }
    }
}