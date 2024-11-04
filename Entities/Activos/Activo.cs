using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public abstract class Activo
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public string Ticker { get; set; }  

        [Required]
        public string Nombre { get; set; }

        public int TipoActivoId { get; set; }
        public virtual TipoActivo? TipoActivo { get; set; }

        [Required]
        public double PrecioUnitario { get; set; }

        public abstract double CalcularMontoTotal(int cantidad);
    }
}
