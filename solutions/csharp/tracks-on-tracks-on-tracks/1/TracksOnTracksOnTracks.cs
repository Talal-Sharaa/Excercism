public static class Languages
{
    private static List<string> _LstLanguages = new List<string>(){"C#", "Clojure", "Elm"};
    
    public static List<string> NewList() => new List<string>();
    public static List<string> GetExistingLanguages() => _LstLanguages;

    public static List<string> AddLanguage(List<string> languages, string language) {
languages.Add(language);
        return languages;
    }
         

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count();
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
{
    // 1. Add a "guard clause" to handle null or empty lists safely.
    if (languages == null || languages.Count == 0)
    {
        return false;
    }

    // 2. Check the first condition: Is the first language "C#"?
    //    We already know Count is at least 1, so this is safe.
    if (languages[0] == "C#")
    {
        return true;
    }

    // 3. Check the second condition: Is the second language "C#" in a list of 2 or 3?
    //    We must first check if a second element even exists.
    if (languages.Count >= 2 && languages[1] == "C#")
    {
        if (languages.Count == 2 || languages.Count == 3)
        {
            return true;
        }
    }

    // 4. If neither of the "exciting" conditions were met, return false.
    return false;
}


    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages) => languages.Distinct().Count() == languages.Count();
}
