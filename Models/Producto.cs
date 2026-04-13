using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparadorProductos.Models
{
    public class Producto
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; } = 0;
    }
}