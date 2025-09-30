public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();

        if (string.IsNullOrWhiteSpace(statement))
        {
            return "Fine. Be that way!";
        }

        bool isQuestion = statement.EndsWith("?");
        bool hasLetters = statement.Any(char.IsLetter);
        bool isYelling = hasLetters && statement.Where(char.IsLetter).All(char.IsUpper);

        if (isYelling && isQuestion)
        {
            return "Calm down, I know what I'm doing!";
        }
        else if (isYelling)
        {
            return "Whoa, chill out!";
        }
        else if (isQuestion)
        {
            return "Sure.";
        }
        else
        {
            return "Whatever.";
        }
    }
}
