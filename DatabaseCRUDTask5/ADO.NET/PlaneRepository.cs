using DatabaseCRUDTask5.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseCRUDTask5.ADO.NET
{
    internal class PlaneRepository : IRepository<Plane, Guid>
    {
        private readonly string _connectionSql;

        public PlaneRepository(string connectionSql)
        {
            _connectionSql = connectionSql;
        }

        /// <inheritdoc />
        public void Add(Plane plane)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);

            sqlConnection.Open();

            string sqlQuery = "INSERT INTO " +
                "Plane (Id, Model, PassengerCapacity, CompanyId ) " +
                "VALUES (@Id, @Model, @PassengerCapacity, @CompanyId )";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@Id", plane.Id);
            command.Parameters.AddWithValue("@Model", plane.Model);
            command.Parameters.AddWithValue("@PassengerCapacity", plane.PassengerCapacity);
            command.Parameters.AddWithValue("@CompanyId", plane.CompanyId);

            command.ExecuteNonQuery();

        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = @"DELETE FROM Plane 
                                WHERE id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        /// <inheritdoc />
        public List<Plane> GetAll()
        {
            var resultPlanes = new List<Plane>();

            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();

            string sqlQuery = @"SELECT Id, Model, PassengerCapacity, CompanyId FROM Plane";
            using var command = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var plane = new Plane
                {
                    Id = reader.GetGuid(0),
                    Model = reader.GetString(1),
                    PassengerCapacity = reader.GetInt32(2),
                    CompanyId = reader.GetGuid(3)
                };

                resultPlanes.Add(plane);
            }

            return resultPlanes;
        }

        /// <inheritdoc />
        public Plane? GetById(Guid id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Plane WHERE Id = @id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var plane = new Plane
                {
                    Id = reader.GetGuid(0),
                    Model = reader.GetString(1),
                    PassengerCapacity = reader.GetInt32(2),
                    CompanyId = reader.GetGuid(3)
                };
                return plane;
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc />
        public void Update(Plane plane)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionSql);
            sqlConnection.Open();
            string sqlQuery = @"UPDATE Plane
                        SET Model = @Model,
                            PassengerCapacity = @PassengerCapacity,
                            CompanyId = @CompanyId
                        WHERE Id = @Id";

            using var command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@Model", plane.Model);
            command.Parameters.AddWithValue("@PassengerCapacity", plane.PassengerCapacity);
            command.Parameters.AddWithValue("@CompanyId", plane.CompanyId);
            command.Parameters.AddWithValue("@Id", plane.Id);
            command.ExecuteNonQuery();
        }
    }
}
