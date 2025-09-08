using System.Globalization; 
public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB) => $"{studentA.PadLeft(29)} ♡ {studentB.PadRight(29)}";

    public static string DisplayBanner(string studentA, string studentB)
    =>
        $@"******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA} +  {studentB}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
            ";

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours) {
        CultureInfo culture = new CultureInfo("de-DE");
        string formattedYears = start.ToString("dd.MM.yyyy");
        string formattedHours = hours.ToString("N2", culture);
        return $"{studentA} and {studentB} have been dating since {formattedYears} - that's {formattedHours} hours";
        }
        
}
