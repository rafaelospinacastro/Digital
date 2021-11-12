using Facturacion.Application.Commands;
using Facturacion.Application.Mapper;
using Facturacion.Application.Response;
using Facturacion.Core.Entities;
using Facturacion.Core.Mapper;
using Facturacion.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.Handlers.CommandHandlers
{
    public class CreateCompraHandler
    {
        private readonly ICompraRepository _compraRepo;

        public CreateCompraHandler(ICompraRepository compraRepository)
        {
            _compraRepo = compraRepository;
        }
        public async Task<CompraResponse> Handle(CreateCompraCommand request, CancellationToken cancellationToken)
        {
            var compraEntitiy = ClienteMapper.Mapper.Map<Compra>(request);
            if (compraEntitiy is null)
            {
                throw new ApplicationException("Problema en el mapeo");
            }
            var nuevaCompra = await _compraRepo.AddAsync(compraEntitiy);
            var compraResponse = CompraMapper.Mapper.Map<CompraResponse>(nuevaCompra);
            return compraResponse;
        }
    }
}
