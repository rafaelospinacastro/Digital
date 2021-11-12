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
    public class CreateDetalleCompraHandler
    {
        private readonly IDetalleCompraRepository _detallecompraRepo;

        public CreateDetalleCompraHandler(IDetalleCompraRepository detallecompraRepository)
        {
            _detallecompraRepo = detallecompraRepository;
        }
        public async Task<DetalleCompraResponse> Handle(CreateDetalleCompraCommand request, CancellationToken cancellationToken)
        {
            var detallecompraEntitiy = ClienteMapper.Mapper.Map<DetalleCompra>(request);
            if (detallecompraEntitiy is null)
            {
                throw new ApplicationException("Problema en el mapeo");
            }
            var nuevoDetalleCompra = await _detallecompraRepo.AddAsync(detallecompraEntitiy);
            var detallecompraResponse = CompraMapper.Mapper.Map<DetalleCompraResponse>(nuevoDetalleCompra);
            return detallecompraResponse;
        }
    }
}
