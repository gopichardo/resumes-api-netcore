using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity.Resume
{
    public interface IResume
    {
        IUser User { get; set; }
        List<IProffesion> Professions { get; set; }
        List<IProffesion> Professions { get; set; }
        List<ISkill> MainSkills { get; set; }
    }
}