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
    public class CreateProductoHandler
    {
        private readonly IProductoRepository _productoRepo;

        public CreateProductoHandler(IProductoRepository productoRepository)
        {
            _productoRepo = productoRepository;
        }
        public async Task<ProductoResponse> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var productoEntitiy = ProductoMapper.Mapper.Map<Producto>(request);
            if (productoEntitiy is null)
            {
                throw new ApplicationException("Problema en el mapeo");
            }
            var nuevaCompra = await _productoRepo.AddAsync(productoEntitiy);
            var productoResponse = ProductoMapper.Mapper.Map<ProductoResponse>(nuevaCompra);
            return productoResponse;
        }
    }
}
