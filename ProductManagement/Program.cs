namespace ProductManagement
{
    internal class Program
    {
        private static List<Product> _products = new List<Product>
            {
                new Product ("Молоко", "ВремяМу", 100, new DateTime(2026,6, 17), new DateTime(2026, 7, 7)),
                new Product ("Чипсы Lays c лобстером", "Lays", 180, new DateTime(2025, 12, 12), new DateTime(2030, 12,12 )),
                new DiscountedProduct("Чипсы Lays cо сметаной и луком", "Lays", 180, new DateTime(2025, 12, 12), new DateTime(2030, 12,12 ), 17)
            };

        static void Main(string[] args)
        {

            int choice = 9;
            while (choice != 0)
            {
                Console.WriteLine("Добавить товар - 1;\n" +
                    "Добавить товар со скидкой - 2\n" +
                    "Показать все товары - 3\n " +
                    "Выйти - 0");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Некорректное значение. Введите число.\n");
                    continue; 
                }

                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break; 
                    case 2:
                        AddDiscountedProduct();
                        break;
                    case 3:
                        Show();
                        break;
                    case 0:
                        break;
                }
            }
        }

        private static (string, string, decimal, DateTime, DateTime) ReadProductData()
        {
            Console.WriteLine("\nИмя: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nПроизводитель: ");
            string manufacturer = Console.ReadLine();
            Console.WriteLine("\nЦена: ");
            decimal price = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("\nДата изготовления: ");
            DateTime prodictionDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\nДата окончания срока: ");
            DateTime endOfProductionDate = DateTime.Parse(Console.ReadLine());

            var data = (name, manufacturer, price, prodictionDate, endOfProductionDate);
            return data;
        }

        public static void AddProduct ()
        {
            var data = ReadProductData();

            var product = new Product (data.Item1, data.Item2, data.Item3, data.Item4, data.Item5);
            _products.Add(product);
        }

        public static void AddDiscountedProduct()
        {
            var data = ReadProductData();
            Console.WriteLine("\nДата изготовления: ");
            decimal discount = Decimal.Parse(Console.ReadLine());

            var discountedProduct = new DiscountedProduct(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, discount);
            _products.Add(discountedProduct);
        }

        public static void Show()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
