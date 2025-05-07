using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace abse.works.Domain.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfessionId { get; set; }
        [JsonIgnore]
        public Profession Profession { get; set; }
    } 
}
