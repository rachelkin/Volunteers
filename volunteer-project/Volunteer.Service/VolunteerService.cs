using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;
using static DTOs.Class1;

namespace Volunteer.Service
{
    public class VolunteerService(IVolunteerRepository repo,IMapper mapper): IVolunteerService
    {
       //private readonly IVolunteerRepository repo;
        //public VolunteerService(IVolunteerRepository repo)
        //{
        //    this.repo = repo;
        //}
        public async Task AddVolunteer(VolunteerPostDTO volunteer) {
            var volunteerToAdd = mapper.Map<MyVolunteer>(volunteer);
            await repo.AddVolunteer(volunteerToAdd);
        }

        public async Task DeleteVolunteer(int id)
        {
            await repo.DeleteVolunteer(id);
        }
       
    
        public async Task<List<VolunteerDTO>> GetAllVolunteers()
        {
            var list= await repo.GetAllVolunteers();
            //List<VolunteerDTO> volunteerDTOs = new List<VolunteerDTO>();

            //foreach (var volunteer in list)
            //{
            //    volunteerDTOs.Add(new VolunteerDTO(volunteer.Id, volunteer.FirstName, volunteer.LastName, volunteer.Email, volunteer.Skill != null ? volunteer.Skill.Name : "unknown"));
            //}
            var volunteerDTOs=mapper.Map<List<VolunteerDTO>>(list);
            return volunteerDTOs;
        }

        public async Task<VolunteerDTO> GetVolunteer(int id)
        {
            var v=await repo.GetVolunteer(id);
            if (v == null)
                return null;
            var volunteerDTO = mapper.Map<VolunteerDTO>(v);
            return volunteerDTO;
        }

        public async Task<VolunteerDTO> GetVolunteerProfile(int id)
        {
            var v = await repo.GetVolunteer(id);

            if (v == null) return null;

            // 3. שימוש ב-Mapper כדי להפוך את ה-Entity ל-DTO
            // זה השלב שמונע את ה-Object Cycle כי ב-DTO אין קשרים חוזרים
            var dto = mapper.Map<VolunteerDTO>(v);

            return dto;
        }
        public async Task UpdateVolunteer(int id, string lastName)
        {
            var myVolunteer =await repo.GetVolunteer(id);
            myVolunteer.LastName=lastName+$" ({myVolunteer.LastName})";
           await repo.UpdateVolunteer(id, myVolunteer);
        }

        public MyVolunteer ValidateUser(LoginDto user)
        {
            var volunteer= repo.GetByEmail(user.Email);
            if(volunteer==null)
                return null;
            if(volunteer.Password != user.Password)
                return null;
            return volunteer;
        }
        public async Task<string> addSkillTOVlunteer(string userId, string skillName)
        {
            var volunteer = await repo.GetVolunteer(int.Parse(userId));

            if (volunteer == null)
                return "Volunteer not found";

            var skillList = await repo.GetSkillByName(skillName);
            var skill = skillList.FirstOrDefault();

            if (skill == null)
                return "Skill not found";

            if (volunteer.Skills == null) volunteer.Skills = new List<Skill>();
            volunteer.Skills.Add(skill);

            await repo.UpdateVolunteer(volunteer.Id, volunteer);
            return "Success";
        }
        public async Task<ICollection<VolunteerDTO>> GetVolunteersBySkillAsync(string skillName)
        {
            var volunteers = await repo.GetVolunteersBySkill(skillName);

            return mapper.Map<ICollection<VolunteerDTO>>(volunteers);
        }

        public async Task<Skill> CreateNewSkillAsync(string name)
        {
            // בדיקה אם קיים - חלק מטיפול בשגיאות
            var existing = await repo.GetSkillByName(name);
            if (existing.Any()) throw new Exception("Skill already exists");

            var newSkill = new Skill { Name = name };
            return await repo.AddSkillAsync(newSkill);
        }

    }
}
