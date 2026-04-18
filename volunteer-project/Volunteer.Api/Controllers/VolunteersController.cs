using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Volunteer.Entities;
using Volunteer.Service;
using static DTOs.Class1;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController(IVolunteerService service) : ControllerBase
    {
        //private readonly IVolunteerService _service ;
        //public VolunteersController(IVolunteerService service)
        //{
        //    _service = service;
        //}
        // GET: api/<VolunteersController>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await service.GetAllVolunteers();
            return Ok(list);
        }

        // GET api/<VolunteersController>/5
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var v = await service.GetVolunteer(id);
            return Ok(v);
        }

        // POST api/<VolunteersController>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VolunteerPostDTO volunteer)
        {
            await service.AddVolunteer(volunteer);
            return Created();

        }
        //בעיה 
        //// PUT api/<VolunteersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string lastName)
        //{
        //    service.UpdateVolunteer(id, lastName);
        //}
        // PUT api/<VolunteersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string lastName)
        {
            await service.UpdateVolunteer(id, lastName);
            return Ok();
        }
        //// DELETE api/<VolunteersController>/5
        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    return Ok();
        //}
        //אין במחיקה כלום אין שום פעולה שמופעלת 
        // DELETE api/<VolunteersController>/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteVolunteer(id);
            return Ok();
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var volunteerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (volunteerId == null)
            {
                return Unauthorized();
            }
            var result = await service.GetVolunteerProfile(int.Parse(volunteerId));
            return Ok(result);
        }
        //*****
        [Authorize]
        [HttpPost("add-skill")]
        public async Task<IActionResult> AddSkill([FromBody] string skillName)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            var result = await service.addSkillTOVlunteer(userId, skillName);
            if (result == "Success")
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpGet("Skill-filter")]
        public async Task<ActionResult<ICollection<VolunteerDTO>>> GetAll([FromQuery] string? skill)
        {
            if (!string.IsNullOrEmpty(skill))
            {
                var filtered = await service.GetVolunteersBySkillAsync(skill);
                return Ok(filtered);
            }

            var all = await service.GetAllVolunteers();
            return Ok(all);
        }
    }
}
