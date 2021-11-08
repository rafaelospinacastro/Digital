using Facturacion.Core.Data;
using Facturacion.Core.Entities;
using Facturacion.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Core.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(FacturacionContext facturacionContext) : base(facturacionContext)
        {

        }
    }
}
