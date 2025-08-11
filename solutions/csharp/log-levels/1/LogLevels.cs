static class LogLine
{
    public static string Message(string logLine)
     =>   logLine.Split(":")[1].Trim();

    public static string LogLevel(string logLine) {
        string xLevel = logLine.Split(":")[0].Trim();
        return xLevel.Substring(1, xLevel.Length-2).ToLower();
    } 

    public static string Reformat(string logLine)
        => $"{Message(logLine)} ({LogLevel(logLine)})";
}
