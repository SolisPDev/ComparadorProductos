using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComparadorProductos.Models;

namespace ComparadorProductos.Services
{
    public static class CsvService
    {
        public static List<Producto> LeerCsv(string ruta)
        {
            return File.ReadAllLines(ruta)
                .Skip(1)
                .Select(linea =>
                {
                    var partes = linea.Split(',');

                    return new Producto
                    {
                        Id = partes[0],
                        Descripcion = partes[1],
                        Precio = decimal.Parse(partes[2])
                    };
                }).ToList();
        }
    }
}