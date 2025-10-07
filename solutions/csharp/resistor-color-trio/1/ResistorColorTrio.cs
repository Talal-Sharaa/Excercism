public static class ResistorColorTrio
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

     public static string Label(string[] colors)
    {
        double rawValue = (10 * ColorValue(colors[0]) + ColorValue(colors[1])) * Math.Pow(10, ColorValue(colors[2]));

        string unit;
        double displayValue;

        if (rawValue >= 1_000_000_000)
        {
            unit = "gigaohms";
            displayValue = rawValue / 1_000_000_000;
        }
        else if (rawValue >= 1_000_000)
        {
            unit = "megaohms";
            displayValue = rawValue / 1_000_000;
        }
        else if (rawValue >= 1_000)
        {
            unit = "kiloohms";
            displayValue = rawValue / 1_000;
        }
        else
        {
            unit = "ohms";
            displayValue = rawValue;
        }

        // Avoid unnecessary decimals (e.g., show "47 kiloohms" not "47.0 kiloohms")
        return $"{displayValue:0.#} {unit}";
    }
}
