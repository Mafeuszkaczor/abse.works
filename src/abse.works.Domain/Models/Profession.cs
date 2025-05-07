using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Domain.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Skill> Skills { get; set; } = new List<Skill>(); 
    }
}
