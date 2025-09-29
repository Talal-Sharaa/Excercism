public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string vOriginalStr, string vSubstringOn) =>
        vOriginalStr.Split(vSubstringOn)[1];
    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string vOriginalStr, string vSunstringLeft, string vSubstringRight) =>
        vOriginalStr.SubstringAfter(vSunstringLeft).Split(vSubstringRight)[0];
    // TODO: define the 'Message()' extension method on the `string` type
        public static string Message(this string vOriginalStr) => vOriginalStr.SubstringAfter(": ");
    // TODO: define the 'LogLevel()' extension method on the `string` type
        public static string LogLevel(this string vOriginalStr) =>
        vOriginalStr.SubstringBetween("[", "]");
}