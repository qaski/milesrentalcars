using System.Collections.Generic;
using System.Threading.Tasks;
using MilesCarRental.Domain.Entities;
using MilesCarRental.Domain.Repositories;

namespace MilesCarRental.Application.Localidades.Queries
{
    public class GetLocalidadesQuery : IGetLocalidadesQuery
    {
        private readonly ILocalidadRepository _localidadRepository;

        public GetLocalidadesQuery(ILocalidadRepository localidadRepository)
        {
            _localidadRepository = localidadRepository;
        }

        public async Task<List<Localidad>> ExecuteAsync()
        {
            return await _localidadRepository.ObtenerTodas();
        }
    }
}
