using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Response
{
    public class CompraResponse
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public Decimal ValorTotal { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
