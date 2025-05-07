using abse.works.Application.ViewModels.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Application.ViewModels.HomePage
{
    public class JobOffersListViewModel
    {
        public List<BasicJobOfferViewModel> Offers { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
