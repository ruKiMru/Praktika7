using System;

namespace Praktika7
{
    class Program
    {
        static int Count = 1;

        static bool NextSet(int[] comb, int n, int k)
        {
            int maxValue = k;

            for (int i = maxValue - 1; i >= 0; i--)
            {
                if (comb[i] < n - maxValue + 1 + i)
                {
                    comb[i]++;
                    for (int j = i + 1; j < maxValue; j++)
                    {
                        comb[j] = comb[j - 1] + 1;
                    }
                    return true;
                }
            }
            return false;
        }

        static void Print(int[] comb, int K)
        {
            Console.Write(Count + "-(");
            for (int i = 0; i < K; i++)
            {
                Console.Write(comb[i] + " ");
            }
            Console.Write(")\n");
            Count++;
        }

        static void Main(string[] args)
        {
            int N, K;
            Console.WriteLine("Введите количество различных элементов N:");
            N = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите максимальное количество элементов в сочетании K:");
            while (!int.TryParse(Console.ReadLine(), out K) || K > N)
            {
                if (K > N)
                {
                    Console.WriteLine("Количество элементов в сочетании не может быть больше количества элементов");
                }
                else
                {
                    Console.WriteLine("Данные введены не корректно");
                }

            }

            Console.WriteLine("Сочетания из N по K без повторений:");

            int[] combMatr = new int[K];

            for (int i = 0; i < combMatr.Length; i++)
            {
                combMatr[i] = i + 1;
            }
            Print(combMatr, K);

            if (N >= K)
            {
                while (NextSet(combMatr, N, K))
                {
                    Print(combMatr, K);
                }
            }

            Console.ReadLine();
        }
    }
}

