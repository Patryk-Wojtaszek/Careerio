using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Dtos;

namespace Careerio.Interfaces
{
    public interface IJobOffer
    {
        IEnumerable<JobOfferDto> GetJobOffersByCompanyName(string name);
        IEnumerable<JobOfferDto> GetJobOffersByCompanyId(int id);
        IEnumerable<JobOfferDto> GetJobOffers();
        int Add(AddJobOfferDto dto);
        bool Update(int id, UpdateJobOfferDto dto);

        JobOfferDto GetJobOfferById(int id);
        void Delete(int id);
    }
}
