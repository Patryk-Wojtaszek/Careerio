using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Models
{
    public class RelatedIndustry
    {
        public int Id { get; set; }
        public string[] RelatedIndustries { get; set; }
        public virtual Company Company { get; set; }
    }
}
