using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Application.DTOs.JobOfferDto
{
    public class JobOfferDto
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Duties { get; set; }
        public string AdditionalInfo { get; set; }
        public string AdditionalSkills { get; set; }
        public string Salary { get; set; }
        public int CountryId { get; set; }
        public string Localization { get; set; }
        public int Period { get; set; }
        public DateTime StartDate { get; set; }
        public List<JobOfferSkillDto> Skills { get; set; }
    }
}
