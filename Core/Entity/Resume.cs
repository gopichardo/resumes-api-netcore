using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Resume
    {
        public Guid Id { get; set; }
        public required User User { get; set; }        
        public ICollection<ResumeSkill>? ResumeSkills { get; set; }
        
    }
}