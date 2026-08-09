using DatabaseCRUDTask5.Models;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;


namespace DatabaseCRUDTask5
{
    internal class CompanyRepository
    {
        private string _connetionSql;

        public CompanyRepository(string connetionSql)
        {
            _connetionSql = connetionSql;
        }

        public void Add(Company company)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connetionSql);
            
            sqlConnection.Open();

            string sqlQuery = "INSERT INTO Company (Name) VALUES (@Name)";
            var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@Name", company.Name);

            command.ExecuteNonQuery();
            
        }

        public List<Company> GetAll()
        {
            var resultCompanies = new List<Company>();

            using SqlConnection sqlConnection = new SqlConnection(_connetionSql);
            
            sqlConnection.Open();
            string sqlQuery = "SELECT Id, Name FROM Company";
            var command = new SqlCommand(sqlQuery, sqlConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var company = new Company()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                };

                resultCompanies.Add(company);
            }
            
            return resultCompanies;
        }

        public Company? GetById(string id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connetionSql);
            sqlConnection.Open();
            string sqlQuery = "SELECT Id, Name FROM Company WHERE Id = @id";

            var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var company = new Company()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                };

                return company;
            }
            else
            {
                return null;
            }
        }

        public void Update (string id, string name)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connetionSql);
            sqlConnection.Open();
            string sqlQuery = "Update Company SET Name = @name WHERE id = @id";

            var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@name", name);
            var reader = command.ExecuteNonQuery();
        }

        public void Delete(string id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connetionSql);
            sqlConnection.Open();
            string sqlQuery = "DELETE FROM Company  WHERE id = @id";

            var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteNonQuery();
        }

        
    }
}
