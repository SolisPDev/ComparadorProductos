using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComparadorProductos.Models;
using ComparadorProductos.Services;
using ComparadorProductos.Helpers;

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
    foreach (var prodCatalogo in catalogo)
    {
        double score = SimilarityHelper.Similitud(
            prodUber.Descripcion,
            prodCatalogo.Descripcion
        );

        if (score >= umbral)
        {
            resultados.Add(
                $"{prodUber.Descripcion}," +
                $"{prodCatalogo.Descripcion}," +
                $"{score:F2}"
            );
        }
    }
}

// 🔹 Guardar archivo
File.WriteAllLines(rutaSalida,
    new[] { "Uber,Catalogo,Similitud" }
    .Concat(resultados)
);

Console.WriteLine("Proceso terminado.");