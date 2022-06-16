using Careerio.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int DateOfStarting { get; set; }
        public int NumberOfEmployees { get; set; }
        public int BenefitId { get; set; }
        public virtual Benefit Benefit { get; set; }
        public string Industry { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public int RelatedIndustryId { get; set; }
        public virtual RelatedIndustry RelatedIndustry { get; set; }
        public int TechnologyId { get; set; }
        public virtual Technology Technology { get; set; }
        public int? GalleryId { get; set; }
        public virtual Gallery Gallery { get; set; }

        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

    }
}
