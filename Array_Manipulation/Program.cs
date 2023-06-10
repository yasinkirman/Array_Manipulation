using System;
using System.Linq;

class Program
{
    static long arrayManipulation(int n, int[][] queries)
    {
        long[] arr = new long[n];

        foreach (var query in queries)
        {
            int a = query[0];
            int b = query[1];
            int k = query[2];
            
            arr[a - 1] += k;
            if (b < n)
            {
                arr[b] -= k;
            }
            if (a < 1 || b < a || n < b || k < 0 || k > (int)Math.Pow(10, 9))
            {
                return 0;
            }
        }

        long max_value = 0;
        long prefix_sum = 0;

        foreach (var num in arr)
        {
            prefix_sum += num;
            if (prefix_sum > max_value)
            {
                max_value = prefix_sum;
            }
        }
        return max_value;
    }

    static void Main()
    {
        Console.WriteLine("Tanımlamalar: \n n: Dizinin eleman sayısı \n m: işlem sayısı \n a,b: n elemanlı dizide işlem yapılacak değer aralığı \n k: a-b aralığındaki elemanlara uygulanacak artış miktarı \n");
        Console.WriteLine("Gerekli Kısıtlar: \n 3 <= n <= 10^7\n 1 <= m <= 2 * 10^5 \n 1 <= a <= b <= n \n 0 <= k <= 10^9 \n");

        Console.Write("n değerini giriniz:");
        int n = int.Parse(Console.ReadLine());

        Console.Write("m değerini giriniz:");
        int m = int.Parse(Console.ReadLine());

        if (n < 3 || n > (int)Math.Pow(10, 7) || m < 1 || m > 2 * (int)Math.Pow(10, 5))
        {
            Console.WriteLine("Geçersiz giriş! n ve m değerleri kısıtlamalara uymalıdır.");
            return;
        }

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++)
        {
            Console.Write($"{i + 1}. işlemin a-b-k değerlerini aralarında birer boşluk bırakarak giriniz:");
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            
        }

        long result = arrayManipulation(n, queries);
        if(result == 0)
        {
            Console.WriteLine("Geçersiz giriş! a, b ve k değerleri kısıtlamalara uymalıdır.");
        }
        else{
            Console.WriteLine("Sonuç: " + result);
        }
    }
}
