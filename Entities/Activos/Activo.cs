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
        
        [StringLength(32, MinimumLength = 2, ErrorMessage = "La longitud del nombre debe ser mayor a 2 y menor a 32")]
        public string Nombre { get; set; }

        public int TipoActivoId { get; set; }
        public virtual TipoActivo? TipoActivo { get; set; }

        [Required]
        public double PrecioUnitario { get; set; }

        public abstract double CalcularMontoTotal(int cantidad);
    }
}
