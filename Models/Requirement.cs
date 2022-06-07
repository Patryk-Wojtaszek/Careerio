using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Models
{
    public class Requirement
    {
        public int Id { get; set; }
       
        public string[] Requirements { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}
