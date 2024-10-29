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
        public string nombre { get; set; }

        [ForeignKey("TipoActivoId")]
        public int TipoActivoId { get; set; }
        public virtual TipoActivo TipoActivo { get; set; }

        [Required]
        public double precioUnitario { get; set; }

        public abstract double CalcularMontoTotal(int cantidad);
    }
}
