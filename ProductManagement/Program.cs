namespace ProductManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product> 
            { 
                new Product ("Молоко", "ВремяМу", 100, new DateTime(2026,6, 17), new DateTime(2026, 7, 7) )
            };
            
        }
    }
}
