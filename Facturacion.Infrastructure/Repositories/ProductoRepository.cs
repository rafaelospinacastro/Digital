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
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(FacturacionContext facturacionContext) : base(facturacionContext)
        {

        }
        public async Task<IEnumerable<Core.Entities.Producto>> GetClienteByNombreProducto(string nombreProducto)
        {

            return await _facturacionContext.Producto
                .Where(m => m.Nombre == nombreProducto)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.Producto>> GetClienteByCodigo(string codigo)
        {
            return await _facturacionContext.Producto
                .Where(m => m.Codigo == codigo)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.Producto>> GetClienteBySigla(string sigla)
        { 
            return await _facturacionContext.Producto
                .Where(m => m.Sigla == sigla)
                .ToListAsync();
        }
    }
}
