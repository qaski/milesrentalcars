using MilesCarRental.Domain.Entities;
using MilesCarRental.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Localidades.Services
{
    
    public class LocalidadService
    {
        private readonly ILocalidadRepository _localidadRepository;

        public LocalidadService(ILocalidadRepository localidadRepository)
        {
            _localidadRepository = localidadRepository;
        }

        public Task< List<Localidad>> ObtenerTodasLocalidades()
        {
            return _localidadRepository.ObtenerTodas();
        }
    }

}
