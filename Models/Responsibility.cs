using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Models
{
    public class Responsibility
    {
        public int Id { get; set; }
        public string[] Responsibilities { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}
