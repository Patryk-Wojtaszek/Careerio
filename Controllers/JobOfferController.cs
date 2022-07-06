using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Careerio.Interfaces;
using Careerio.Dtos;
using Careerio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Careerio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOffer _jobOffer;

        public JobOfferController (IJobOffer jobOffer)
        {
            _jobOffer = jobOffer;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult <IEnumerable<JobOfferDto>> GetJobOffers()
        {
            var jobOffersDto = _jobOffer.GetJobOffers();
            return Ok(jobOffersDto);
        }

        [HttpPost]
        
        public ActionResult AddJobOffer([FromBody]AddJobOfferDto dto)
        {
            var id = _jobOffer.Add(dto);
            return Created($"{id}", null);
        }
        [HttpPut("{id}")]
       
        public ActionResult UpdateJobOffer ([FromBody] UpdateJobOfferDto dto, [FromRoute] int id)
        {
            var isUpdated = _jobOffer.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetJobOffers(int id)
        {
            var jobOffer = _jobOffer.GetJobOfferById(id);
            return Ok(jobOffer);
        }

        [HttpGet("companyId={id}")]
        [AllowAnonymous]
        public IActionResult GetJobOffersByCompanyId(int id )
        {
            var jobOffer = _jobOffer.GetJobOffersByCompanyId(id);
            return Ok(jobOffer);
        }
        [HttpGet("companyName={name}")]
        [AllowAnonymous]
        public IActionResult GetJobOffersByCompanyName(string name)
        {
            var jobOffer = _jobOffer.GetJobOffersByCompanyName(name);
            return Ok(jobOffer);
        }

        [HttpDelete("{id}")]
     
        public void DeleteCompany(int id )
        {
            _jobOffer.Delete(id);
        }
    }
}
