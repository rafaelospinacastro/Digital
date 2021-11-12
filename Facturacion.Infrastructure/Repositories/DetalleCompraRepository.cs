using Facturacion.Core.Entities;
using Facturacion.Core.Repositories;
using Facturacion.Infrastructure.Data;
using Facturacion.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Repositories
{    
    public class DetalleCompraRepository : Repository<DetalleCompra>, IDetalleCompraRepository
    {
        public DetalleCompraRepository(FacturacionContext facturacionContext) : base(facturacionContext)
        {

        }
        public async Task<IEnumerable<Core.Entities.DetalleCompra>> GetClienteByIdProducto(Guid idProducto)
        {

            return await _facturacionContext.DetalleCompra
                .Where(m => m.IdProducto == idProducto)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.DetalleCompra>> GetClienteByIdCompra(Guid idCompra)
        {

            return await _facturacionContext.DetalleCompra
                .Where(m => m.IdCompra == idCompra)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.DetalleCompra>> GetClienteByValorCompra(decimal valorCompra)
        {

            return await _facturacionContext.DetalleCompra
                .Where(m => m.ValorProducto == valorCompra)
                .ToListAsync();
        }
    }
}
