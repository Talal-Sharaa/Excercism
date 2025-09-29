public class Robot
{
    private static Random _RandomAlphaNumeric = new Random();
    private static HashSet<string> _usedNames = new HashSet<string>();

    private string _name;

    public string Name
    {
        get
        {
            if (_name == null)
            {
                _name = GenerateUniqueName();
            }
            return _name;
        }
    }

    public void Reset()
    {
            _usedNames.Remove(_name); // Free old name
            _name = GenerateUniqueName();
    }

    private static string GenerateUniqueName()
    {
        string name;
        do
        {
            name = GenerateName();
        } while (_usedNames.Contains(name));

        _usedNames.Add(name);
        return name;
    }

    private static string GenerateName()
    {
        char randomChar1 = (char)_RandomAlphaNumeric.Next('A', 'Z' + 1);
        char randomChar2 = (char)_RandomAlphaNumeric.Next('A', 'Z' + 1);
        int randomDigit1 = _RandomAlphaNumeric.Next(0, 10);
        int randomDigit2 = _RandomAlphaNumeric.Next(0, 10);
        int randomDigit3 = _RandomAlphaNumeric.Next(0, 10);

        return $"{randomChar1}{randomChar2}{randomDigit1}{randomDigit2}{randomDigit3}";
    }
}
