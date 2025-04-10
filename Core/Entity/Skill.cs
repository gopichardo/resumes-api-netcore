using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Skill
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<ResumeSkill>? ResumeSkills { get; set; }
    }
}