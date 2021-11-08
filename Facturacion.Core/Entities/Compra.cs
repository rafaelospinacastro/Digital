﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Core.Entities
{
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       

        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public Decimal ValorTotal { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
