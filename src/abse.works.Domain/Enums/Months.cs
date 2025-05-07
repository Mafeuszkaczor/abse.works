using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Domain.Enums
{
    public enum Months
    {
        [Display(Name = "Miesiąc")]
        one,
        [Display(Name = "Dwa miesiące")]
        two,
        [Display(Name = "Około pół roku")]
        halfyear,
        [Display(Name = "Rok")]
        year,
        [Display(Name = "Więcej niż 2 lata")]
        twoyears
    }
}
