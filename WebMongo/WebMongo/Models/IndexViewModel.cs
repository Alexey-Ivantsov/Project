using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMongo.Models
{
    public class IndexViewModel
    {
        public FilterViewModel Filter { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
    }
}
