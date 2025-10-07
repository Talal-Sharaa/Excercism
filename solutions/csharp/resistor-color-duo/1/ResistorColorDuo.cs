public static class ResistorColorDuo
{
    private static readonly Dictionary<string, int> ColorMap = new(StringComparer.OrdinalIgnoreCase)
    {
        ["black"] = 0,
        ["brown"] = 1,
        ["red"] = 2,
        ["orange"] = 3,
        ["yellow"] = 4,
        ["green"] = 5,
        ["blue"] = 6,
        ["violet"] = 7,
        ["grey"] = 8,
        ["white"] = 9
    };

    private static int ColorValue(string color)
    {
        if (!ColorMap.TryGetValue(color, out int value))
            throw new ArgumentOutOfRangeException(nameof(color), $"Invalid color: {color}");
        return value;
    }

    public static int Value(string[] colors) => 10 * ColorValue(colors[0]) + ColorValue(colors[1]);
}
