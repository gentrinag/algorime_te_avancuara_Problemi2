using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problemi2
{
    class Program
    {
        public const int x = 1000000007;  //per probleme me large integers
        public static long[,] vektor = new long[2500, 50000];
        public static long rez = 0;
        static void Main(string[] args)
        {
            DivFree rezultati = new DivFree();
            Console.WriteLine(" Jepni vleren e n (gjetesia e array-it):"); // Prompt
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" Jepni vleren e k (numrat prej 1-k marrin pjese ne kombinime):"); // Prompt
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(rezultati.dfcount(n, k));
        }

        public class DivFree
        {
            public long dfcount(int n, int k)
            {
                for (int i = 1; i <= k; i++)
                {
                    vektor[1, i] = 1;
                }

                for (int g = 2; g <= n; g++)
                {
                    long sum = 0;
                    for (int i = 1; i <= k; i++)
                    {
                        sum = (sum + vektor[g - 1, i]) % x;
                    }
                    for (int i = 1; i <= k; i++)
                    {
                        vektor[g, i] = (vektor[g, i] + sum);
                        for (int j = 2 * i; j <= k; j += i)
                        {
                            vektor[g, i] = (vektor[g, i] - vektor[g - 1, j] + x) % x;
                        }
                    }
                }

                for (int i = 1; i <= k; i++)
                {
                    rez = (rez + vektor[n, i]) % x;
                }

                return rez;
            }
        }
    }
}
