using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Dtos
{
    public class JobOfferDto
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public DateTime? DateTime { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public string CompanyName { get; set; }
        public string TypeOfContractDescription { get; set; }
        public string ExperienceLevelDescription { get; set; }
        public bool IsRemoteRecruitment { get; set; }
        public string WorkingHoursDescription { get; set; }
        public string[] Responsibilities { get; set; }
        public string[] Requirements { get; set; }

    }
}
