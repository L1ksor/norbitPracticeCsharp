using DatabaseCRUDTask5.Models;
using Microsoft.Data.SqlClient;

namespace DatabaseCRUDTask5.ADO.NET
{
    internal class TripRepository : IRepository<Trip, Guid>
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private string _connectionSql;

        public TripRepository(string connetionSql)
        {
            _connectionSql = connetionSql;
        }

        /// <inheritdoc />
        public void Add(Trip trip)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);

            sqlConnection.Open();

            string sqlQuery = "INSERT INTO " +
                "Trip (CompanyId, PlaneId, TownFrom, TownTo, TimeOut, TimeIn) " +
                "VALUES (@CompanyId, @PlaneId, @TownFrom, @TownTo, @TimeOut, @TimeIn)";
            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@CompanyId", trip.CompanyId);
            command.Parameters.AddWithValue("@PlaneId", trip.PlaneId);
            command.Parameters.AddWithValue("@TownFrom", trip.TownFrom);
            command.Parameters.AddWithValue("@TownTo", trip.TownTo);
            command.Parameters.AddWithValue("@TimeOut", trip.TimeOut);
            command.Parameters.AddWithValue("@TimeIn", trip.TimeIn);
            command.ExecuteNonQuery();
        }

        /// <inheritdoc />
        public List<Trip> GetAll()
        {
            var resultCompanies = new List<Trip>();

            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);

            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Trip";
            using var command = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var trip = new Trip()
                {
                    Id = reader.GetGuid(0),
                    CompanyId = reader.GetGuid(1),
                    PlaneId = reader.GetString(2),
                    TownFrom = reader.GetString(3),
                    TownTo = reader.GetString(4),
                    TimeOut = reader.GetDateTime(5),
                    TimeIn = reader.GetDateTime(6),
                };

                resultCompanies.Add(trip);
            }

            return resultCompanies;
        }

        /// <inheritdoc />
        public Trip? GetById(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Trip WHERE Id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var trip = new Trip()
                {
                    Id = reader.GetGuid(0),
                    CompanyId = reader.GetGuid(1),
                    PlaneId = reader.GetString(2),
                    TownFrom = reader.GetString(3),
                    TownTo = reader.GetString(4),
                    TimeOut = reader.GetDateTime(5),
                    TimeIn = reader.GetDateTime(6),
                };

                return trip;
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc />
        public void Update(Trip trip)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = @"UPDATE Trip 
                        SET CompanyId = @CompanyId, 
                            PlaneId = @PlaneId,
                            TownFrom = @TownFrom, 
                            TownTo = @TownTo, 
                            TimeOut = @TimeOut, 
                            TimeIn = @TimeIn 
                        WHERE Id = @Id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@CompanyId", trip.CompanyId);
            command.Parameters.AddWithValue("@PlaneId", trip.PlaneId);
            command.Parameters.AddWithValue("@TownFrom", trip.TownFrom);
            command.Parameters.AddWithValue("@TownTo", trip.TownTo);
            command.Parameters.AddWithValue("@TimeOut", trip.TimeOut);
            command.Parameters.AddWithValue("@TimeIn", trip.TimeIn);
            command.Parameters.AddWithValue("@Id", trip.Id);
            command.ExecuteNonQuery();
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = "DELETE FROM Trip WHERE id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
