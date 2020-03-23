using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse_sw2.Models.ViewModel
{
    public class ProductViewModel
    {
        public Products Products { get; set; }
        public IEnumerable<ProductTypes> ProductTypes { get; set; }
       
         public IEnumerable <SpecialTags> SpecialTags { get; set; }
    
    }
}
