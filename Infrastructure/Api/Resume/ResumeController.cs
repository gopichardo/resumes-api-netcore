using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Resume
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetResume()
        {
            // Simulate fetching resume data
            var resumeData = new
            {
                Name = "John Doe",
                Experience = new List<string> { "Software Engineer", "Project Manager" },
                Skills = new List<string> { "C#", "ASP.NET", "JavaScript" }
            };

            return Ok(resumeData);
        }
    }
}