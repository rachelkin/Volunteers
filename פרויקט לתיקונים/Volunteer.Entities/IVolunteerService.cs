using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTOs.Class1;

namespace Volunteer.Entities
{
    public interface IVolunteerService
    {
        Task AddVolunteer(VolunteerPostDTO volunteer);
         Task<List<VolunteerDTO>> GetAllVolunteers();
        Task<VolunteerDTO> GetVolunteer(int id);
        Task UpdateVolunteer(int id, string lastName);
        MyVolunteer ValidateUser(LoginDto user);
        //Task<MyVolunteer> GetVolunteerProfile(int id);
        Task<VolunteerDTO> GetVolunteerProfile(int id);
        Task DeleteVolunteer(int id);
        Task<string> addSkillTOVlunteer(string userId, string skillName);


        Task<ICollection<VolunteerDTO>> GetVolunteersBySkillAsync(string skillName);
        Task<Skill> CreateNewSkillAsync(string name);
    }
}
