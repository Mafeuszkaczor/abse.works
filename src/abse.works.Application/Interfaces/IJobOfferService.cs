using abse.works.Application.Common;
using abse.works.Application.DTOs.JobOfferDto;
using abse.works.Application.ViewModels.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Application.Interfaces
{
    public interface IJobOfferService
    {
        Task<Response<bool>> AddJobOffer(JobOfferDto dto);
        Task<Response<bool>> AddSkillToJobOffer(JobOfferSkillDto dto);
        Task<Response<bool>> RemoveSkillFromJobOffer(JobOfferSkillDto dto);
        Task<Response<bool>> UpdateJobOffer(JobOfferDto dto);
        Task<Response<bool>> DeleteJobOffer(int jobOfferId);
        Task<Response<JobOffersViewModel>> GetJobOffers(int page, int pageSize);
        Task<Response<JobOfferViewModel>> GetJobOfferById(int jobOfferId);
        //Task<Response<bool>> ApplyForJobOffer (int id);
    }
}
