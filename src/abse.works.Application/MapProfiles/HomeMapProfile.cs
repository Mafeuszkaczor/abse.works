using AutoMapper;
using abse.works.Application.ViewModels.HomePage;
using abse.works.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Application.MapProfiles
{
    public class HomeMapProfile : Profile
    {
        public HomeMapProfile()
        {
            CreateMap<JobOffer, BasicJobOfferViewModel>()
                .ReverseMap();
        }
    }
}
