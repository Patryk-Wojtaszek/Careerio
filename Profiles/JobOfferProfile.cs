using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Models;
using Careerio.Dtos;
using AutoMapper;

namespace Careerio.Profiles
{
    public class JobOfferProfile : Profile
    {
        public JobOfferProfile()
        {
            CreateMap<JobOffer, JobOfferDto>()
                 .ForMember(m => m.CompanyName, c => c.MapFrom(r => r.Company.Name))
                 .ForMember(m => m.ExperienceLevelDescription, c => c.MapFrom(r => r.ExperienceLevel.ExperienceLevelDescription))
                 .ForMember(m => m.IsRemoteRecruitment, c => c.MapFrom(r => r.RemoteRecruitment.IsRemoteRecruitment))
                 .ForMember(m => m.Requirements, c => c.MapFrom(r => r.Requirement.Requirements))
                 .ForMember(m => m.Responsibilities, c => c.MapFrom(r => r.Responsibility.Responsibilities))
                 .ForMember(m => m.TypeOfContractDescription, c => c.MapFrom(r => r.TypeOfContract.TypeOfContractDescription))
                 .ForMember(m => m.WorkingHoursDescription, c => c.MapFrom(r => r.WorkingHours.WorkingHoursDescription));

            CreateMap<AddJobOfferDto, JobOffer>()
                .ForMember(m => m.Requirement, c => c.MapFrom(dto => new Requirement() { Requirements = dto.Requirements }))
                .ForMember(m => m.Responsibility, c => c.MapFrom(dto => new Responsibility() { Responsibilities = dto.Responsibilities }));
        }
    }
}
