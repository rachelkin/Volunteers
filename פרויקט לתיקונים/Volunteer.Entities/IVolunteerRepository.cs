using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer.Entities
{
    public interface IVolunteerRepository
    {
        Task<Skill> AddSkillAsync(Skill newSkill);
        Task AddVolunteer(MyVolunteer volunteer);
        Task DeleteVolunteer(int id);
        Task<IEnumerable<MyVolunteer>> GetAllVolunteers();
        MyVolunteer GetByEmail(string email);
        Task<ICollection<Skill>> GetSkillByName(string skillName);
        Task<MyVolunteer> GetVolunteer(int id);
        Task<ICollection<MyVolunteer>> GetVolunteersBySkill(string skillName);
        Task UpdateVolunteer(int id, MyVolunteer myVolunteer);
    }
}
