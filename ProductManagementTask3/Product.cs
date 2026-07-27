using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
{
    /// <summary>
    /// Класс продукта
    /// </summary>

    internal class Product
    {
        private string _name;
        private string _manufacturer;
        private decimal _price;
        private DateTime _prodictionDate;
        private DateTime _endOfProductionDate;

        public Product(string name, string manufacturer, decimal price, DateTime prodictionDate, DateTime endOfProductionDate)
        {
            if (price < 0 || endOfProductionDate < prodictionDate) 
            {
                throw new ArgumentOutOfRangeException("Введены неверные параметры");
            }

            _price = price;
            _name = name;
            _manufacturer = manufacturer;
            _prodictionDate = prodictionDate;
            _endOfProductionDate = endOfProductionDate;
        }

        public override string ToString()
        {
            return $"Название: {_name}\n" +
                $"Цена: {_price}\n" +
                $"Дата изготовления и окончания: {_prodictionDate} - {_endOfProductionDate}\n" +
                $"Производитель: {_manufacturer} \n";
        }
    }
}
