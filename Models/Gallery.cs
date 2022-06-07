using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Models
{
    public class Gallery
    {
        public int Id { get; set; }
            
        public string[] Photos { get; set; }
        public virtual Company Company { get; set; }

    }
}
