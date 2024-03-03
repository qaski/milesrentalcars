using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Domain.Entities;
using MilesCarRental.Domain.Repositories;

namespace MilesCarRental.Application.CarIdActualLocation.Services
{
    public class CarIdActualLocationService : ICarIdActualLocationService
    {
        private readonly ICarIdActualLocationRepository _carIdActualLocationRepository;

        public CarIdActualLocationService(ICarIdActualLocationRepository carIdActualLocationRepository)
        {
            _carIdActualLocationRepository = carIdActualLocationRepository ?? throw new ArgumentNullException(nameof(carIdActualLocationRepository));
        }

        public async Task<IEnumerable<CarIdActualLocationDTO>> GetAllCarIdActualLocationsAsync()
        {
            var carIdActualLocations = await _carIdActualLocationRepository.GetAllCarIdActualLocationsAsync();

            List<CarIdActualLocationDTO> carIdActualLocationDTOs = new List<CarIdActualLocationDTO>();

            foreach (var carIdActualLocation in carIdActualLocations)
            {
                carIdActualLocationDTOs.Add(new CarIdActualLocationDTO
                {
                    Id = carIdActualLocation.Id,
                    Brand = carIdActualLocation.Brand,
                    IdActualLocation = carIdActualLocation.IdActualLocation,
                    Plate = carIdActualLocation.Plate,
                    Date = carIdActualLocation.Date
                });
            }

            return carIdActualLocationDTOs;
        }

        public async Task UpdateCarIdActualLocationAsync(CarIdActualLocationDTO carIdActualLocationDTO)
        {
            // Convertir el DTO a la entidad de dominio
            var carIdActualLocation = new MilesCarRental.Domain.Entities.CarIdActualLocation
            {
                Id = carIdActualLocationDTO.Id,
                Brand = carIdActualLocationDTO.Brand,
                IdActualLocation = carIdActualLocationDTO.IdActualLocation,
                Plate = carIdActualLocationDTO.Plate,
                Date = carIdActualLocationDTO.Date
            };

            // Actualizar la ubicación del carro utilizando el repositorio
            await _carIdActualLocationRepository.UpdateCarIdActualLocationAsync(carIdActualLocation);
        }

    }
}
