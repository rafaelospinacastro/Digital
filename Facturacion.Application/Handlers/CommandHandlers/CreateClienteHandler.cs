using Facturacion.Core.Commands;
using Facturacion.Core.Entities;
using Facturacion.Core.Mapper;
using Facturacion.Core.Repositories;
using Facturacion.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Core.Handlers.CommandHandlers
{
    public class CreateClienteHandler
    {        
        private readonly IClienteRepository _clienteRepo;

        public CreateClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepo = clienteRepository;
        }
        public async Task<ClienteResponse> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteEntitiy = ClienteMapper.Mapper.Map<Cliente>(request);
            if (clienteEntitiy is null)
            {
                throw new ApplicationException("Problema en el mapeo");
            }
            var newCliente = await _clienteRepo.AddAsync(clienteEntitiy);
            var clienteResponse = ClienteMapper.Mapper.Map<ClienteResponse>(newCliente);
            return clienteResponse;
        }
    }
}
