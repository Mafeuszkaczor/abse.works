using AutoMapper;
using abse.works.Application.DTOs;
using abse.works.Application.DTOs.JobOfferDto;
using abse.works.Application.ViewModels.JobOffer;
using abse.works.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Application.MapProfiles
{
    public class JobOfferMapProfile : Profile
    {
        public JobOfferMapProfile()
        {
            CreateMap<JobOffer, JobOfferViewModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills.Select(s => s.Skill.Name).ToList()))
                .ReverseMap();

            CreateMap<JobOffer, JobOfferDto>()
                .ReverseMap();

            CreateMap<JobOfferDto, JobOfferViewModel>()
                .ReverseMap();
        }
    }
}
