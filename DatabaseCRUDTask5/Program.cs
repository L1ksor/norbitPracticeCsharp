using System.IO;
using System.Text.Json;
using DatabaseCRUDTask5.Models;
using DatabaseCRUDTask5.ADO.NET;
using DatabaseCRUDTask5.EF_Core;
namespace DatabaseCRUDTask5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = File.ReadAllText("../../../settings.json");

            using JsonDocument doc = JsonDocument.Parse(jsonString);
            
            JsonElement root = doc.RootElement;
            string connectionString = root.GetProperty("DefaultConnection").GetString();



            using (var context = new AirlinesDbContext(connectionString))
            {
                string choice = Console.ReadLine();
                MainMenu mainMenu;
                if (choice == "2")
                {
                    Console.WriteLine("\nЗапуск в режиме ADO.NET...");
                    mainMenu = new MainMenu(
                        new PlaneRepository(connectionString),
                        new PassengerRepository(connectionString),
                        new CompanyRepository(connectionString),
                        new TripRepository(connectionString),
                        new PassInTripRepository(connectionString)
                    );
                }
                else
                {
                    Console.WriteLine("\nЗапуск в режиме EF Core...");
                    var dbContext = new AirlinesDbContext(connectionString);
                    mainMenu = new MainMenu(
                        new PlaneEFRepository(dbContext),
                        new PassengerEFRepository(dbContext),
                        new CompanyEFRepository(dbContext),
                        new TripEFRepository(dbContext),
                        new PassInTripEFRepository(dbContext)
                    );
                }

                mainMenu.Run();
            }
        }


    }
}
