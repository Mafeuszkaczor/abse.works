using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Application.DTOs
{
    public class ProfessionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SkillDto> Skills { get; set; } = new List<SkillDto>();
    }
}
