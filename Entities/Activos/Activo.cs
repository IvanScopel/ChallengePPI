using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class Activo
    {
        public int id { get; set; }
        public string ticker { get; set; }
        public string nombre { get; set; }
        public TipoActivo tipoActivo { get; set; }
        public double precioUnitario { get; set; }

        public abstract double CalcularMontoTotal(int cantidad);
    }
}
