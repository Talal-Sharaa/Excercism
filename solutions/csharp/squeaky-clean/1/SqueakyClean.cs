using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (string.IsNullOrEmpty(identifier))
        {
            return string.Empty;
        }

        // Use StringBuilder for efficient string manipulation.
        var builder = new StringBuilder(identifier.Length);
        bool capitalizeNext = false;

        foreach (char c in identifier)
        {
            if (capitalizeNext && char.IsLetter(c))
            {
                builder.Append(char.ToUpper(c));
                capitalizeNext = false;
                continue;
            }

            if (c == ' ')
            {
                builder.Append('_');
            }
            else if (c == '-')
            {
                // Set a flag to capitalize the next valid character.
                // The hyphen itself is omitted.
                capitalizeNext = true;
            }
            else if (char.IsControl(c))
            {
                builder.Append("CTRL");
                continue;
            }
            // Filter for allowed characters.
            // This logic keeps letters (except lowercase Greek) and digits.
            else if (IsAllowedCharacter(c))
            {
                builder.Append(c);
            }
            // All other characters (like symbols, lowercase Greek, etc.) are skipped.
        }

        return builder.ToString();
    }

    /// <summary>
    /// Helper method to determine if a character should be included in the final identifier.
    /// </summary>
    private static bool IsAllowedCharacter(char c)
    {
        // Rule 1: Reject lowercase Greek letters (as per the original code's logic).
        // Unicode range for Greek and Coptic block is U+0370 to U+03FF.
        if (c >= '\u0370' && c <= '\u03FF' && char.IsLower(c))
        {
            return false;
        }

        // Rule 2: Allow standard letters and underscores.
        // char.IsLetter includes letters from many languages.
        if (char.IsLetter(c) || c == '_')
        {
            return true;
        }

        return false;
    }
}
