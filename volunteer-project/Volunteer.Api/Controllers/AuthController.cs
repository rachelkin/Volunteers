using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volunteer.Entities;
using Volunteer.Service;

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IVolunteerService volunteerService,JwtService jwtService) : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(LoginDto user)
        {
            //בדיקה האם המייל והסיסמא תואמים אם כן נחזיר את המשתש
            var volunteer=volunteerService.ValidateUser(user);
            if(volunteer==null)
            {
                return Unauthorized();
            }
            //יצירת תוקן
            var token=jwtService.GenerateToken(volunteer);
             return Ok(token);
            //החזרת התוקן למשתמש

        }
            
    }
}
