using MilesCarRental.Application.DTOs;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.Mappings
{
    public static class CarIdActualLocationMapping
    {
        public static CarIdActualLocationDTO MapToDTO(MilesCarRental.Domain.Entities.CarIdActualLocation carIdActualLocation)
        {
            return new CarIdActualLocationDTO
            {
                Id = carIdActualLocation.Id,
                Brand = carIdActualLocation.Brand,
                IdActualLocation = carIdActualLocation.IdActualLocation,
                Plate = carIdActualLocation.Plate,
                Date = carIdActualLocation.Date
            };
        }
    }
}
