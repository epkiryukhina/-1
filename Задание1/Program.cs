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
            int n, i, j, s;
            long ss, m, max;
            int[,] a = new int[8, 8];
            int[] p = new int[9];
            int[] pmax = new int[9];
            string[] str = new string[9];

            n = Int32.Parse(Console.ReadLine());//ввод кол-ва

            ss = 0;

            for (i = 0; i < n; i++)//ввод чисел в массив
            {
                str = Console.ReadLine().Split(' ');
                for (j = 0; j < n; j++)
                {
                    ss += Int32.Parse(str[j]);
                    a[i, j] = Int32.Parse(str[j]);
                }
            }

            for (i = 0; i <= n; i++)//заполнение доп массива для хранения порядка букв 
                p[i] = i;

            max = 0;

            do
            {
                m = 0;

                for (i = 1; i <= n; i++)//сумма оставшихся на месте с учетом порядка букв
                    m += a[i - 1, p[i] - 1];

                if (m > max)//если сумма оставшихся на месте больше максимума
                {
                    max = m;

                    for (int l = 0; l <= n; l++)
                        pmax[l] = p[l];
                }

                j = n;

                do//поиск первой большей перед меньшей
                {
                    --j;
                } while (!(p[j] < p[j + 1]));

                if (j > 0)
                {
                    i = n + 1;

                    do//поиск первой меньшей перед сохраненной
                    {
                        --i;
                    } while (!(p[i] > p[j]));

                    s = p[i];//смена значений
                    p[i] = p[j];
                    p[j] = s;

                    for (i = j + 1; i <= (n + j + 1) / 2; i++)//замена значений
                    {
                        s = p[i];
                        p[i] = p[n + j + 1 - i];
                        p[n + j + 1 - i] = s;
                    }
                }
            } while (j != 0);

            for (i = 1; i <= n; i++)//вывод рез-ов
                Console.Write((char)(pmax[i] - 1 + (int)'A'));
            
            Console.WriteLine();
            Console.Write(ss - max);

            Console.ReadLine();
        }
    }
}


