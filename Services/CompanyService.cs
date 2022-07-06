using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Interfaces;
using Careerio.Dtos;
using AutoMapper;
using Careerio.Data;
using Careerio.Models;
using Microsoft.EntityFrameworkCore;
using Careerio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Careerio.Authorization;
using System.Security.Claims;

namespace Careerio.Services
{
    public class CompanyService : ICompany
    {
        private readonly CareerioDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;


        public CompanyService(CareerioDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public int Add(AddCompanyDto dto)
        {
            
            var company = _mapper.Map<Company>(dto);
            var userId = _userContextService.GetUserId;
          

            var companies = _context.Companies.FirstOrDefault(c => c.CreatedById==userId);
            if (companies != null)
            {
                throw new ForbidException("Jeden użytkownik może zarejstrować jedną firmę.");
            }
            company.CreatedById = userId;
            _context.Companies.Add(company);
            _context.SaveChanges();

            return company.Id;
        }

        public IEnumerable<CompanyDto> GetCompanies()
        {
            var companies = _context
                .Companies
                .Include(c => c.Address)
                .Include(c => c.Benefit)
                .Include(c => c.Gallery)
                .Include(c => c.Technology)
                .ToList();
            var companiesDto = _mapper.Map<List<CompanyDto>>(companies);
            return companiesDto;
        }
        public CompanyDto GetCompanyByUserId(int id)
        {
            var company = _context
          .Companies
           .Include(c => c.Address)
           .Include(c => c.Benefit)
           .Include(c => c.Gallery)
           .Include(c => c.Technology)
           .SingleOrDefault(c => c.CreatedById == id);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }
        public CompanyDto GetCompanyById(int id)
        {
            var company = _context
               .Companies
                .Include(c => c.Address)
                .Include(c => c.Benefit)
                .Include(c => c.Gallery)
                .Include(c => c.Technology)
                .SingleOrDefault(c => c.Id == id);
            if (company is null)
            {
                throw new NotFoundException("Nie znaleziono firmy.");
            }

            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }

        public void DeleteCompany(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);
            if (company is null)
            {
                throw new NotFoundException("Nie znaleziono firmy");
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, company, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("Forbidden");
            }

          
                var address = _context.Addresses.FirstOrDefault(c => c.Company == company);
                var benefit = _context.Benefits.FirstOrDefault(c => c.Company == company);
                var gallery = _context.Galleries.FirstOrDefault(c => c.Company == company);
                var technology = _context.Technologies.FirstOrDefault(c => c.Company == company);
                _context.Remove(address);
                _context.Remove(benefit);
                _context.Remove(gallery);
                _context.Remove(technology);
            
            _context.Remove(company);
            _context.SaveChanges();
        }
        public CompanyDto Update(int id, UpdateCompanyDto dto)
        {


            var company = _context.Companies.FirstOrDefault(c => c.Id == id);
            if (company is null)
            {
               throw new NotFoundException("Nie znaleziono firmy");
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, company, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("Forbidden");
            }

           
           
            company.DateOfStarting = dto.DateOfStarting;
         
            company.Email = dto.Email;

            company.ImageUrl = dto.ImageUrl;
            company.Industry = dto.Industry;
            company.LongDescription = dto.LongDescription;
            company.Name = dto.Name;
            company.NumberOfEmployees = dto.NumberOfEmployees;

            company.ShortDescription = dto.ShortDescription;

            company.Url = dto.Url;
            company.Address = new Address() { City = dto.City, Country = dto.Country, PostCode = dto.PostCode, Province = dto.Province, Street = dto.Street };
            company.Benefit = new Benefit() { Benefits = dto.Benefits };
            company.Gallery = new Gallery() { Photos = dto.Photos };
            company.Technology = new Technology() { Technologies = dto.Technologies };

            _context.SaveChanges();

            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }


    }
}
