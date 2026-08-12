using DatabaseCRUDTask5.Models;
using Microsoft.Data.SqlClient;

namespace DatabaseCRUDTask5.ADO.NET
{
    internal class CompanyRepository : IRepository<Company, Guid>
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private string _connectionSql;

        public CompanyRepository(string connetionSql)
        {
            _connectionSql = connetionSql;
        }

        /// <inheritdoc />
        public void Add(Company company)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            
            sqlConnection.Open();

            string sqlQuery = "INSERT INTO Company (Name) VALUES (@Name)";
            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@Name", company.Name);

            command.ExecuteNonQuery();
        }

        /// <inheritdoc />
        public List<Company> GetAll()
        {
            var resultCompanies = new List<Company>();

            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            
            sqlConnection.Open();
            string sqlQuery = "SELECT Id, Name FROM Company";
            using var command = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = command.ExecuteReader();
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

        /// <inheritdoc />
        public Company? GetById(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = "SELECT Id, Name FROM Company WHERE Id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
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

        /// <inheritdoc />
        public void Update (Company company)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = "Update Company SET Name = @name WHERE id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@name", company.Name);
            command.Parameters.AddWithValue("@id", company.Id);
            command.ExecuteNonQuery();
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = "DELETE FROM Company  WHERE id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
