using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Core.Response
{
    public class ClienteResponse
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
