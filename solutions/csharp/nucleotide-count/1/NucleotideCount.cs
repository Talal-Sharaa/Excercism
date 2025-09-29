public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> xCountGroups = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 }
        };

        HashSet<char> validKeys = new HashSet<char> { 'A', 'C', 'G', 'T' };

        foreach (char nucleotide in sequence)
        {
            if (!validKeys.Contains(nucleotide))
            {
                throw new ArgumentException($"Invalid nucleotide found: {nucleotide}");
            }

            xCountGroups[nucleotide]++;
        }

        return xCountGroups;
    }
}
