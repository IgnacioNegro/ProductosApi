using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductoConBdd
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}