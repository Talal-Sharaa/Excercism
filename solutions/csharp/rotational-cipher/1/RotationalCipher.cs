using System.Text;
public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder xRotatedString = new StringBuilder();

        foreach (char iChar in text)
        {
            if (char.IsUpper(iChar))
            {
                char xRotated = (char)('A' + (iChar - 'A' + shiftKey) % 26);
                xRotatedString.Append(xRotated);
            }
            else if (char.IsLower(iChar))
            {
                char xRotated = (char)('a' + (iChar - 'a' + shiftKey) % 26);
                xRotatedString.Append(xRotated);
            }
            else
            {
                xRotatedString.Append(iChar);
            }
        }

        return xRotatedString.ToString();
    }
}
