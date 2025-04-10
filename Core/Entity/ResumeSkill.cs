using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class ResumeSkill
    {
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}