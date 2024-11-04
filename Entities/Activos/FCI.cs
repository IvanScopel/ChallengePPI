using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Activos
{
    public class FCI : Activo
    {
        public override double CalcularMontoTotal(int cantidad)
        {
            return this.PrecioUnitario * cantidad;
        }
    }
}
