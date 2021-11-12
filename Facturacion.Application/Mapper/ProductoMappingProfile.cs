using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Facturacion.Application.Commands;
using Facturacion.Application.Response;
using Facturacion.Core.Entities;

namespace Facturacion.Application.Mapper
{
    public class ProductoMappingProfile : Profile
    {
        public ProductoMappingProfile()
        {
            CreateMap<Producto, ProductoResponse>().ReverseMap();
            CreateMap<Producto, CreateProductoCommand>().ReverseMap();
        }

    }
}
