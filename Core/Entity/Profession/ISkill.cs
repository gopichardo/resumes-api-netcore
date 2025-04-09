using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity.Profession
{
    public interface ISkill
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}