using Facturacion.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Core.Commands
{
    public class CreateClienteCommand : IRequest<ClienteResponse> 
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
