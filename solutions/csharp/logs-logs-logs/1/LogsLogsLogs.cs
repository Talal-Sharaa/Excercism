// TODO: define the 'LogLevel' enum
enum LogLevel{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0
}
static class LogLine
{
    // A mapping from the string representation to the enum value.
    // 'static readonly' ensures it's created only once.
    private static readonly Dictionary<string, LogLevel> _logLevelMap = new Dictionary<string, LogLevel>
    {
        ["TRC"] = LogLevel.Trace,
        ["DBG"] = LogLevel.Debug,
        ["INF"] = LogLevel.Info,
        ["WRN"] = LogLevel.Warning,
        ["ERR"] = LogLevel.Error,
        ["FTL"] = LogLevel.Fatal
    };

    public static LogLevel ParseLogLevel(string logLine)
    {
        // Find the positions of the delimiters
        int startIndex = logLine.IndexOf('[') + 1;
        int endIndex = logLine.IndexOf(']');

        // Gracefully handle malformed strings
        if (startIndex == 0 || endIndex == -1 || endIndex < startIndex)
        {
            return LogLevel.Unknown;
        }

        // Extract the key without creating extra arrays
        string levelStr = logLine.Substring(startIndex, endIndex - startIndex);
        
        // Look up the value in the dictionary. If not found, return Unknown.
        if (_logLevelMap.TryGetValue(levelStr, out LogLevel level))
        {
            return level;
        }

        return LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
}
