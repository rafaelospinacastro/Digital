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
            var employeeEntitiy = ClienteMapper.Mapper.Map<Cliente>(request);
            if (employeeEntitiy is null)
            {
                throw new ApplicationException("Problema en el mapeo");
            }
            var newEmployee = await _clienteRepo.AddAsync(employeeEntitiy);
            var employeeResponse = ClienteMapper.Mapper.Map<ClienteResponse>(newEmployee);
            return employeeResponse;
        }
    }
}
