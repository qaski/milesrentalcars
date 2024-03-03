using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.Entities
{
    public class CarIdActualLocation
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int IdActualLocation { get; set; }
        public string Plate { get; set; }
        public DateTime Date { get; set; }
    }
}

