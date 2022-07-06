using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Careerio.Models;
using Careerio.Dtos;
using Careerio.Interfaces;
using Careerio.Data;
using Microsoft.EntityFrameworkCore;
using Careerio.Exceptions;
using Careerio.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace Careerio.Services
{
    public class JobOfferService : IJobOffer
    {
        private readonly CareerioDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authorizationService;

        public JobOfferService(CareerioDbContext context, IMapper mapper, IUserContextService userContextService, IAuthorizationService authorizationService)
        {
            _userContextService = userContextService;
            _context = context;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }
        public IEnumerable<JobOfferDto>GetJobOffersByCompanyName(string name)
        {
            var jobOffer = _context.JobOffers.FirstOrDefault(j => j.Company.Name == name);
            if (jobOffer is null)
            {
                throw new NotFoundException("Nie ma ofert pracy udostępnionych przez podaną firmę.");
            }
            var jobOffers = _context.JobOffers
                     .Include(j => j.Company)
                     .Include(j => j.ExperienceLevel)
                     .Include(j => j.RemoteRecruitment)
                     .Include(j => j.Requirement)
                     .Include(j => j.Responsibility)
                     .Include(j => j.TypeOfContract)
                      .Include(j => j.WorkingHours)
                      .Where(j => j.Company.Name == name);



            var jobOffersDto = _mapper.Map<List<JobOfferDto>>(jobOffers);
            return jobOffersDto;
        }
        public IEnumerable<JobOfferDto> GetJobOffersByCompanyId(int id)
        {

            var jobOffer = _context.JobOffers.FirstOrDefault(j => j.CompanyId == id);
            if(jobOffer is null)
            {
                throw new NotFoundException("Nie ma ofert pracy udostępnionych przez podaną firmę.");
            }

            var jobOffers = _context.JobOffers
                  .Include(j => j.Company)
                  .Include(j => j.ExperienceLevel)
                  .Include(j => j.RemoteRecruitment)
                  .Include(j => j.Requirement)
                  .Include(j => j.Responsibility)
                 .Include(j => j.TypeOfContract)
                 .Include(j => j.WorkingHours)
                 .Where(j => j.CompanyId == id);

        

            var jobOffersDto = _mapper.Map<List<JobOfferDto>>(jobOffers);
            return jobOffersDto;
        }
        public IEnumerable<JobOfferDto> GetJobOffers()
        {
            var jobOffers = _context.JobOffers
                .Include(j => j.Company)
                .Include(j => j.ExperienceLevel)
                .Include(j => j.RemoteRecruitment)
                .Include(j => j.Requirement)
                .Include(j => j.Responsibility)
                .Include(j => j.TypeOfContract)
                .Include(j => j.WorkingHours)
                .ToList();

            var jobOffersDto = _mapper.Map<List<JobOfferDto>>(jobOffers);
            return jobOffersDto;

        }

        public int Add(AddJobOfferDto dto)
        {
            var jobOffer = _mapper.Map<JobOffer>(dto);
            jobOffer.CreatedById = _userContextService.GetUserId;

            var company = _context.Companies.FirstOrDefault(c => c.CreatedById == _userContextService.GetUserId);
                
            if(company is null)
            {
                throw new BadRequestException("Brak firmy powiązanej z zalogowanym użytkownikiem");
            }

            
            jobOffer.CompanyId = company.Id;
            jobOffer.DateTime = DateTime.Now;
            _context.JobOffers.Add(jobOffer);
            _context.SaveChanges();

            return jobOffer.Id;
        }

    
        

        public bool Update(int id, UpdateJobOfferDto dto)
        {
            var jobOffer = _context.JobOffers.FirstOrDefault(j => j.Id == id);
            if (jobOffer is null)
            {

                throw new NotFoundException("Nie znaleziono oferty pracy.");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, jobOffer, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("Użytkownik nie jest autoryzowany do edycji tego ogłoszenia.");
            }
            jobOffer.ExperienceLevelId = dto.ExperienceLevelId;
            jobOffer.JobTitle = dto.JobTitle;
            jobOffer.RemoteRecruitmentId = dto.RemoteRecruitmentId;
            jobOffer.Requirement = new Requirement() { Requirements = dto.Requirements };
            jobOffer.Responsibility = new Responsibility() { Responsibilities = dto.Responsibilities };
            jobOffer.SalaryFrom = dto.SalaryFrom;
            jobOffer.SalaryTo = dto.SalaryTo;
            jobOffer.TypeOfContractId = dto.TypeOfContractId;
            jobOffer.WorkingHoursID = dto.WorkingHoursID;

            _context.SaveChanges();
            return true;

        }

        public JobOfferDto GetJobOfferById(int id)
        {
            var jobOffer = _context
               .JobOffers
                .Include(j => j.Company)
                .Include(j => j.ExperienceLevel)
                .Include(j => j.RemoteRecruitment)
                .Include(j => j.Requirement)
                .Include(j => j.Responsibility)
                .Include(j => j.TypeOfContract)
                .Include(j => j.WorkingHours)
                .SingleOrDefault(c => c.Id == id);
            if (jobOffer is null)
            {
                throw new NotFoundException("Nie znaleziono oferty pracy.");
            }

            var jobOfferDto = _mapper.Map<JobOfferDto>(jobOffer);
            return jobOfferDto; ;
        }
        public void Delete(int id)
        {
            var jobOffer = _context.JobOffers.FirstOrDefault(j => j.Id == id);
            if (jobOffer is null)
            {
                throw new NotFoundException("Nie znaleziono oferty pracy");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, jobOffer, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("Użytkownik nie jest autoryzowany do usunięcia tego ogłoszenia.");
            }
            var requirement = _context.Requirements.FirstOrDefault(j => j.JobOffer == jobOffer);
            _context.Remove(requirement);
            var responsibility = _context.Responsibilities.FirstOrDefault(j => j.JobOffer == jobOffer);
            _context.Remove(responsibility);
            _context.Remove(jobOffer);
            _context.SaveChanges();
        }
    }
}
