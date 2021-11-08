using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Core.Entities
{
    public class DetalleCompra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }
        public Guid IdCompra { get; set; }
        public Guid IdProducto { get; set; }
        public int Cantidad { get; set; }
        public Decimal ValorProducto { get; set; }
    }
}
