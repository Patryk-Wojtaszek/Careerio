using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Models
{
    public class Technology
    {
        public int Id { get; set; }
        public string[] Technologies { get; set; }
        public virtual Company Company { get; set; }
    }
}
