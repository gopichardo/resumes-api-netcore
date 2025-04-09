using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity.Profession
{
    public interface IProffesion
    {
        string Name { get; set; }
        string Description { get; set; }
        List<ISkill> Skills { get; set; }
    }
}