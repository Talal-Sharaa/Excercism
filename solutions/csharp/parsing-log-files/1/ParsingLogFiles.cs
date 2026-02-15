using System.Text.RegularExpressions;
public class LogParser
{
    private static readonly Regex _DelimiterRegex = new Regex("<[\\^*=\\-]+>");
    private static readonly Regex _EndOfLineRegex = 
        new Regex("end-of-line\\d+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    private static readonly Regex _PasswordsRegex = 
        new Regex(@"password\S+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    
    string[] _ValidStart = new string[]{
        "[TRC]",
        "[DBG]",
        "[INF]",
        "[WRN]",
        "[ERR]",
        "[FTL]"
    };
    public bool IsValidLine(string text) {
        foreach(string iStart in _ValidStart){
            if(text.StartsWith(iStart)){
                return true;
            }
        }
        return false;
    }

    public string[] SplitLogLine(string text) => _DelimiterRegex.Split(text);

    public int CountQuotedPasswords(string lines) => lines.ToLower().Split("\"password\"").Length;
    
    public string RemoveEndOfLineText(string logLine)
    {
        if (string.IsNullOrEmpty(logLine))
        {
            return logLine;
        }
        
        // Replace all matches of the pattern with an empty string.
        return _EndOfLineRegex.Replace(logLine, "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
{
    List<string> resultLines = new List<string>();
    foreach(string line in lines)
    {
        MatchCollection matches = _PasswordsRegex.Matches(line);
        if(matches.Count > 0)
        {
            string passwordToken = matches[matches.Count - 1].Value;
            resultLines.Add($"{passwordToken}: {line}");  
        }
        else
        {
            resultLines.Add($"--------: {line}");
        }
    }
    return resultLines.ToArray();
}

}
