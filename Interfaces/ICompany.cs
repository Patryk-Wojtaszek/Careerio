using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Models;
using Careerio.Dtos;
using System.Security.Claims;

namespace Careerio.Interfaces
{
    public interface ICompany
    {
        int Add(AddCompanyDto dto);

        
        IEnumerable<CompanyDto> GetCompanies();

        CompanyDto GetCompanyById(int id);
        CompanyDto GetCompanyByUserId(int id);

        void DeleteCompany(int companyId);

        CompanyDto Update(int id, UpdateCompanyDto dto);
    }
}
