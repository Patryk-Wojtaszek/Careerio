using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Dtos
{
    public class AddCompanyDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int DateOfStarting { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Industry { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string[] Benefits { get; set; }
        public string[] Photos { get; set; }
        public string[] RelatedIndustries { get; set; }
        public string[] Technologies { get; set; }
    }
}
