using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Models
{
    public class Benefit
    {
        public int Id { get; set; }
        public string[] Benefits { get; set; }
        public virtual Company Company { get; set; }
    }
}
