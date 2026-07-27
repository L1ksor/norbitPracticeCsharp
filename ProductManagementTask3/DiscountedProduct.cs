using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
{
    /// <summary>
    /// Потомок Product для продукта со скидкой.
    /// </summary>
    internal class DiscountedProduct : Product
    {
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }

        public DiscountedProduct(string name, string manufacturer, decimal price,
            DateTime prodictionDate, DateTime endOfProductionDate, decimal discount) 
            : base(name, manufacturer, price, prodictionDate, endOfProductionDate)
        {
            Discount = discount;
            DiscountPrice = price  - (price * (discount / 100)) ;
        }

        public override string ToString()
        {
            return base.ToString() + $"Скидка: {Discount}%\n" +
                $"Цена со скидкой: {DiscountPrice}\n" ;
        }


    }
}
