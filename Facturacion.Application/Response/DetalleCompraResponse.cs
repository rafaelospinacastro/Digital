using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Response
{
    public class DetalleCompraResponse
    {
        public Guid Id { get; set; }
        public Guid IdCompra { get; set; }
        public Guid IdProducto { get; set; }
        public int Cantidad { get; set; }
        public Decimal ValorProducto { get; set; }
    }
}
