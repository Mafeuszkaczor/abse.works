using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Domain.Models
{
    public class JobOfferSkill
    {
        public int JobOfferId { get; private set; }
        public int SkillId { get; private set; }

        public JobOffer JobOffer { get; private set; }
        public Skill Skill { get; private set; }

        private JobOfferSkill() { }

        public JobOfferSkill(JobOffer jobOffer, Skill skill)
        {
            JobOffer = jobOffer;
            Skill = skill;
        }
    }
}
