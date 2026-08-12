using DatabaseCRUDTask5.Models;
using Microsoft.Data.SqlClient;

namespace DatabaseCRUDTask5.ADO.NET
{
    internal class PassengerRepository : IRepository<Passenger, Guid>
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private string _connectionSql;

        public PassengerRepository(string connetionSql)
        {
            _connectionSql = connetionSql;
        }

        /// <inheritdoc />
        public void Add(Passenger passenger)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);

            sqlConnection.Open();

            string sqlQuery = "INSERT INTO " +
                "Passenger (Id, Name) " +
                "VALUES (@Id, @Name)";
            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@Id", passenger.Id);
            command.Parameters.AddWithValue("@Name", passenger.Name);

            command.ExecuteNonQuery();
        }

        /// <inheritdoc />
        public List<Passenger> GetAll()
        {
            var resultPassengers = new List<Passenger>();

            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);

            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Passenger";
            using var command = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var passenger = new Passenger()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1)
                };

                resultPassengers.Add(passenger);
            }

            return resultPassengers;
        }

        /// <inheritdoc />
        public Passenger? GetById(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Passenger WHERE Id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var passenger = new Passenger()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1)
                };

                return passenger;
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc />
        public void Update(Passenger passenger)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = @"UPDATE Passenger
                        SET Name = @Name
                        WHERE Id = @Id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@Name", passenger.Name);
            command.Parameters.AddWithValue("@Id", passenger.Id);
            command.ExecuteNonQuery();
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = @"DELETE FROM Passenger 
                                WHERE id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
