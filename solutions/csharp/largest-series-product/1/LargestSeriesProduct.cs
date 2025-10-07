public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (span < 0)
            throw new ArgumentException("Span must not be negative.");
        if (span > digits.Length)
            throw new ArgumentException("Span must be smaller than or equal to the length of the digits string.");
        if (digits.Any(ch => !char.IsDigit(ch)))
            throw new ArgumentException("Input string must contain only digits.");

        if (span == 0)
            return 1;

        long xLargestProduct = 0;

        for (int i = 0; i <= digits.Length - span; i++)
        {
            string slice = digits.Substring(i, span);
            long product = slice.Aggregate(1L, (acc, c) => acc * (c - '0'));
            if (product > xLargestProduct)
                xLargestProduct = product;
        }

        return xLargestProduct;
    }
}
