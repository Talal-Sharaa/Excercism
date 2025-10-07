using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number cannot be empty.");

        string digits = Regex.Replace(phoneNumber.Trim(), @"\D", "");

        if (digits.Length == 11 && digits.StartsWith("1"))
        {
            digits = digits.Substring(1);
        }

        if (digits.Length != 10)
            throw new ArgumentException("Phone number must contain exactly 10 digits.");

        if (digits[0] < '2' || digits[3] < '2')
            throw new ArgumentException("Area code and exchange code cannot start with 0 or 1.");

        return digits;
    }
}
