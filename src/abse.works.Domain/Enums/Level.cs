using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Domain.Enums
{
    public enum Level
    {
        [Display(Name = "Nie umiem")]
        NoSkill,
        [Display(Name = "Bardzo słabo")]
        VeryPoor,
        [Display(Name = "Słabo")]
        Poor,
        [Display(Name = "Dobrze")]
        Good,
        [Display(Name = "Bardzo dobrze")]
        VeryGood
    }
}
