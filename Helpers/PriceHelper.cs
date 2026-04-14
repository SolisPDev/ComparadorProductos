using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparadorProductos.Helpers
{
    public static class PriceHelper
    {
        public static double CalcularScorePrecio(decimal precioUber, decimal precioCatalogo)
        {
            decimal diferencia = Math.Abs(precioUber - precioCatalogo);

            // Ideal: diferencia cercana a 30
            decimal objetivo = 30;

            // Mientras más cerca del objetivo, mejor score
            decimal desviacion = Math.Abs(diferencia - objetivo);

            // Escalar a 0 - 1 (máx tolerancia 50)
            double score = 1.0 - (double)(desviacion / 50);

            return Math.Max(0, score);
        }

        public static bool EsPrecioValido(decimal precioUber, decimal precioCatalogo)
        {
            decimal diferencia = Math.Abs(precioUber - precioCatalogo);

            // 🔹 regla: alrededor de 30 con tolerancia
            decimal objetivo = 30;
            decimal tolerancia = 10;

            return diferencia >= (objetivo - tolerancia) &&
                   diferencia <= (objetivo + tolerancia);
        }
    }
}