using AutoMapper;
using Facturacion.Application.Commands;
using Facturacion.Application.Response;
using Facturacion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Mapper
{
    public class CompraMappingProfile : Profile
    {
        public CompraMappingProfile()
        {
            CreateMap<Compra, CompraResponse>().ReverseMap();
            CreateMap<Compra, CreateCompraCommand>().ReverseMap();
        }
    }
}
