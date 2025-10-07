public static class ResistorColorDuo
{
    private static readonly string[] Colors = 
    {
        "black", "brown", "red", "orange", "yellow",
        "green", "blue", "violet", "grey", "white"
    };

    private static int ColorValue(string color)
    {
        int index = Array.IndexOf(Colors, color.ToLower());
        if (index == -1)
            throw new ArgumentOutOfRangeException(nameof(color), $"Invalid color: {color}");
        return index;
    }

    public static int Value(string[] colors)
    {
        return 10 * ColorValue(colors[0]) + ColorValue(colors[1]);
    }
}
