using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using abse.works.Application.Common;
using abse.works.Application.DTOs.JobOfferDto;
using abse.works.Application.Interfaces;
using abse.works.Application.ViewModels.HomePage;
using abse.works.Application.ViewModels.JobOffer;
using abse.works.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static abse.works.Domain.Constants.Constants;

namespace abse.works.Infrastructure.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly int userId = 4;

        public JobOfferService(AppDbContext appDbContext, IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;
        }

        private Response<bool> GetResponse(int result)
        {
            if (result > 0)
                return Response<bool>.SuccessResponse(Messages.SaveSuccess);
            else
                return Response<bool>.WarningResponse(Messages.NoSave);
        }

        public async Task<Response<bool>> AddJobOffer(JobOfferDto dto)
        {
            try
            {
                var jobOffer = new JobOffer(
                    dto.Position, 
                    dto.Description,
                    dto.Duties, 
                    dto.AdditionalInfo,
                    dto.AdditionalSkills, 
                    dto.Salary, 
                    dto.Localization, 
                    dto.Period, 
                    dto.StartDate, 
                    dto.CountryId);

                await _context.JobOffers.AddAsync(jobOffer);
                await _context.SaveChangesAsync();
                return Response<bool>.SuccessResponse(Messages.SaveSuccess);
            }
            catch (Exception ex)
            {
                return Response<bool>.BadResponse(Messages.SaveError);
            }
        }

        public async Task<Response<bool>> AddSkillToJobOffer(JobOfferSkillDto dto)
        {
            try
            {
                var jobOffer = await _context.JobOffers.FindAsync(dto.JobOfferId);
                if (jobOffer == null)
                {
                    return Response<bool>.WarningResponse(Messages.NoSave);
                }

                var skill = await _context.Skills.FindAsync(dto.SkillId);
                if (skill == null)
                {
                    return Response<bool>.WarningResponse(Messages.NoSave);
                }

                jobOffer.AddSkill(skill);
                await _context.SaveChangesAsync();
                return Response<bool>.SuccessResponse(Messages.SaveSuccess);
            }
            catch (Exception ex)
            {
                return Response<bool>.BadResponse(Messages.SaveError);
            }
        }

        public async Task<Response<bool>> RemoveSkillFromJobOffer(JobOfferSkillDto dto)
        {
            try
            {
                var jobOffer = await _context.JobOffers.FindAsync(dto.JobOfferId);
                if (jobOffer == null)
                {
                    return Response<bool>.WarningResponse(Messages.NoSave);
                }

                var skill = await _context.Skills.FindAsync(dto.SkillId);
                if (skill == null)
                {
                    return Response<bool>.WarningResponse(Messages.NoSave);
                }

                jobOffer.RemoveSkill(skill);
                await _context.SaveChangesAsync();
                return Response<bool>.SuccessResponse(Messages.SaveSuccess);
            }
            catch (Exception ex)
            {
                return Response<bool>.BadResponse(Messages.SaveError);
            }
        }

        public async Task<Response<bool>> UpdateJobOffer(JobOfferDto dto)
        {
            try
            {
                var jobOffer = await _context.JobOffers.FindAsync(dto.Id);
                if (jobOffer == null)
                {
                    return Response<bool>.WarningResponse(Messages.NoSave);
                }

                jobOffer.Update(
                    dto.Position, 
                    dto.Description, 
                    dto.Duties,
                    dto.AdditionalInfo,
                    dto.AdditionalSkills, 
                    dto.Salary, 
                    dto.Localization, 
                    dto.Period, 
                    dto.StartDate, 
                    dto.CountryId);

                await _context.SaveChangesAsync();
                return Response<bool>.SuccessResponse(Messages.SaveSuccess);
            }
            catch (Exception ex)
            {
                return Response<bool>.BadResponse(Messages.SaveError);
            }
        }

        public async Task<Response<bool>> DeleteJobOffer(int jobOfferId)
        {
            try
            {
                var jobOffer = await _context.JobOffers.FindAsync(jobOfferId);
                if (jobOffer == null)
                {
                    return Response<bool>.WarningResponse(Messages.NoSave);
                }

                _context.JobOffers.Remove(jobOffer);
                await _context.SaveChangesAsync();
                return Response<bool>.SuccessResponse(Messages.SaveSuccess);
            }
            catch (Exception ex)
            {
                return Response<bool>.BadResponse(Messages.SaveError);
            }
        }

        public async Task<Response<JobOffersViewModel>> GetJobOffers(int page, int pageSize)
        {
            try
            {
                var jobOffers = await _context.JobOffers
                    .Include(x => x.Country)
                    .Include(x => x.Skills)
                        .ThenInclude(x => x.Skill)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                if (!jobOffers.Any())
                {
                    return Response<JobOffersViewModel>.WarningResponse(Messages.DownloadError);
                }

                var model = new JobOffersViewModel()
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalCount = await _context.JobOffers.CountAsync(),
                    TotalPages = (int)Math.Ceiling((double)await _context.JobOffers.CountAsync() / pageSize),
                    Offers = _mapper.Map<List<JobOfferViewModel>>(jobOffers)
                };

                return Response<JobOffersViewModel>.SuccessResponse(model);
            }
            catch
            {
                return Response<JobOffersViewModel>.BadResponse(Messages.DownloadError);
            }
        }

        public async Task<Response<JobOfferViewModel>> GetJobOfferById(int id)
        {
            try
            {
                var jobOffer = await _context.JobOffers
                    .Include(x => x.Country)
                    .Include(x => x.Skills)
                        .ThenInclude(x => x.Skill)
                    .FirstOrDefaultAsync(x => x.Id == id);

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

        //public async Task<Response<bool>> ApplyForJobOffer(int id)
        //{
        //    try
        //    {
        //        var jobOffer = await _context.JobOffers.FirstOrDefaultAsync(x => x.Id == id);
        //        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

        //        if (user == null || jobOffer == null)
        //            return Response<bool>.BadResponse(Messages.SaveError);

        //        _context.JobOfferCandidates.Add(new JobOfferCandidate(user, jobOffer));
        //        var result = _context.SaveChanges();
        //        return Response<bool>.SuccessResponse(Messages.Applied);
        //    }
        //    catch
        //    {
        //        return Response<bool>.BadResponse(Messages.SaveError);
        //    }
        //}

        //public async Task<Response<List<JobOfferViewModel>>> GetJobOffersBySkillId(int skillId)
        //{
        //    try
        //    {
        //        var jobOffers = await _context.JobOffers
        //            .Where(x => x.Skills.Any(s => s.Id == skillId))
        //            .ToListAsync();
        //        return _mapper.Map<List<JobOfferViewModel>>(jobOffers);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
