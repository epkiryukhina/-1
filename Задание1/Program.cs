using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Задание1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i, j, s, k;
            long ss, m, max;
            int[,] a = new int[8, 8];
            int[] p = new int[9];
            int[] pmax = new int[9];
            string[] str = new string[9];

            n = Int32.Parse(Console.ReadLine());

            ss = 0;

            for (i = 0; i < n; i++)
            {
                str = Console.ReadLine().Split(' ');
                for (j = 0; j < n; j++)
                {
                    ss += Int32.Parse(str[j]);
                    a[i, j] = Int32.Parse(str[j]);
                }
            }

            for (i = 0; i <= n; i++)
                p[i] = i;

            max = 0;

            do
            {
                m = 0;

                for (i = 1; i <= n; i++)
                    m += a[i - 1, p[i] - 1];

                if (m > max)
                {
                    max = m;

                    for (int l = 0; l <= n; l++)
                        pmax[l] = p[l];
                }

                j = n;

                do
                {
                    --j;
                } while (!(p[j] < p[j + 1]));

                if (j > 0)
                {
                    i = n + 1;

                    do
                    {
                        --i;
                    } while (!(p[i] > p[j]));

                    s = p[i];
                    p[i] = p[j];
                    p[j] = s;

                    for (i = j + 1; i <= (n + j + 1) / 2; i++)
                    {
                        s = p[i];
                        p[i] = p[n + j + 1 - i];
                        p[n + j + 1 - i] = s;
                    }
                }
            } while (j != 0);

            for (i = 1; i <= n; i++)
                Console.Write((char)(pmax[i] - 1 + (int)'A'));
            
            Console.WriteLine();
            Console.Write(ss - max);

            Console.ReadLine();
        }
    }
}


