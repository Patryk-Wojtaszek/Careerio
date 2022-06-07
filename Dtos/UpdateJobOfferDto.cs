using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Dtos
{
    public class UpdateJobOfferDto
    {
        public string JobTitle { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public byte TypeOfContractId { get; set; }
        public byte ExperienceLevelId { get; set; }
        public byte RemoteRecruitmentId { get; set; }
        public byte WorkingHoursID { get; set; }
        public string[] Requirements { get; set; }
        public string[] Responsibilities { get; set; }
    }
}
