using System.Collections.Generic;
using System.Threading.Tasks;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Domain.Repositories
{
    public interface ICarIdActualLocationRepository
    {
        Task<List<CarIdActualLocation>> GetAllCarIdActualLocationsAsync();
        Task UpdateCarIdActualLocationAsync(CarIdActualLocation carIdActualLocation);
    }
}
