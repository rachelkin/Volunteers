using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MyVolunteer> Volunteers { get; set; } = new List<MyVolunteer>();
        //public override string ToString()
        //{
        //    return this.Name;
        //}
    }
}
