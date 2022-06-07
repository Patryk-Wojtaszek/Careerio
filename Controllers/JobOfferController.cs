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
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOffer _jobOffer;

        public JobOfferController (IJobOffer jobOffer)
        {
            _jobOffer = jobOffer;
        }

        [HttpGet]
        
        public ActionResult <IEnumerable<JobOfferDto>> GetJobOffers()
        {
            var jobOffersDto = _jobOffer.GetJobOffers();
            return Ok(jobOffersDto);
        }

        [HttpPost]
        [Authorize(Roles = "Employer, Admin")]
        public ActionResult AddJobOffer([FromBody]AddJobOfferDto dto)
        {
            var id = _jobOffer.Add(dto);
            return Created($"{id}", null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Employer, Admin")]
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
        public IActionResult GetJobOffers(int id)
        {
            var jobOffer = _jobOffer.GetJobOfferById(id);
            return Ok(jobOffer);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Employer, Admin")]
        public void DeleteCompany(int id )
        {
            _jobOffer.Delete(id);
        }
    }
}
