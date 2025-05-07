using System.ComponentModel.DataAnnotations;

namespace abse.works.Domain.Enums
{
    public enum DocumentTypes
    {
        [Display(Name = "CV")]
        CV = 0,

        [Display(Name = "Certifikat")]
        Certificates = 1,

        [Display(Name = "Umowa")]
        Contract = 2
    }
}
