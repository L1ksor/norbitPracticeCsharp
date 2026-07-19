namespace ProductManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = new List<Product>
            {
                new Product ("Молоко", "ВремяМу", 100, new DateTime(2026,6, 17), new DateTime(2026, 7, 7)),
                new Product ("Чипсы Lays c лобстером", "Lays", 180, new DateTime(2025, 12, 12), new DateTime(2030, 12,12 )),
                new DiscountedProduct("Чипсы Lays cо сметаной и луком", "Lays", 180, new DateTime(2025, 12, 12), new DateTime(2030, 12,12 ), 17)

            };

            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }

            int choice;
            while (true)
            {
                Console.WriteLine("Добавить товар - 1;\n" +
                    "Удалить товар - 2" +
                    "Показать все товары - 3 ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        {

                        }

                }
            }
        }  

        static public void AddProduct ()
        {
            
        }
    }
}
