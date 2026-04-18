using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;

namespace Repositoryy
{
    public class VolunteerRepository(DataContext dataContext) : IVolunteerRepository
    {
        public async Task<IEnumerable<MyVolunteer>> GetAllVolunteers()
        {
            return await dataContext.Volunteers.Include(v=>v.Skills).ToListAsync();
        }

        public async Task AddVolunteer(MyVolunteer volunteer)
        {
            dataContext.Volunteers.Add(volunteer);
            await dataContext.SaveChangesAsync();
        }

        public async Task<MyVolunteer> GetVolunteer(int id)
        {
            return await dataContext.Volunteers.Where(MyVolunteer => MyVolunteer.Id == id).Include(v => v.Skills).FirstOrDefaultAsync();
        }
        public async Task UpdateVolunteer(int id, MyVolunteer volunteer)
        {
            var existingVolunteer = await dataContext.Volunteers
                .Include(v => v.Skills)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (existingVolunteer != null)
            {
                foreach (var skill in volunteer.Skills)
                {
                    if (!existingVolunteer.Skills.Any(s => s.Id == skill.Id))
                    {
                        existingVolunteer.Skills.Add(skill);
                    }
                }

                await dataContext.SaveChangesAsync();
            }
        }

        public MyVolunteer GetByEmail(string email)
        {
            var volunteer = dataContext.Volunteers.Where(MyVolunteer => MyVolunteer.Email == email).FirstOrDefault();
            return volunteer;
        }

        public async Task DeleteVolunteer(int id)
        {
            var volunteer = await GetVolunteer(id);
            if (volunteer != null)
            {
                dataContext.Volunteers.Remove(volunteer);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Skill>> GetSkillByName(string skillName)
        {
            return await dataContext.Skills
                .Where(s => s.Name == skillName)
                .ToListAsync();
        }
        public async Task<ICollection<MyVolunteer>> GetVolunteersBySkill(string skillName)
        {
            return await dataContext.Volunteers
                .Include(v => v.Skills) // חייבים לטעון את המיומנויות כדי לבדוק אותן
                .Where(v => v.Skills.Any(s => s.Name.ToLower() == skillName.ToLower()))
                .ToListAsync();
        }
        public async Task<Skill> AddSkillAsync(Skill skill)
        {
            dataContext.Skills.Add(skill);
            await dataContext.SaveChangesAsync();
            return skill;
        }
    }
}
