using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Resume
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public List<Proffesion> Professions { get; set; }
        public List<Skill> MainSkills { get; set; }
    }
}