using DatabaseCRUDTask5.Models;
using Microsoft.Data.SqlClient;
namespace DatabaseCRUDTask5.ADO.NET
{
    internal class PassInTripRepository : IRepository<PassInTrip, Guid>
    {
        private readonly string _connectionSql;

        public PassInTripRepository(string connectionSql)
        {
            _connectionSql = connectionSql;
        }

        /// <inheritdoc />
        public void Add(PassInTrip passInTrip)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);

            sqlConnection.Open();

            string sqlQuery = "INSERT INTO " +
                "PassInTrip (Id, TripId, PassengerId, Place) " +
                "VALUES (@Id, @TripId, @PassengerId, @Place)";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@Id", passInTrip.Id);
            command.Parameters.AddWithValue("@TripId", passInTrip.TripId);
            command.Parameters.AddWithValue("@PassengerId", passInTrip.PassengerId);
            command.Parameters.AddWithValue("@Place", passInTrip.Place);

            command.ExecuteNonQuery();

        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = @"DELETE FROM PassInTrip 
                                WHERE id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        /// <inheritdoc />
        public List<PassInTrip> GetAll()
        {
            var resultPassInTrip = new List<PassInTrip>();

            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();

            string sqlQuery = @"SELECT * FROM PassInTrip";
            using var command = new SqlCommand( sqlQuery, sqlConnection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var passInTrip = new PassInTrip 
                {
                    Id = reader.GetGuid(0),
                    TripId = reader.GetGuid(1),
                    PassengerId = reader.GetGuid(2),
                    Place = reader.GetString(3)
                };

                resultPassInTrip.Add(passInTrip);
            }

            return resultPassInTrip;
        }

        /// <inheritdoc />
        public PassInTrip? GetById(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM PassInTrip WHERE Id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var passInTrip = new PassInTrip
                {
                    Id = reader.GetGuid(0),
                    TripId = reader.GetGuid(1),
                    PassengerId = reader.GetGuid(2),
                    Place = reader.GetString(3)
                };
                return passInTrip;
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc />
        public void Update(PassInTrip passInTrip)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = @"UPDATE PassInTrip
                        SET Place = @Place
                        WHERE Id = @Id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@Place", passInTrip.Place);
            command.Parameters.AddWithValue("@Id", passInTrip.Id);
            command.ExecuteNonQuery();
        }
    }
}
