using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using MilesCarRental.Domain.Entities;
using MilesCarRental.Domain.Repositories;
using NPOI.SS.Formula.Functions;

namespace MilesCarRental.Infrastructure.Repositories
{
    public class CarIdActualLocationRepository : ICarIdActualLocationRepository
    {
        private readonly string _connectionString;

        public CarIdActualLocationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CarIdActualLocation>> GetAllCarIdActualLocationsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return (List<CarIdActualLocation>)await connection.QueryAsync<CarIdActualLocation>("SELECT * FROM CarActualLocation");
        }

        public async Task UpdateCarIdActualLocationAsync(CarIdActualLocation carIdActualLocation)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE CarActualLocation SET Brand = @Brand, IdActualLocation = @IdActualLocation, Plate = @Plate, Date = @Date WHERE Id = @Id", carIdActualLocation);
        }
    }
}
