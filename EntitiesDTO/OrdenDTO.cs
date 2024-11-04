using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDTO
{
    public class OrdenDTO
    {
        public int CuentaId { get; set; }
        public int ActivoId{ get; set; }
        public int Cantidad { get; set; }
        public char Operacion { get; set; }

    }
}
