using MilesCarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.Repositories
{
   
    public interface ILocalidadRepository
    {
        public Task<List<Localidad>> ObtenerTodas();
    }
}
