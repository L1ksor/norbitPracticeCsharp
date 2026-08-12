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
            string sqlConnection = root.GetProperty("DefaultConnection").GetString();
            

            var company = new Company { Id = Guid.NewGuid(), Name = "Norbit" };

            var companies = new CompanyRepository(sqlConnection);
            companies.GetAll().ForEach(comp => Console.WriteLine(comp));
            var company1 = companies.GetById("F69F8699-7CB2-4641-9DB3-69D3A6A5DBDF");

            Console.WriteLine(company1?.Name ?? "Компания не найдена");
            var company213213 = new CompanyEFRepository(sqlConnection);
        }


    }
}
