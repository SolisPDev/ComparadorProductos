using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComparadorProductos.Helpers;

namespace ComparadorProductos.Helpers
{
    public static class SimilarityHelper
    {
        public static int DistanciaLevenshtein(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++) d[i, 0] = i;
            for (int j = 0; j <= m; j++) d[0, j] = j;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int costo = (s[i - 1] == t[j - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + costo);
                }
            }

            return d[n, m];
        }

        public static double Similitud(string a, string b)
        {
            a = TextHelper.Normalizar(a);
            b = TextHelper.Normalizar(b);

            int distancia = DistanciaLevenshtein(a, b);
            int maxLen = Math.Max(a.Length, b.Length);

            if (maxLen == 0) return 1.0;

            return 1.0 - (double)distancia / maxLen;
        }
    }
}