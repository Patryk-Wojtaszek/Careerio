using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public virtual Company Company { get; set; }
    }
}
