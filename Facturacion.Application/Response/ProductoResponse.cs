using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Response
{
    public class ProductoResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public Decimal PrecioActual { get; set; }
    }
}
