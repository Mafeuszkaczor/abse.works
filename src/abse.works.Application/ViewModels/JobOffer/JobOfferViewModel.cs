using abse.works.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Application.ViewModels.JobOffer
{
    public class JobOfferViewModel
    {
        public int Id { get; set; }
        public string Position { get; private set; }
        public string Description { get; private set; }
        public string Duties { get; set; }
        public string AdditionalInfo { get; set; }
        public string AdditionalSkills { get; set; }
        public string Salary { get; set; }
        public string Country { get; private set; }
        public string Localization { get; private set; }
        public int Period { get; private set; }
        public DateTime StartDate { get; private set; }
        public List<string> Skills { get; set; }
    }
}
