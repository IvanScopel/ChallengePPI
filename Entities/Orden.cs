using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Orden
    {
        [Key]
        public int Id { get; set; }

        public int CuentaId{ get; set; }

        [Required]
        public Activo Activo { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        public char Operacion { get; set; }

        [ForeignKey("TipoActivoId")]
        public int TipoEstadoId { get; set; }
        public virtual TipoEstado? Estado { get; set; }
        public double MontoTotal { get; set; }

    }
}
