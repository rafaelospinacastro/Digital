using Facturacion.Core.Commands;
using Facturacion.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Facturacion.Core.Entities;
using Facturacion.Application.Response;
using Facturacion.Application.Commands;

namespace Facturacion.Application.Mapper
{
    public class DetalleCompraMappingProfile : Profile
    {

        public DetalleCompraMappingProfile()
        {
            CreateMap<DetalleCompra, DetalleCompraResponse>().ReverseMap();
            CreateMap<DetalleCompra, CreateDetalleCompraCommand>().ReverseMap();
        }
    }
}
