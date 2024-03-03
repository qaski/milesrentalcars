using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.CarIdActualLocation.Services;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarIdActualLocationController : ControllerBase
    {
        private readonly ICarIdActualLocationService _carIdActualLocationService;

        public CarIdActualLocationController(ICarIdActualLocationService carIdActualLocationService)
        {
            _carIdActualLocationService = carIdActualLocationService ?? throw new ArgumentNullException(nameof(carIdActualLocationService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarIdActualLocationDTO>>> GetAllCarIdActualLocations()
        {
            var carIdActualLocations = await _carIdActualLocationService.GetAllCarIdActualLocationsAsync();
            return Ok(carIdActualLocations);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarIdActualLocation(int id, CarIdActualLocationDTO carIdActualLocationDTO)
        {
            if (id != carIdActualLocationDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _carIdActualLocationService.UpdateCarIdActualLocationAsync(carIdActualLocationDTO);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
