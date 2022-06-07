using Careerio.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public byte TypeOfContractId { get; set; }
        public virtual TypeOfContract TypeOfContract { get; set; }

        public byte ExperienceLevelId { get; set; }
        public virtual ExperienceLevel ExperienceLevel { get; set; }
        public byte RemoteRecruitmentId { get; set; }

        public virtual RemoteRecruitment RemoteRecruitment { get; set; }
        public byte WorkingHoursID { get; set; }
        public virtual WorkingHours WorkingHours { get; set; }
        public int ResponsibilityId { get; set; }
        public virtual Responsibility Responsibility { get; set; }
        public int RequirementId { get; set; }
        public virtual Requirement Requirement { get; set; }
        public DateTime? DateTime { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}
