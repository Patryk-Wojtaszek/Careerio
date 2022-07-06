
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Models;
using Careerio.Dtos;
using AutoMapper;

namespace Careerio.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(m => m.Benefits, c => c.MapFrom(r => r.Benefit.Benefits))
                .ForMember(m => m.City, c => c.MapFrom(r => r.Address.City))
                .ForMember(m => m.Country, c => c.MapFrom(r => r.Address.Country))
                .ForMember(m => m.Photos, c => c.MapFrom(r => r.Gallery.Photos))
                .ForMember(m => m.PostCode, c => c.MapFrom(r => r.Address.PostCode))
                .ForMember(m => m.Province, c => c.MapFrom(r => r.Address.Province))
                .ForMember(m => m.Street, c => c.MapFrom(r => r.Address.Street))
                .ForMember(m => m.Technologies, c => c.MapFrom(r => r.Technology.Technologies));

            CreateMap<AddCompanyDto, Company>()
                .ForMember(m => m.Address, c => c.MapFrom(dto => new Address() { City = dto.City, Country = dto.Country, PostCode = dto.PostCode, Province = dto.Province, Street = dto.Street }))
                .ForMember(m => m.Benefit, c => c.MapFrom(dto => new Benefit() { Benefits = dto.Benefits }))
                .ForMember(m => m.Gallery, c => c.MapFrom(dto => new Gallery() { Photos = dto.Photos }))
                .ForMember(m => m.Technology, c => c.MapFrom(dto => new Technology() { Technologies = dto.Technologies }));
                

        }
    }
}
