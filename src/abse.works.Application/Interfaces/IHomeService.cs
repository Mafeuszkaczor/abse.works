using abse.works.Application.Common;
using abse.works.Application.ViewModels.HomePage;
using abse.works.Application.ViewModels.JobOffer;
using abse.works.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Application.Interfaces
{
    public interface IHomeService
    {
        public Task<Response<JobOffersListViewModel>> GetJobOffers(int page, int pageSize);
        public Task<Response<JobOfferViewModel>> GetJobOfferDetails(int id);
    }
}
