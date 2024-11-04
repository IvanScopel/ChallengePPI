using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
        public int Cantidad { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        [RegularExpression("[CV]", ErrorMessage = "El valor solo puede ser 'C' o 'V'.")]
        public char Operacion { get; set; }

        [ForeignKey("Estado")]
        public int TipoEstadoId { get; set; }
        public virtual TipoEstado? Estado { get; set; }
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public double MontoTotal { get; set; }

        public bool Borrado;
    }
}
