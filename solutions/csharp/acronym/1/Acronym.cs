using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase) =>
         string.Concat(Regex.Split(phrase, @"[- _]+")
                .Where(w => !string.IsNullOrEmpty(w))
                .Select(w => char.ToUpper(w[0])));
}