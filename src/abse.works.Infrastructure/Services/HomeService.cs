using Microsoft.EntityFrameworkCore;
using abse.works.Application.Common;
using abse.works.Application.Interfaces;
using abse.works.Application.ViewModels.HomePage;
using static abse.works.Domain.Constants.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using abse.works.Application.ViewModels.JobOffer;

namespace abse.works.Infrastructure.Services
{
    public class HomeService : IHomeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public HomeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<JobOffersListViewModel>> GetJobOffers(int page, int pageSize)
        {
            try
            {
                var jobOffers = await _context.JobOffers
                    .Include(x => x.Country)
                    .Include(x => x.Skills)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                if (!jobOffers.Any())
                {
                    return Response<JobOffersListViewModel>.WarningResponse(Messages.DownloadError);
                }

                var model = new JobOffersListViewModel()
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalCount = await _context.JobOffers.CountAsync(),
                    TotalPages = (int)Math.Ceiling((double)await _context.JobOffers.CountAsync() / pageSize),
                    Offers = _mapper.Map<List<BasicJobOfferViewModel>>(jobOffers)
                };

                return Response<JobOffersListViewModel>.SuccessResponse(model);
            }
            catch
            {
                return Response<JobOffersListViewModel>.BadResponse(Messages.DownloadError);
            }
        }

        public async Task<Response<JobOfferViewModel>> GetJobOfferDetails(int id)
        {
            try
            {
                var jobOffer = await _context.JobOffers
                    .Include(x => x.Country)
                    .Include(x => x.Skills)
                        .ThenInclude(x => x.Skill)
                    .FirstAsync(x => x.Id == id);

                if (jobOffer == null)
                {
                    return Response<JobOfferViewModel>.WarningResponse(Messages.DownloadError);
                }

                var model = _mapper.Map<JobOfferViewModel>(jobOffer);
                return Response<JobOfferViewModel>.SuccessResponse(model);
            }
            catch
            {
                return Response<JobOfferViewModel>.BadResponse(Messages.DownloadError);
            }
        }
    }
}
