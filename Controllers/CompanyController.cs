using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Careerio.Interfaces;
using Careerio.Dtos;
using Careerio.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Careerio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }

        [HttpPost]
        [Authorize(Roles ="Employer, Admin")]
        public ActionResult AddCompany([FromBody]AddCompanyDto dto)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var id = _company.Add(dto);
            return Created($"{id}", null);
        }

        [HttpGet]
        [Authorize(Roles = "Employer, Admin, User")]
        public ActionResult<IEnumerable<CompanyDto>> GetCompanies()
        {
            var companiesDto = _company.GetCompanies();
            return Ok(companiesDto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Employer, Admin, User")]
        public IActionResult GetCompany (int id )
        {
            var company = _company.GetCompanyById(id);
            return Ok(company);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Employer, Admin")]
        public void DeleteCompany(int id )
        {
            _company.DeleteCompany(id);
         
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Employer, Admin")]

        public ActionResult UpdateCompany([FromBody] UpdateCompanyDto dto, [FromRoute] int id)
        {

            var isUpdated = _company.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
