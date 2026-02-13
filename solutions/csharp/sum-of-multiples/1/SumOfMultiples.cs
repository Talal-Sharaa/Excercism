public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        if (multiples == null)
            throw new ArgumentNullException(nameof(multiples));

        HashSet<int> uniqueMultiples = new HashSet<int>();

        foreach (int multiple in multiples)
        {
            if (multiple == 0) continue;
            for (int i = multiple; i < max; i += multiple)
            {
                uniqueMultiples.Add(i);
            }
        }

        return uniqueMultiples.Sum();
    }
}
