using System.Collections.Generic;
using System.Threading.Tasks;
using MilesCarRental.Application.DTOs;

namespace MilesCarRental.Application.CarIdActualLocation.Services
{
    public interface ICarIdActualLocationService
    {
        public Task<IEnumerable<CarIdActualLocationDTO>> GetAllCarIdActualLocationsAsync();
        public Task UpdateCarIdActualLocationAsync(CarIdActualLocationDTO carIdActualLocationDTO);
    }
}
