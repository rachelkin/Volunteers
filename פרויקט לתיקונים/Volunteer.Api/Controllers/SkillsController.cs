using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositoryy;
using Volunteer.Entities;

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController(IVolunteerService service) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] string skillName)
        {
            var result = await service.CreateNewSkillAsync(skillName);

            if (result == null)
            {
                return BadRequest("Skill already exists or could not be created.");
            }
            return Ok(result);
        }
    }
}
