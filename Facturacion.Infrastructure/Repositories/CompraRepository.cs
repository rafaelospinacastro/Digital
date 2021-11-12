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
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        public CompraRepository(FacturacionContext facturacionContext) : base(facturacionContext)
        {

        }
        public async Task<IEnumerable<Core.Entities.Compra>> GetClienteByIdCliente(Guid idCliente)
        {

            return await _facturacionContext.Compra
                .Where(m => m.IdCliente == idCliente)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.Compra>> GetClienteByFechaCompra(DateTime fechacompra)
        {
            return await _facturacionContext.Compra
                .Where(m => m.Fecha == fechacompra)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.Compra>> GetClienteByUsuario(string usuario)
        {
            return await _facturacionContext.Compra
                .Where(m => m.Usuario == usuario)
                .ToListAsync();
        }        
    }
}
