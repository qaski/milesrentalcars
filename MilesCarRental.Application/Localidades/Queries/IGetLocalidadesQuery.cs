using MilesCarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Localidades.Queries
{
    public interface IGetLocalidadesQuery
    {
        public Task< List<Localidad>> ExecuteAsync();
    }
}
