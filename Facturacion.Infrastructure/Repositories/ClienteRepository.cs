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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(FacturacionContext facturacionContext) : base(facturacionContext)
        {

        }
        public async Task<IEnumerable<Core.Entities.Cliente>> GetClienteByIdentificacion(string cedula)
        {
            return await _facturacionContext.Cliente
                .Where(m => m.Identificacion == cedula)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.Cliente>> GetClienteByApellido(string apellido)
        {
            return await _facturacionContext.Cliente
                .Where(m => m.Apellidos == apellido)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.Cliente>> GetClienteByNombre(string nombre)
        {
            return await _facturacionContext.Cliente
                .Where(m => m.Nombres == nombre)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.Cliente>> GetClienteByNombreCompleto(string nombre, string apellido)
        {
            return await _facturacionContext.Cliente
                .Where(m => m.Nombres == nombre && m.Apellidos == apellido)
                .ToListAsync();
        }
        public async Task<IEnumerable<Core.Entities.Cliente>> GetClienteByCelular(string celular)
        {
            return await _facturacionContext.Cliente
                .Where(m => m.Celular == celular)
                .ToListAsync();
        }
    }
}
