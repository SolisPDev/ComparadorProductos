using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ComparadorProductos.Helpers
{
    public static class TextHelper
    {
        public static string Normalizar(string texto)
        {
            texto = texto.ToLower().Trim();

            // 🔹 Eliminar "uber" al inicio
            texto = Regex.Replace(texto, @"^uber\s*", "");

            // 🔹 Quitar acentos
            texto = texto
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u");

            // 🔹 Quitar caracteres especiales
            texto = Regex.Replace(texto, @"[^\w\s]", "");

            // 🔹 Quitar palabras basura
            string[] basura = { "combo", "promo", "paquete", "nuevo" };

            foreach (var palabra in basura)
            {
                texto = Regex.Replace(texto, $@"\b{palabra}\b", "");
            }

            // 🔹 Limpiar espacios
            texto = Regex.Replace(texto, @"\s+", " ");

            return texto.Trim();
        }
    }
}