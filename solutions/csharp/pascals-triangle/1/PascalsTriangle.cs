using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        if (rows < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rows), "The number of rows must be a positive integer.");
        }

        int[][] xRows = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            xRows[i] = new int[i + 1];
            xRows[i][0] = 1;
            xRows[i][i] = 1;

            for (int j = 1; j < i; j++)
            {
                xRows[i][j] = xRows[i - 1][j - 1] + xRows[i - 1][j];
            }
        }

        return xRows;
    }
}
