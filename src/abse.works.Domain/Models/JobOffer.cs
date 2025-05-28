using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Domain.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Position { get; private set; }
        public string Description { get; private set; }
        public string Duties { get; set; }
        public string AdditionalInfo { get; set; }
        public string AdditionalSkills { get; set; }
        public string Salary { get; set; }
        public int CountryId { get; private set; }
        public string Localization { get; private set; }
        public int Period { get; private set; }
        public DateTime StartDate { get; private set; }
        private readonly List<JobOfferSkill> _skills = new();
        public IReadOnlyCollection<JobOfferSkill> Skills => _skills.AsReadOnly();

        public Country Country { get; set; }

        private JobOffer() { }

        public JobOffer(
            string position, 
            string description, 
            string duties, 
            string additionalInfo,
            string additionalSkills, 
            string salary, 
            string localization, 
            int period, 
            DateTime startDate, 
            int countryId)
        {
            if (string.IsNullOrWhiteSpace(position))
                throw new ("Position is required");

            if (period <= 0)
                throw new ("Period have to be positive");

            if (startDate < DateTime.UtcNow)
                throw new ("Date cannot be earlier than today");

            Position = position;
            Description = description;
            Localization = localization;
            Duties = duties;
            AdditionalInfo = additionalInfo;
            AdditionalSkills = additionalSkills;
            Salary = salary;
            CountryId = countryId;
            Period = period;
            StartDate = startDate;
        }
        public void AddSkill(Skill skill)
        {
            if (_skills.Any(s => s.Skill.Id == skill.Id))
                throw new ("Skill already exists in offer");

            _skills.Add(new JobOfferSkill(this, skill));
        }

        public void RemoveSkill(Skill skill)
        {
            var jobOfferSkill = _skills.FirstOrDefault(s => s.Skill.Id == skill.Id);
            if (jobOfferSkill == null)
                throw new("Skill not found in offer");
            _skills.Remove(jobOfferSkill);
        }

        public void Update(
            string position, 
            string description, 
            string duties,
            string additionalInfo,
            string additionalSkills, 
            string salary, 
            string localization, 
            int period, 
            DateTime startDate, 
            int countryId)
        {
            if (string.IsNullOrWhiteSpace(position))
                throw new("Position is required");
            if (period <= 0)
                throw new("Period have to be positive");
            if (startDate < DateTime.UtcNow)
                throw new("Date cannot be earlier than today");

            Position = position;
            Description = description;
            Duties = duties;
            AdditionalInfo = additionalInfo;
            AdditionalSkills = additionalSkills;
            Salary = salary;
            Localization = localization;
            CountryId = countryId;
            Period = period;
            StartDate = startDate;
        }
    }
}
