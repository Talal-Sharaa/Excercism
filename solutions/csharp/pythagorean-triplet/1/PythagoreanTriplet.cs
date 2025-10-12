using System;
using System.Collections.Generic;
using System.Linq;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        // no triplets exist for odd sums
        if (sum % 2 != 0)
            return Array.Empty<(int, int, int)>();

            var results = new List<(int a, int b, int c)>();

        for (int m = 2; m < Math.Sqrt(sum / 2); m++)
        {
            if ((sum / 2) % m == 0)
            {
                int sm = sum / 2 / m;
                while (sm % 2 == 0) sm /= 2;

                int k = (m % 2 == 1) ? m + 2 : m + 1;
                while (k < 2 * m && k <= sm)
                {
                    if (sm % k == 0 && GCD(k, m) == 1)
                    {
                        int d = sum / 2 / (k * m);
                        int n = k - m;
                        int a = d * (m * m - n * n);
                        int b = 2 * d * m * n;
                        int c = d * (m * m + n * n);

                        if (a > b)
                            (a, b) = (b, a);

                        results.Add((a, b, c));
                    }
                    k += 2;
                }
            }
        }

        // ensure consistent deterministic ordering
        return results.OrderBy(t => t.a)
                      .ThenBy(t => t.b)
                      .ThenBy(t => t.c);
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}
