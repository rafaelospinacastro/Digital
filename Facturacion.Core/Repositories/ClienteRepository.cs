using Facturacion.Core.Data;
using Facturacion.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Core.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(FacturacionContext facturacionContext) : base(facturacionContext)
        {

        }
    }
}
