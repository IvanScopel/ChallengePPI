﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TipoEstado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
