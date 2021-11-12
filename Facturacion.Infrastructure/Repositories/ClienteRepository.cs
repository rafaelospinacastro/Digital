using Facturacion.Core.Entities;
using Facturacion.Core.Repositories;
using Facturacion.Infrastructure.Data;
using Facturacion.Infrastructure.Repositories.Base;
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
    }
}
