﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Activos
{
    public class Accion : Activo
    {
        public override double CalcularMontoTotal(int cantidad)
        {
            var totalSinComisiones = cantidad * this.PrecioUnitario;
            var comision = totalSinComisiones * 0.002;
            var impuesto = comision * 0.21;
            return totalSinComisiones + comision + impuesto;

        }
    }
}
