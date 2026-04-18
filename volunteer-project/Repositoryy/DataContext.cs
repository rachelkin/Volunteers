using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;

namespace Repositoryy
{
    public class DataContext : DbContext
    {
        public DbSet<MyVolunteer> Volunteers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VolunteerDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var baking = new Skill { Id = 1, Name = "Baking" };
            var cleaning = new Skill { Id = 2, Name = "Cleaning" };
            var teaching = new Skill { Id = 3, Name = "Teaching" };
            var gardening = new Skill { Id = 4, Name = "Gardening" };
            var coding = new Skill { Id = 5, Name = "Coding" };

            modelBuilder.Entity<Skill>().HasData(baking, cleaning, teaching, gardening, coding);

            var v1 = new MyVolunteer { Id = 1, FirstName = "Yael", LastName = "Gutman", Email = "yael@example.com", PhoneNumber = "050-1234561", BirthDate = new DateTime(1995, 1, 10), Password = "pass1", Role = "user" };
            var v2 = new MyVolunteer { Id = 2, FirstName = "Yehudit", LastName = "Vaiss", Email = "yehudit@example.com", PhoneNumber = "052-1234562", BirthDate = new DateTime(1998, 2, 20), Password = "pass2", Role = "user" };
            var v3 = new MyVolunteer { Id = 3, FirstName = "Noa", LastName = "Levi", Email = "noa@example.com", PhoneNumber = "054-1234563", BirthDate = new DateTime(1992, 3, 15), Password = "pass3", Role = "user" };
            var v4 = new MyVolunteer { Id = 4, FirstName = "Michal", LastName = "Cohen", Email = "michal@example.com", PhoneNumber = "053-1234564", BirthDate = new DateTime(1990, 4, 25), Password = "pass4", Role = "admin" };
            var v5 = new MyVolunteer { Id = 5, FirstName = "Tamar", LastName = "Aharoni", Email = "tamar@example.com", PhoneNumber = "058-1234565", BirthDate = new DateTime(1997, 5, 12), Password = "pass5", Role = "user" };
            var v6 = new MyVolunteer { Id = 6, FirstName = "Rivka", LastName = "Shwartz", Email = "rivka@example.com", PhoneNumber = "050-1234566", BirthDate = new DateTime(1994, 6, 05), Password = "pass6", Role = "user" };
            var v7 = new MyVolunteer { Id = 7, FirstName = "Sarah", LastName = "Gold", Email = "sarah@example.com", PhoneNumber = "052-1234567", BirthDate = new DateTime(1996, 7, 18), Password = "pass7", Role = "user" };
            var v8 = new MyVolunteer { Id = 8, FirstName = "Esther", LastName = "Katz", Email = "esther@example.com", PhoneNumber = "054-1234568", BirthDate = new DateTime(1993, 8, 22), Password = "pass8", Role = "user" };
            var v9 = new MyVolunteer { Id = 9, FirstName = "Avigail", LastName = "Friedman", Email = "avigail@example.com", PhoneNumber = "053-1234569", BirthDate = new DateTime(1999, 9, 30), Password = "pass9", Role = "user" };
            var v10 = new MyVolunteer { Id = 10, FirstName = "Leah", LastName = "Stern", Email = "leah@example.com", PhoneNumber = "058-1234560", BirthDate = new DateTime(1991, 10, 08), Password = "pass10", Role = "user" };

            modelBuilder.Entity<MyVolunteer>().HasData(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10);


            modelBuilder.Entity("MyVolunteerSkill").HasData(
            new { VolunteersId = 1, SkillsId = 1 },
            new { VolunteersId = 2, SkillsId = 2 },
            new { VolunteersId = 2, SkillsId = 3 }, 
            new { VolunteersId = 3, SkillsId = 3 },
            new { VolunteersId = 4, SkillsId = 1 },
            new { VolunteersId = 5, SkillsId = 4 },
            new { VolunteersId = 6, SkillsId = 5 },
            new { VolunteersId = 7, SkillsId = 2 },
            new { VolunteersId = 8, SkillsId = 3 },
            new { VolunteersId = 9, SkillsId = 4 },
            new { VolunteersId = 10, SkillsId = 5 }
            );
        }
    }
}
