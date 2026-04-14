using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComparadorProductos.Models;
using ComparadorProductos.Services;
using ComparadorProductos.Helpers;

namespace ComparadorProductos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando comparación...");

            // 🔹 Rutas de archivos (ajústalas a tu entorno)
            string rutaCatalogo = "catalogo.csv";
            string rutaUber = "uber.csv";
            string rutaSalida = "resultado.csv";

            // 🔹 Leer archivos
            var catalogo = CsvService.LeerCsv(rutaCatalogo);
            var uber = CsvService.LeerCsv(rutaUber);

            var resultados = new List<string>();

            double umbral = 0.7;

            // 🔹 Comparación
            foreach (var prodUber in uber)
            {
                Producto mejorProducto = null;
                double mejorScore = 0;

                foreach (var prodCatalogo in catalogo)
                {
                    double similitud = SimilarityHelper.Similitud(
                        prodUber.Descripcion,
                        prodCatalogo.Descripcion
                    );

                    if (similitud < 0.5) continue; // filtro mínimo

                    double precioScore = PriceHelper.CalcularScorePrecio(
                        prodUber.Precio,
                        prodCatalogo.Precio
                    );

                    double scoreFinal = (similitud * 0.7) + (precioScore * 0.3);

                    if (scoreFinal > mejorScore)
                    {
                        mejorScore = scoreFinal;
                        mejorProducto = prodCatalogo;
                    }
                }
                // 🔹 Solo guardar si encontró algo suficientemente bueno
                if (mejorProducto != null && mejorScore >= 0.65) {
                    resultados.Add(
                        $"\"{prodUber.Id}\"," +
                        $"\"{prodUber.Descripcion}\"," +
                        $"{prodUber.Precio}," +
                        $"\"{mejorProducto.Id}\"," +
                        $"\"{mejorProducto.Descripcion}\"," +
                        $"{mejorProducto.Precio}," +
                        $"{mejorScore:F2}"
                    );
                }
            }
        
            // 🔹 Guardar archivo
            File.WriteAllLines(rutaSalida,
                new[] { "Uber,Catalogo,Similitud" }
                .Concat(resultados)
            );

            Console.WriteLine("Proceso terminado.");
        }
    }
}