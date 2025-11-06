using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductoConBdd
{
    public class DetalleProductoDto
    {
        public string nombre { get; set; }
        public string precio { get; set; }
        public string createdAt { get; set; }
    }
}