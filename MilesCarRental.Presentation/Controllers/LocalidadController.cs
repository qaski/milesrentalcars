using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.Localidades.Queries;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private readonly IGetLocalidadesQuery _getLocalidadesQuery;

        public LocalidadController(IGetLocalidadesQuery getLocalidadesQuery)
        {
            _getLocalidadesQuery = getLocalidadesQuery;
        }

        [HttpGet("ObtenerTodasLasLocalidades")]
        public async Task<ActionResult<IEnumerable<Localidad>>> Get()
        {
            try
            {
                var localidades = await _getLocalidadesQuery.ExecuteAsync();
                return Ok(localidades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
