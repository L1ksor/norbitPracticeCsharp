using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
{
    internal class DiscountedProduct : Product
    {
        public decimal discount {  get; set; }
        public decimal discountPrice { get; set; }


    }
}
