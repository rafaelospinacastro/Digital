using Facturacion.Core.Commands;
using Facturacion.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Facturacion.Core.Entities;

namespace Facturacion.Core.Mapper
{
    public class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            CreateMap<Cliente, ClienteResponse>().ReverseMap();
            CreateMap<Cliente, CreateClienteCommand>().ReverseMap();
        }
    }
}
