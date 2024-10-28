using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Orden
    {
        public int id { get; set; }
        public int cuentaId{ get; set; }
        public Activo activo { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public char operacion { get; set; }
        public Estado estado { get; set; }
        public double montoTotal { get; set; }

    }
}
